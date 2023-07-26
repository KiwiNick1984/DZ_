using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_5.Generic
{
    internal class OneWayList<T> : IMyCollection<T>, IMyEnumerable<T>, IMyEnumerable
    {
        protected OneWayNode<T> _head;
        protected OneWayNode<T> _tail;
        protected int _count;

        public int Count => _count;
        public object First => _head;
        public object Last => _tail;

        public OneWayList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public void Add(T inObj)
        {
            AddLast(inObj);
        }
        public virtual void AddFirst(T data)
        {
            _head = CreateNode(data: data, next: _head);
            _count++;
        }
        public virtual void AddLast(T data)
        {
            if (_head == null)
            {
                _head = CreateNode(data: data);
                _tail = _head;
            }
            else
            {
                OneWayNode<T> current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                _tail = CreateNode(data: data, prev: current);
            }
            _count++;
        }
        public void Insert(int index, T data)
        {
            if ((uint)index > (uint)_count)
            {
                throw new Exception("ОШИБКА! Insert выход за пределы диапазона!");
            }

            if (index == _count)
            {
                AddLast(data);
            }
            else if (index == 0)
            {
                AddFirst(data);
            }
            else
            {
                OneWayNode<T> current = _head;
                for (int i = 0; i < _count; i++)
                {
                    if (i == index - 1)
                    {
                        CreateNode(data: data, next: current.Next, prev: current);
                        break;
                    }
                    current = current.Next;
                }
            }
            _count++;
        }
        public void Clear()
        {
            OneWayNode<T> currentNode = _head;
            while (currentNode != null)
            {
                OneWayNode<T> tempNode = currentNode;
                currentNode = currentNode.Next;
                DeleteNode(tempNode);
            }
            _head = null;
            _tail = null;
            _count = 0;
        }
        public bool Contains(T inItem)
        {
            if (Count > 0)
            {
                OneWayNode<T> current = _head;
                while (current.Next != null)
                {
                    if (current.Data.Equals(inItem))
                        return true;
                    current = current.Next;
                }
                if (current.Data.Equals(inItem))
                    return true;
            }
            return false;
        }
        public T[] ToArray()
        {
            if (Count > 0)
            {
                T[] array = new T[_count];
                OneWayNode<T> current = _head;

                for (int i = 0; current.Next != null; i++)
                {
                    array[i] = current.Data;
                    current = current.Next;
                }
                array[_count - 1] = current.Data;
                return array;
            }
            return null;
        }
        protected virtual OneWayNode<T> CreateNode(T data, OneWayNode<T> next = null, OneWayNode<T> prev = null)
        {
            OneWayNode<T> newDode = new OneWayNode<T>(data, next);
            if (prev != null)
                prev.Next = newDode;
            return newDode;
        }
        protected virtual void DeleteNode(OneWayNode<T> current, OneWayNode<T> next = null, OneWayNode<T> prev = null)
        {
            current.Next = null;
            current.Data = default(T);
        }

        IMyEnumerator<T> IMyEnumerable<T>.GetEnumerator() => new Enumerator(this);
        IMyEnumerator IMyEnumerable.GetEnumerator() => new Enumerator(this);
        public IEnumerator<T> GetEnumerator()
        {
            OneWayNode<T> _currentNode = _head;
            while (_currentNode.Next != null)
            {
                yield return _currentNode.Data;
                _currentNode = _currentNode.Next;
                if (_currentNode.Next == null)
                {
                    yield return _currentNode.Data;
                }
            }
        }

        public class Enumerator : IMyEnumerator, IMyEnumerator<T>
        {
            private OneWayNode<T> _currentNode;
            private T _currentData;
            private bool _stopNext;

            public Enumerator(OneWayList<T> list)
            {
                _currentNode = list._head;
            }

            public T Current => _currentData;
            object IMyEnumerator.Current => _currentData;

            public bool MoveNext()
            {
                if (!_stopNext)
                {
                    if (_currentNode?.Next == null)
                    {
                        _stopNext = true;
                        _currentData = _currentNode.Data;
                        return true;
                    }
                    _currentData = _currentNode.Data;
                    if (_currentNode?.Next != null)
                    {
                        _currentNode = _currentNode.Next;
                    }
                    return true;
                }
                return false;
            }
            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
    class OneWayNode<T>
    {
        private OneWayNode<T> _next;
        private T _data;
        public OneWayNode<T> Next
        {
            get { return _next; }
            set { _next = value; }
        }
        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }
        public OneWayNode(T inObjData, OneWayNode<T> next = null)
        {
            _data = inObjData;
            _next = next;
        }
    }
}
