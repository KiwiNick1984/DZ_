using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_5
{
    public interface IMyCollection
    {
        void Clear();
        bool Contains(object value);
        int Count { get; }
        object[] ToArray();
    }
}
