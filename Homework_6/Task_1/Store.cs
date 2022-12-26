using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class Store : INotifyPropertyChanged
    {
        public event EventHandler Appoint;
        public event PropertyChangedEventHandler? PropertyChanged;

        private static int cnt = 0;
        private List<Product> listOfProducts = new List<Product>();
        private Manager manager;
        private Employee worker;
        public readonly string STORE_NAME;

        public Store(string storeName)
        {
            STORE_NAME = storeName;
        }

        public List<Product> ListOfProducts
        {
            get { return new List<Product>(listOfProducts); }
            set 
            { 
                listOfProducts = value.ConvertAll(product => new Product(product.Description, product.Quantity));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListOfProducts"));
            }
        }
        public Employee Worker
        {
            get { return worker; }
            set { worker = value; }
        }

        public void OnAppointment()
        {
            Appoint?.Invoke(worker, EventArgs.Empty);
        }
        public void OnUpdateQuantity(int index, int newQty)
        {
            if(newQty != listOfProducts[index].Quantity)
            {
                Product product = listOfProducts[index];
                Console.WriteLine($"{product.Description} quantity {product.Quantity} : new quantity {newQty}");
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProductQuantity"));
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
