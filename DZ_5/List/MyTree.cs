using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_5.Generic
{
    internal class MyTree<T> where T : IComparable<T>
    {
        public MyTree(int count = 0)
        {
            _count = count;
        }

        int _count;
        public T _data;
        MyTree<T> _left;
        MyTree<T> _right;

        public int Count => _count;

        public void Add(T inInt)
        {
            if (_count == 0)
            {
                _data = inInt;
                _count++;
            }
            else
            {
                //if(inInt < _data)
                if (inInt.CompareTo(_data) < 0)
                {
                    if (_left == null)
                    {
                        _left = new MyTree<T>(++_count);
                        _left._data = inInt;
                    }
                    else
                    {
                        ++_count;
                        _left.Add(inInt);
                    }
                }
                else
                {
                    if (_right == null)
                    {
                        _right = new MyTree<T>(++_count);
                        _right._data = inInt;
                    }
                    else
                    {
                        ++_count;
                        _right.Add(inInt);
                    }
                }
            }
        }

        public bool Contains(T inInt)
        {
            if (inInt.CompareTo(_data) == 0)
            {
                return true;
            }
            else if (inInt.CompareTo(_data) < 0)
            {
                if (_left != null)
                    return _left.Contains(inInt);
                else
                    return false;
            }
            else
            {
                if (_right != null)
                    return _right.Contains(inInt);
                else
                    return false;
            }
        }

        public T[] ToArray()
        {
            T[] leftArr = new T[0];
            T[] rightArr = new T[0];
            T[] returnArr;
            if (_left != null)
            {
                leftArr = _left.ToArray();
            }
            if (_right != null)
            {
                rightArr = _right.ToArray();
            }
            if (_left == null && _right == null)
            {
                return new T[] { _data };
            }
            returnArr = new T[leftArr.Length + rightArr.Length + 1];
            for (int i = 0; i < leftArr.Length; i++)
            {
                returnArr[i] = leftArr[i];
            }
            for (int i = leftArr.Length; i < returnArr.Length - 1; i++)
            {
                returnArr[i] = rightArr[i - leftArr.Length];
            }
            returnArr[returnArr.Length - 1] = _data;
            return returnArr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Stack<stackNode> stack = new Stack<stackNode>();
            stack.Push(new stackNode(_data, _right));
            MyTree<T> _nextNode = _left;
            while (stack.Count != 0)
            {
                if (_nextNode != null)
                {
                    stack.Push(new stackNode(_nextNode._data, _nextNode._right));
                    _nextNode = _nextNode._left;
                }
                else if (stack.Peek()._right != null && !stack.Peek()._print)
                {
                    stack.Peek()._print = true;
                    _nextNode = stack.Peek()._right._left;
                    stack.Push(new stackNode(stack.Peek()._right._data, stack.Peek()._right._right));
                }
                else
                {
                    yield return stack.Pop()._dataNode;
                }
            }
        }

        private class stackNode
        {
            public T _dataNode;
            public MyTree<T> _right;
            public bool _print;
            public stackNode(T data, MyTree<T> right)
            {
                _dataNode = data;
                _right = right;
            }
        }
    }
}
