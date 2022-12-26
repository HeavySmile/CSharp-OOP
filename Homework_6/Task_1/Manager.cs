using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class Manager : Employee
    {
        public Manager(string name, Store worksAt) : base(name, worksAt) { }

        public void GetAppointed()
        {

        }
        internal void ManageProductQuantity()
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
