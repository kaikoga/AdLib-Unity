using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AdLib.Reflection.View.UIElements
{
    class AdLibAccessGeneratorWindowView : VisualElement
    {
        const string UxmlPath = "Packages/net.kaikoga.adlib/Editor/Silksprite/AdLib/Reflection/View/Uxml/AdLibAccessGeneratorWindowView.uxml";
        const string UssPath = "Packages/net.kaikoga.adlib/Editor/Silksprite/AdLib/Reflection/View/Uxml/AdLib.uss";

        public readonly AssemblyListView AssemblyList;
        public readonly NamespaceListView NamespaceList;
        public readonly TypeListView TypeList;
        public readonly TextField ActualNamespaceField;
        public readonly TextField ActualClassNameField;
        public readonly ObjectField SourceCodeField;
        public readonly TextField AccessNamespaceField;
        public readonly TextField AccessClassNameField;
        public readonly TextField GeneratedCodeField;
        public readonly Button WriteButton;

        public AdLibAccessGeneratorWindowView()
        {
            styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>(UssPath));
            var container = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(UxmlPath).CloneTree();
            container.style.flexGrow = 1;
            AssemblyList = container.Q<AssemblyListView>("assemblyList");
            NamespaceList = container.Q<NamespaceListView>("namespaceList");
            TypeList = container.Q<TypeListView>("typeList");
            ActualNamespaceField = container.Q<TextField>("actualNamespaceField");
            ActualClassNameField = container.Q<TextField>("actualClassNameField");
            SourceCodeField = container.Q<ObjectField>("sourceCodeField");
            AccessNamespaceField = container.Q<TextField>("accessNamespaceField");
            AccessClassNameField = container.Q<TextField>("accessClassNameField");
            GeneratedCodeField = container.Q<TextField>("generatedCodeField");
            WriteButton = container.Q<Button>("writeButton");
            
            GeneratedCodeField.SetVerticalScrollerVisibility(ScrollerVisibility.Auto);
            hierarchy.Add(container);
        }
    }
}
