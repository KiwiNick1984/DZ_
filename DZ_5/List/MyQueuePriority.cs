using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_5.Generic
{
    internal class MyQueuePriority<T> : IMyEnumerable<T>, IMyEnumerable
    {
        struct _priorityNode
        {
            public T _data;
            public int _priority;
            public _priorityNode(T data, int priority)
            {
                _data = data;
                _priority = priority;
            }
        }

        MyList<_priorityNode> _listNodes = new MyList<_priorityNode>();
        public int Count => _listNodes.Count;

        public void Enqueue(T item, int priority)
        {
            _listNodes.Add(new _priorityNode(item, priority));
            _listNodes.Sort(new PriorityComparer());
        }
        public T this[int index]
        {
            get
            { return _listNodes[index]._data; }
        }
        public T Dequeue()
        {
            T tempObj = _listNodes[0]._data;
            _listNodes.RemoveAt(0);
            return tempObj;
        }

        IMyEnumerator<T> IMyEnumerable<T>.GetEnumerator() => new Enumerator(this);
        IMyEnumerator IMyEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _listNodes[i]._data;
            }
        }

        public class Enumerator : IMyEnumerator, IMyEnumerator<T>
        {
            private readonly MyQueuePriority<T> _list;
            private int _index;
            private T _current;

            public Enumerator(MyQueuePriority<T> list)
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

        class PriorityComparer : IComparer<_priorityNode>
        {
            public int Compare(_priorityNode inNode1, _priorityNode inNode2)
            {
                return inNode1._priority - inNode2._priority;
            }
        }
    }
}
