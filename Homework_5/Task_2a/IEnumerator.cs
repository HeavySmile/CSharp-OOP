using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2a
{
    public interface IEnumerator
    {
        public bool MoveNext();
        public object Current { get; }
        public void Reset();
    }
}
