using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;

namespace AdLib.Reflection.View.UIElements
{
    class NamespaceListView : VisualElement
    {
        readonly ListView _listView;
        readonly List<string> _itemsSource = new List<string>();
        public event Action<IEnumerable<string>>? ItemsChosen;

        public NamespaceListView()
        {
            _listView = new ListView
            {
                itemsSource = _itemsSource,
                selectionType = SelectionType.Single
            };
            _listView.makeItem += () => new NamespaceView();
            _listView.bindItem += (visualElement, index) =>
            {
                var view = (NamespaceView)visualElement;
                view.Draw(_itemsSource[index]);
            };
            _listView.itemsChosen += selection => ItemsChosen?.Invoke(selection.OfType<string>());
            hierarchy.Add(_listView);
        }

        public void Draw(List<string> itemsSource)
        {
            _itemsSource.Clear();
            _itemsSource.AddRange(itemsSource);
            _listView.RefreshItems();
        }

        public new class UxmlFactory : UxmlFactory<NamespaceListView, UxmlTraits>
        {
        }
    }

    class NamespaceView : Label
    {
        public void Draw(string ns) => text = ns;
    } 
}
