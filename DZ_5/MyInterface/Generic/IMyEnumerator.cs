using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_5.Generic
{
    public interface IMyEnumerator<out T> : IMyEnumerator
    {
        new T Current
        {
            get;
        }
    }
}
