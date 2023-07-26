using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_5.Generic
{
    public interface IMyCollection<T>
    {
        int Count { get; }
        void Add(T inItem);
        void Clear();
        bool Contains(T item);
        T[] ToArray();
    }
}
