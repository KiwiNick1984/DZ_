using DZ_5.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_5
{
    internal class EvantList_add<T> : EventArgs
    {
        public T Item { get; private set; }
        public int Index { get; set; }
        public EvantList_add(T item, int index = 0)
        {
            Item = item;
            Index = index;
        }
    }
    internal class MyObservableList<T> : MyList<T>
    {
        public event EventHandler<EvantList_add<T>> ListChanged_add;
        public event EventHandler<EvantList_add<T>> ListChanged_remove;
        public override void Add(T inItem)
        {
            base.Add(inItem);
            ListChanged_add?.Invoke(this, new EvantList_add<T>(inItem, Count - 1));
        }
        public override void Insert(int index, T inItem)
        {
            base.Insert(index, inItem);
            ListChanged_add?.Invoke(this, new EvantList_add<T>(inItem, index));
        }
        public override void Remove(T inItem)
        {
            base.Remove(inItem);
            ListChanged_remove?.Invoke(this, new EvantList_add<T>(inItem));
        }
    }
}
