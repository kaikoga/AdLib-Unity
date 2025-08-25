using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Silksprite.AdLib.Utils
{
    public abstract class CustomClone<T, TOut>
        where T : Object
        where TOut : Object
    {
        CopyStrategyDescriptor _descriptor;

        protected abstract void Define(CopyStrategyDescriptor descriptor);

        [PublicAPI]
        public (TOut mainAsset, IEnumerable<Object> subAssets) Clone(T source)
        {
            var result = DoClone(source);
            return (result.mainAsset, result.context.Mapping.Values.Where(a => a != result.mainAsset).ToArray());
        }

        [PublicAPI]
        public (TOut mainAsset, Dictionary<Object, Object> mappings) CloneWithMappings(T source)
        {
            var result = DoClone(source);
            return (result.mainAsset, result.context.Mapping
                .Where(mapping => mapping.Value != result.mainAsset)
                .ToDictionary(mapping => mapping.Key, mapping => mapping.Value));
        }

        [PublicAPI]
        public Object CloneAsNewAsset(T source, string assetPath, HideFlags? overrideSubAssetHideFlags = null)
        {
            var assets = DoClone(source);
            AssetDatabase.CreateAsset(assets.mainAsset, assetPath);
            foreach (var mapping in assets.context.Mapping
                         .Where(mapping => mapping.Value != assets.mainAsset))
            {
                AssetDatabase.AddObjectToAsset(mapping.Value, assets.mainAsset);
                mapping.Value.hideFlags = overrideSubAssetHideFlags switch
                {
                    { } value => value,
                    null => mapping.Key.hideFlags
                };
            }
            AssetDatabase.SaveAssets();
            return assets.mainAsset;
        }
        
        (TOut mainAsset, CustomCloneContext context) DoClone(T source)
        {
            if (_descriptor == null)
            {
                _descriptor = new CopyStrategyDescriptor();
                Define(_descriptor);                
            }
            
            var context = new CustomCloneContext(_descriptor);
            var mainAsset = context.CachedClone(source) as TOut;
            return (mainAsset, context);
        }
    }
    
    public abstract class CustomClone<T> : CustomClone<T, T> where T : Object { }

    public class CustomCloneContext
    {
        readonly CopyStrategyDescriptor _descriptor;
        public readonly Dictionary<Object, Object> Mapping = new Dictionary<Object, Object>();
            
        public CustomCloneContext(CopyStrategyDescriptor descriptor) => _descriptor = descriptor;

        public Object CachedClone(Object source)
        {
            if (source is null) return default;

            foreach (var copyStrategy in _descriptor.List)
            {
                if (copyStrategy.Match(source))
                {
                    return copyStrategy.GetCopy(source, this);
                }
            }
            throw new CustomCloneException($"Unable to handle object <{source}> with type <{source.GetType()}>");
        }
    }

    public class CopyStrategyDescriptor
    {
        public List<ICopyStrategy> List { get; } = new List<ICopyStrategy>();
        public void Add(ICopyStrategy copyStrategy) => List.Add(copyStrategy);

        public void ShallowCopy<T>(bool childClasses = false) where T : Object => Add(new ShallowCopy<T>(childClasses));
        public void DeepCopy<T>(bool childClasses = false, Func<Object, T> instantiate = null, Action<T, CustomCloneContext> duplicateFields = null, Action<T> postProcess = null)
            where T : Object
        {
            Add(new DeepCopy<T>(childClasses, instantiate, duplicateFields, postProcess));
        }
    }

    public interface ICopyStrategy
    {
        bool Match(Object source);
        Object GetCopy(Object source, CustomCloneContext context);
    }

    public class ShallowCopy<T> : ICopyStrategy
        where T : Object
    {
        readonly bool _childClasses;

        public bool Match(Object source) => _childClasses ? source is T : source.GetType() == typeof(T);
        public Object GetCopy(Object source, CustomCloneContext context) => source;

        public ShallowCopy(bool childClasses = false)
        {
            _childClasses = childClasses;
        }
    }
    
    public class DeepCopy<T> : ICopyStrategy
        where T : Object
    {
        readonly bool _childClasses;
        readonly Func<Object, T> _instantiate;
        readonly Action<T, CustomCloneContext> _duplicateFields;
        readonly Action<T> _postProcess;

        public DeepCopy(bool childClasses = false, Func<Object, T> instantiate = null, Action<T, CustomCloneContext> duplicateFields = null, Action<T> postProcess = null)
        {
            _childClasses = childClasses;
            _instantiate = instantiate ?? Instantiate;
            _duplicateFields = duplicateFields ?? DuplicateFields;
            _postProcess = postProcess ?? Postprocess;
        }

        public bool Match(Object source) => _childClasses ? source is T : source.GetType() == typeof(T);

        public Object GetCopy(Object source, CustomCloneContext context)
        {
            if (context.Mapping.TryGetValue(source, out var mapped)) return mapped;
            var target = _instantiate(source);
            context.Mapping[source] = target;
            _duplicateFields(target, context);
            _postProcess(target);
            return target;
        }

        protected virtual T Instantiate(Object source)
        {
            T target;
            var ctor = typeof(T).GetConstructor(Type.EmptyTypes);
            if (ctor == null || source is ScriptableObject)
            {
                target = (T) Object.Instantiate(source);
                target.name = source.name;
            }
            else
            {
                target = (T) ctor.Invoke(Array.Empty<object>());
                EditorUtility.CopySerialized(source, target);
            }
            return target;
        }

        protected virtual void DuplicateFields(T target, CustomCloneContext context)
        {
            var serializedObject = new SerializedObject(target);
            var it = serializedObject.GetIterator();
            
            var enterChildren = true;
            while (it.Next(enterChildren))
            {
                enterChildren = true;
                switch (it.propertyType)
                {
                    case SerializedPropertyType.ObjectReference:
                        if (it.objectReferenceValue == target)
                        {
                            // Skip self reference, already duplicated
                            break;
                        }
                        it.objectReferenceValue = context.CachedClone(it.objectReferenceValue);
                        break;
                    case SerializedPropertyType.String:
                        // Iterating strings can get super slow...
                        enterChildren = false;
                        break;
                }
            }
            serializedObject.ApplyModifiedPropertiesWithoutUndo();
        }

        [UsedImplicitly]
        protected virtual void Postprocess(T target)
        {
        }
    }
    
    public class CustomCloneException : Exception
    {
        public CustomCloneException(string message) : base(message) { }
    }
}