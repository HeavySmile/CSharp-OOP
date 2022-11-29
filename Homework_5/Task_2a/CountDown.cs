using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2a
{
    public class CountDown : IEnumerator
    {
        public CountDown(object start)
        {
            Current = start;
        }
        public bool MoveNext()
        {
            if ((int)Current != 0)
            {
                Current = (int)Current - 1;
                return true;
            }

            return false;
        }
        public object Current
        {
            get; private set;
        }
        public void Reset()
        {
            Current = 16;
        }
    }
}
