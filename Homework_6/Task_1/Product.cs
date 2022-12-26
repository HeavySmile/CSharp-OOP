using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class Product
    {
        private string description;
        private int quantity;

        public Product(string description)
        {
            Description = description;
            Quantity = 0;
        }
        public Product(string description, int quantity)
        {
            Description = description;
            Quantity = quantity;
        }
        
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set 
            { 
                quantity = value; 
            }
        }
    }
}
