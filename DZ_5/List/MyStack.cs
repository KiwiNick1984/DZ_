using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_5.Generic
{
    internal class MyStack<T> : IMyEnumerable<T>, IMyEnumerable, IMyCollection
    {
        MyList<T> _items = new MyList<T>();
        public int Count => _items.Count;

        public void Push(T inObj)
        {
            _items.Add(inObj);
        }
        public T Pop()
        {
            T tempObj = _items[Count - 1];
            _items.RemoveAt(Count - 1);
            return tempObj;
        }
        public T Peek()
        {
            return _items[Count - 1];
        }
        public T this[int index]
        {
            get
            { return _items[index]; }
            set
            { _items[index] = value; }
        }
        public bool Contains(T inItem)
        {
            return _items.Contains(inItem);
        }
        bool IMyCollection.Contains(object inItem)
        {
            return Contains((T)inItem);
        }
        public T[] ToArray()
        {
            return _items.ToArray();
        }
        object[] IMyCollection.ToArray()
        {
            return ((IMyCollection)_items).ToArray();
        }
        public void Clear()
        {
            _items.Clear();
        }

        IMyEnumerator<T> IMyEnumerable<T>.GetEnumerator() => new Enumerator(this);
        IMyEnumerator IMyEnumerable.GetEnumerator() => new Enumerator(this);
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _items[i];
            }
        }

        public class Enumerator : IMyEnumerator, IMyEnumerator<T>
        {
            private readonly MyStack<T> _list;
            private int _index;
            private T _current;

            public Enumerator(MyStack<T> list)
            {
                _list = list;
                _index = 0;
                _current = default(T);
            }

            public T Current => _current;
            object IMyEnumerator.Current => _current;

            public bool MoveNext()
            {
                if (_index < _list.Count)
                {
                    _current = _list[_index++];
                    return true;
                }
                return false;
            }
            public void Reset()
            {
                _index = 0;
                _current = default;
            }
        }
    }
}
