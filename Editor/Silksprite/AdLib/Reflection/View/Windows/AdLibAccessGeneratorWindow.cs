using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using AdLib.Reflection.Extensions;
using AdLib.Reflection.Generator;
using AdLib.Reflection.View.UIElements;
using UnityEditor;
using UnityEngine;

namespace AdLib.Reflection.View.Windows
{
    class AdLibAccessGeneratorWindow : EditorWindow
    {
        [MenuItem("Tools/Ablet/Debug/Other Tools/AdLib Access Generator", false, 101)]
        static void ShowWindow()
        {
            (GetWindow<AdLibAccessGeneratorWindow>() ?? CreateInstance<AdLibAccessGeneratorWindow>()).Show();
        }

        AdLibAccessGeneratorWindowView? _view;
        readonly List<Assembly> _assemblyList = new List<Assembly>();
        readonly List<string?> _namespaceList = new List<string?>();
        readonly List<Type> _typeList = new List<Type>();

        [SerializeField]
        string[] currentAssemblyNames = { };
        [SerializeField]
        string[] currentNamespaceNames = { };
        [SerializeField]
        string[] currentTypeNames = { };

        IEnumerable<Assembly> CurrentAssemblies => _assemblyList.Where(assembly => currentAssemblyNames.Contains(assembly.GetName().Name));
        IEnumerable<Type> CurrentTypes => CurrentAssemblies.SelectMany(assembly => assembly.GetTypes()).Where(type => currentTypeNames.Contains(type.FullName));

        Type? CurrentType => CurrentTypes.FirstOrDefault(); 

        void CreateGUI()
        {
            titleContent = new GUIContent("AdLib Access Generator");
            minSize = new Vector2(800f, 400f);
            _view = new AdLibAccessGeneratorWindowView();
            rootVisualElement.Add(_view);

            _view.AssemblyList.ItemsChosen += OnAssemblyChosen; 
            _view.NamespaceList.ItemsChosen += OnNamespaceChosen; 
            _view.TypeList.ItemsChosen += OnTypeChosen; 
            _view.WriteButton.clicked += OnWriteButtonClicked;

            _assemblyList.Clear();
            _assemblyList.AddRange(AppDomain.CurrentDomain.GetAssemblies().OrderBy(assembly => assembly.GetName().Name));
            _view.AssemblyList.Draw(_assemblyList);
            DrawNamespaceList();
            DrawTypeList();
            DrawType();
        }

        static readonly Regex TypeNameStartsWithAlphabet = new Regex("^[a-zA-Z].*$");
        void OnAssemblyChosen(IEnumerable<Assembly> assemblies)
        {
            currentAssemblyNames = assemblies.Select(assembly => assembly.GetName().Name).ToArray();
            DrawNamespaceList();
        }

        void DrawNamespaceList()
        {
            _namespaceList.Clear();
            _namespaceList.AddRange(CurrentAssemblies
                .SelectMany(assembly => assembly.GetTypes())
                .Select(type => type.Namespace)
                .Distinct()
                .OrderBy(ns => ns));
            _view?.NamespaceList.Draw(_namespaceList);
        }

        void OnNamespaceChosen(IEnumerable<string?> namespaces)
        {
            currentNamespaceNames = namespaces.Select(ns => ns ?? "").ToArray();
            DrawTypeList();
        }

        void DrawTypeList()
        {
            _typeList.Clear();
            _typeList.AddRange(CurrentAssemblies.SelectMany(assembly => assembly.GetTypes()
                .Where(type => currentNamespaceNames.Contains(type.Namespace ?? ""))
                .Where(type => TypeNameStartsWithAlphabet.IsMatch(type.Name))
                .OrderBy(type => type.GetNestedTypeName())));
            _view?.TypeList.Draw(_typeList);
        }

        void OnTypeChosen(IEnumerable<Type> types)
        {
            currentTypeNames = types.Select(t => t.FullName).ToArray();
            DrawType();
        }

        void DrawType()
        {
            if (!(CurrentType is { } type))
            {
                return;
            }
            _view?.ActualNamespaceField.SetValueWithoutNotify(type.Namespace);
            _view?.ActualClassNameField.SetValueWithoutNotify(type.GetNestedTypeName());
            GuessSourceCode(type);
            RefreshGeneratedCodeField(type);
        }

        static readonly Regex NamespaceDefinitionInSourceCode = new Regex(@"^namespace\s+(\S+)$", RegexOptions.Multiline);
        void GuessSourceCode(Type type)
        {
            var guessedAccessFileName = $"{type.GetNestedTypeName()}Access".Replace(".", "Class.");
            var attributeString = $@"ReflectionAccess(""{type.GetNestedTypeName()}"", ""{type.Assembly.GetName().Name}"")";
            var sourceCode = AssetDatabase.FindAssets($"t:MonoScript {guessedAccessFileName}")
                .Concat(AssetDatabase.FindAssets("t:MonoScript"))
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(AssetDatabase.LoadAssetAtPath<MonoScript>)
                .FirstOrDefault(script => script.text.Contains(attributeString) || script.name == guessedAccessFileName);
            _view?.SourceCodeField.SetValueWithoutNotify(sourceCode);
            if (sourceCode != null)
            {
                var actualNs = NamespaceDefinitionInSourceCode.Match(sourceCode.text).Groups[1].Value;
                _view?.AccessNamespaceField.SetValueWithoutNotify(actualNs);
                _view?.AccessClassNameField.SetValueWithoutNotify(sourceCode.name.Replace(".", "+"));
            }
            else
            {
                _view?.AccessClassNameField.SetValueWithoutNotify(guessedAccessFileName.Replace(".", "+"));
            }
        }
        
        void RefreshGeneratedCodeField(Type type)
        {
            _view?.GeneratedCodeField.SetValueWithoutNotify(ReflectionAccessGeneratorBase.Create(type, _view.AccessNamespaceField.value, _view.AccessClassNameField.value).Generate());
        }

        void OnWriteButtonClicked()
        {
            string monoScriptPath;
            if (_view!.SourceCodeField.value is { } asset)  
            {
                monoScriptPath = AssetDatabase.GetAssetPath(asset);
            }
            else
            {
                monoScriptPath = EditorUtility.SaveFilePanelInProject("Save", _view.AccessClassNameField.value, "cs", "Save");
            }
            if (!string.IsNullOrWhiteSpace(monoScriptPath))
            {
                File.WriteAllText(monoScriptPath, _view!.GeneratedCodeField.value);
            }
        }
    }
}
