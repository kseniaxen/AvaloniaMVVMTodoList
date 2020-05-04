using AvaloniaMVVMTodoDemo.Models;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI.Legacy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AvaloniaMVVMTodoDemo.ViewModels
{
    public class TodoListViewModel : ViewModelBase
    {
        private IEnumerable<TodoItem> items;
        public TodoListViewModel(IEnumerable<TodoItem> _items)
        {
            this.items = _items;
            // Items = new ReactiveList<TodoItem>(items);
            // CheckedItems = 
            //Items = new ObservableCollection<TodoItem>(items);

            //CheckedItems = new ObservableCollection<TodoItem>(
            //    Items.Where((todoItem) => todoItem.IsChecked)
            //);

            foreach (var item in Items)
            {
                item.Changed.Subscribe((model)=> {
                    CheckedItems.Clear();
                    CheckedItems.AddRange(Items.Where((todoItem) => todoItem.IsChecked));
                });
            }
        }
        // public ReactiveList<TodoItem> Items { get; }
        private ObservableCollection<TodoItem> _items;
        public ObservableCollection<TodoItem> Items {
            get
            {
                return _items ?? (_items = new ObservableCollection<TodoItem>(items));
            }
        }

        private ObservableCollection<TodoItem> _checkedItems;
        public ObservableCollection<TodoItem> CheckedItems {
            get {
                return _checkedItems ?? (_checkedItems = new ObservableCollection<TodoItem>(
                    Items.Where((todoItem) => todoItem.IsChecked)));
            }
        }
    }
}
