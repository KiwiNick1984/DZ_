using DZ_5.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_5.Generic
{
    internal class TowWaysList<T> : OneWayList<T>
    {
        protected override OneWayNode<T> CreateNode(T data, OneWayNode<T> next = null, OneWayNode<T> prev = null)
        {
            TowWayNode<T> newDode = new TowWayNode<T>(data, next, prev);
            if (next != null)
                ((TowWayNode<T>)next).Prev = newDode;
            if (prev != null)
                prev.Next = newDode;
            return newDode;
        }
        protected override void DeleteNode(OneWayNode<T> current, OneWayNode<T> next = null, OneWayNode<T> prev = null)
        {
            current.Next = null;
            current.Data = default(T);
            ((TowWayNode<T>)current).Prev = null;
        }
    }
    class TowWayNode<T> : OneWayNode<T>
    {
        private OneWayNode<T> _prev;
        public OneWayNode<T> Prev
        {
            get { return _prev; }
            set { _prev = value; }
        }
        public TowWayNode(T data, OneWayNode<T> next = null, OneWayNode<T> prev = null) : base(data, next)
        {
            _prev = prev;
        }
    }
}
