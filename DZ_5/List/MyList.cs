using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_5.Generic
{
    internal class MyList<T> : IMyList<T>, IMyList, IMyCollection<T>, IMyCollection
    {
        private T[] _items;
        private int _size;
        private int _capacity;

        public int Count => _size;
        public int Capacity
        {
            get => _capacity;
        }

        public MyList(int inCapacity = 4)
        {
            _items = new T[0];
            EnsureCapacity(inCapacity);
        }

        public virtual void Add(T inItem)
        {
            if (_size == _items.Length)
            {
                EnsureCapacity(_size + 1);
            }
            _items[_size++] = inItem;
        }

        void IMyList.Add(object inItem)
        {
            try
            {
                Add((T)inItem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public T this[int index]
        {
            get
            { return _items[index]; }
            set
            { _items[index] = value; }
        }
        object IMyList.this[int index]
        {
            get
            { return _items[index]; }
            set
            {
                try
                {
                    _items[index] = (T)value;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public void Clear()
        {
            for (int i = 0; i < _items.Length; i++)
            {
                _items[i] = default(T);
            }
            _size = 0;
        }
        public bool Contains(T inItem)
        {
            if (inItem == null)
            {
                for (int i = 0; i < _size; i++)
                {
                    if (_items[i] == null)
                    {
                        return true;
                    }
                }
                return false;
            }
            EqualityComparer<T> defal = EqualityComparer<T>.Default;
            for (int i = 0; i < _size; i++)
            {
                if (defal.Equals(_items[i], inItem))
                    return true;
            }
            return false;
        }
        bool IMyCollection.Contains(object inItem)
        {
            return Contains((T)inItem);
        }
        public virtual void Insert(int index, T inItem)
        {
            if ((uint)index > (uint)_size)
            {
                throw new Exception("ОШИБКА! выход за пределы диапазона!");
            }
            if (_size == _items.Length)
            {
                EnsureCapacity(_size + 1);
            }
            for (int i = _size; i > index; i--)
            {
                _items[i] = _items[i - 1];
            }
            _items[index] = inItem;
            _size++;
        }
        void IMyList.Insert(int index, object inIndex)
        {
            try
            {
                Insert(index, (T)inIndex);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public virtual void Remove(T inItem)
        {
            int num = IndexOf(inItem);
            if (num >= 0)
            {
                RemoveAt(num);
            }
        }
        void IMyList.Remove(object inItem)
        {
            Remove((T)inItem);
        }
        public void RemoveAt(int index)
        {
            if ((uint)index >= (uint)_size)
            {
                throw new Exception("ОШИБКА! Выход за пределы диапазона!");
            }
            for (int i = index; i < _size - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
            _items[_size - 1] = default(T);
            _size--;
        }
        public int IndexOf(T inItem)
        {
            for (int i = 0; i < _size; i++)
            {
                if (inItem.Equals(_items[i]))
                    return i;
            }
            return -1;
        }
        int IMyList.IndexOf(object inObj)
        {
            return IndexOf((T)inObj);
        }
        public int LastIndexOf(T inItem)
        {
            int tempIndex = -1;
            for (int i = 0; i < _size; i++)
            {
                if (inItem.Equals(_items[i]))
                    tempIndex = i;
            }

            return tempIndex;
        }
        public T[] ToArray()
        {
            T[] array = new T[_size];
            for (int i = 0; i < _size; i++)
            {
                array[i] = _items[i];
            }
            return array;
        }
        object[] IMyCollection.ToArray()
        {
            object[] array = new object[_size];
            for (int i = 0; i < _size; i++)
            {
                array[i] = _items[i];
            }
            return array;
        }
        public void Reverse()
        {
            T tempObj;
            for (int i = 0; i < _size / 2; i++)
            {
                tempObj = _items[i];
                _items[i] = _items[_size - i - 1];
                _items[_size - i - 1] = tempObj;
            }
        }
        public void Sort()
        {
            //IComparable<T> tempItem;
            int i;
            for (int j = 1; j < Count; j++)
            {
                if (_items[j] is IComparable<T> tempItem)
                {
                    tempItem = (IComparable<T>)_items[j];
                    i = j - 1;
                    while (i >= 0 && tempItem.CompareTo(_items[i]) < 0)
                    {
                        _items[i + 1] = _items[i];
                        i--;
                    }
                    _items[i + 1] = (T)tempItem;
                }
            }
        }
        public void Sort(IComparer<T> comparer)
        {
            T tempItem;
            int i;
            for (int j = 1; j < Count; j++)
            {
                tempItem = _items[j];
                i = j - 1;
                while (i >= 0 && comparer.Compare(tempItem, _items[i]) < 0)
                {
                    _items[i + 1] = _items[i];
                    i--;
                }
                _items[i + 1] = tempItem;
            }
        }
        public int BinarySearch(T searchedVal)
        {
            return BinarySearchPrivate(searchedVal, 0, Count);
        }
        private int BinarySearchPrivate(T searchedVal, int leftIndex, int rightIndex)
        {
            if (leftIndex > rightIndex)
                return -1;

            var middle = (leftIndex + rightIndex) / 2;
            IComparable<T> middleVal = (IComparable<T>)_items[middle];

            if (middleVal.CompareTo(searchedVal) == 0)
            {
                return middle;
            }
            else
            {
                if (middleVal.CompareTo(searchedVal) > 0)
                    return BinarySearchPrivate(searchedVal, leftIndex, middle - 1);
                else
                    return BinarySearchPrivate(searchedVal, middle + 1, rightIndex);
            }
        }

        private void EnsureCapacity(int min)
        {
            if (_items.Length < min)
            {
                _capacity = ((_items.Length == 0) ? 4 : (_items.Length * 2));
                if ((uint)_capacity > 2146435071u)
                {
                    _capacity = 2146435071;
                }
                if (_capacity < min)
                {
                    _capacity = min;
                }

                T[] tempObjArr = new T[_capacity];
                for (int i = 0; i < _items.Length; i++)
                {
                    tempObjArr[i] = _items[i];
                }
                _items = tempObjArr;
            }
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
