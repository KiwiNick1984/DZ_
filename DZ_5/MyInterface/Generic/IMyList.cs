using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_5.Generic
{
    public interface IMyList<T> : IMyCollection<T>, IMyEnumerable<T>, DZ_5.IMyEnumerable
    {
        T this[int index] { get; set; }
        int IndexOf(T inItem);
        void Insert(int index, T inItem);
        void RemoveAt(int index);
    }
}
