using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class Employee : EventArgs
    {
        private string name;
        private Store worksAt;

        public Employee(string name, Store worksAt)
        {
            Name = name;
            WorksAt = worksAt;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Store WorksAt
        {
            get { return worksAt; }
            set { worksAt = value; }
        }
        public void GetAppointed()
        {

        }
        internal void ManageListOfProducts()
        {
            Console.WriteLine(GetType());
        }
        public void ManageQty(Product p, int qty)
        {
            worksAt.OnUpdateQuantity(worksAt.ListOfProducts.FindIndex(0, worksAt.ListOfProducts.Count, x => p.Equals(x)), qty);
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
