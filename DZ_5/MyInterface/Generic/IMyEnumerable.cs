using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_5.Generic
{
    public interface IMyEnumerable<out T> : IMyEnumerable
    {
        new IMyEnumerator<T> GetEnumerator();
    }
}
