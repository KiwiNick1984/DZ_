using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_5.Generic
{
    internal class MyQueue<T> : IMyEnumerable<T>, IMyEnumerable, IMyCollection
    {
        MyList<T> listStruct = new MyList<T>();
        public int Count => listStruct.Count;

        public void Enqueue(T item)
        {
            listStruct.Add(item);
        }
        public T Dequeue()
        {
            T tempObj = listStruct[0];
            listStruct.RemoveAt(0);
            return tempObj;
        }
        public void Clear()
        {
            listStruct.Clear();
        }
        public bool Contains(T item)
        {
            return listStruct.Contains(item);
        }
        bool IMyCollection.Contains(object inItem)
        {
            return Contains((T)inItem);
        }
        public T Peek()
        {
            return listStruct[0];
        }
        public T[] ToArray()
        {
            return listStruct.ToArray();
        }
        object[] IMyCollection.ToArray()
        {
            return ((IMyCollection)listStruct).ToArray();
        }
        IMyEnumerator<T> IMyEnumerable<T>.GetEnumerator() => new Enumerator(listStruct);
        IMyEnumerator IMyEnumerable.GetEnumerator() => new Enumerator(listStruct);
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return listStruct[i];
            }
        }

        public class Enumerator : IMyEnumerator, IMyEnumerator<T>
        {
            private readonly MyList<T> _list;
            private int _index;
            private T _current;

            public Enumerator(MyList<T> list)
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
