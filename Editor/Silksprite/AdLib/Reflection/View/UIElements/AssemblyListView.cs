using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine.UIElements;

namespace AdLib.Reflection.View.UIElements
{
    class AssemblyListView : VisualElement
    {
        readonly ListView _listView;
        readonly List<Assembly> _itemsSource = new List<Assembly>();
        public event Action<IEnumerable<Assembly>>? ItemsChosen;

        public AssemblyListView()
        {
            _listView = new ListView
            {
                itemsSource = _itemsSource,
                selectionType = SelectionType.Single
            };
            _listView.makeItem += () => new AssemblyView();
            _listView.bindItem += (visualElement, index) =>
            {
                var view = (AssemblyView)visualElement;
                view.Draw(_itemsSource[index]);
            };
            _listView.itemsChosen += selection => ItemsChosen?.Invoke(selection.OfType<Assembly>());
            hierarchy.Add(_listView);
        }

        public void Draw(List<Assembly> itemsSource)
        {
            _itemsSource.Clear();
            _itemsSource.AddRange(itemsSource);
            _listView.RefreshItems();
        }

        public new class UxmlFactory : UxmlFactory<AssemblyListView, UxmlTraits>
        {
        }
    }

    class AssemblyView : Label
    {
        public void Draw(Assembly assembly) => text = assembly.GetName().Name;
    } 
}
