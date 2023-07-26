using DZ_5.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_5
{
    public interface IMyList : IMyCollection, IMyEnumerable
    {
        object this[int index] { get; set; }
        void Add(object value);
        int IndexOf(object value);
        void Insert(int index, object value);
        void Remove(object value);
        void RemoveAt(int index);
    }
}
