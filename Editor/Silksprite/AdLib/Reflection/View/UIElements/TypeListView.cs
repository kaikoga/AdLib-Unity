using System;
using System.Collections.Generic;
using System.Linq;
using AdLib.Reflection.Extensions;
using UnityEngine.UIElements;

namespace AdLib.Reflection.View.UIElements
{
    class TypeListView : VisualElement
    {
        readonly ListView _listView;
        readonly List<Type> _itemsSource = new List<Type>();
        public event Action<IEnumerable<Type>>? ItemsChosen;

        public TypeListView()
        {
            _listView = new ListView
            {
                itemsSource = _itemsSource,
                selectionType = SelectionType.Single
            };
            _listView.makeItem += () => new TypeView();
            _listView.bindItem += (visualElement, index) =>
            {
                var view = (TypeView)visualElement;
                view.Draw(_itemsSource[index]);
            };
            _listView.itemsChosen += selection => ItemsChosen?.Invoke(selection.OfType<Type>());
            hierarchy.Add(_listView);
        }

        public void Draw(List<Type> itemsSource)
        {
            _itemsSource.Clear();
            _itemsSource.AddRange(itemsSource);
            _listView.RefreshItems();
        }

        public new class UxmlFactory : UxmlFactory<TypeListView, UxmlTraits>
        {
        }
    }

    class TypeView : Label
    {
        public void Draw(Type type)
        {
            text = type.GetNestedTypeName();
        }
    } 
}
