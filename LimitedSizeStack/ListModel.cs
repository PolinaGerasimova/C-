//using System;
//using System.Collections.Generic;

//namespace LimitedSizeStack
//{

//    public class ListModel<TItem>
//    {
//        public enum Action
//        {
//            AddItem,
//            RemoveItem
//        }
//        public List<TItem> Items { get; }
//        public int UndoLimit;
//        LimitedSizeStack<Tuple<Action, int, TItem>> historyAction;

//        public ListModel(int undoLimit)
//        {
//            Items = new List<TItem>();
//            UndoLimit = undoLimit;
//            historyAction = new LimitedSizeStack<Tuple<Action, int, TItem>>(undoLimit);
//        }

//        public void AddItem(TItem item)
//        {

//            historyAction.Push(Tuple.Create(Action.AddItem, Items.Count, item));
//            Items.Add(item);
//        }

//        public void RemoveItem(int index)
//        {
//            historyAction.Push(Tuple.Create(Action.RemoveItem, index, Items[index]));
//            Items.RemoveAt(index);
//        }

//        public bool CanUndo()
//        {
//            return historyAction.Count > 0;
//        }

//        public void Undo()
//        {
//            var (item1, item2, item3) = historyAction.Pop();

//            if (item1 == Action.AddItem)
//                Items.RemoveAt(historyAction.Count);
//            else if (item1 == Action.RemoveItem)
//            {
//                if (historyAction.Count == 1) Items.Insert(item2 - 1, item3);
//                else Items.Insert(item2, item3);
//            }
//        }
//    }
//}

using System;
using System.Collections.Generic;

namespace LimitedSizeStack
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class AddItemCommand<TItem> : ICommand
    {
        private List<TItem> _items;
        private TItem _item;

        public AddItemCommand(List<TItem> items, TItem item)
        {
            _items = items;
            _item = item;
        }

        public void Execute()
        {
            _items.Add(_item);
        }

        public void Undo()
        {
            _items.RemoveAt(_items.Count - 1);
        }
    }

    public class RemoveItemCommand<TItem> : ICommand
    {
        private List<TItem> _items;
        private int _index;
        private TItem _item;
        public RemoveItemCommand(List<TItem> items, int index)
        {
            _items = items;
            _index = index;
            _item = items[index];
        }

        public void Execute()
        {
            _items.RemoveAt(_index);
        }

        public void Undo()
        {
            _items.Insert(_index, _item);
        }
    }
    
    public class ListModel<TItem>
    {
        public List<TItem> Items { get; }
        public int UndoLimit;
        LimitedSizeStack<ICommand> historyAction;
        public ListModel(int undoLimit)
        {
            Items = new List<TItem>();
            UndoLimit = undoLimit;
            historyAction = new LimitedSizeStack<ICommand>(undoLimit);
        }

        public void AddItem(TItem item)
        {
            var command = new AddItemCommand<TItem>(Items, item);
            command.Execute();
            historyAction.Push(command);
        }

        public void RemoveItem(int index)
        {
            var command = new RemoveItemCommand<TItem>(Items, index);
            command.Execute();
            historyAction.Push(command);
        }

        public bool CanUndo()
        {
            return historyAction.Count > 0;
        }

        public void Undo()
        {
            if (CanUndo())
            {
                var command = historyAction.Pop();
                command.Undo();
            }
        }
    }
}