using DZ_5.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_5
{
    public interface IMyEnumerable
    {
        IMyEnumerator GetEnumerator();
    }
}
