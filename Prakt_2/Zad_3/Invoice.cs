using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zad_3
{
    public class Invoice
    {
        private string partDescription;
        private string partNumber;
        private decimal pricePerItem;
        private int quantity;

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="partDescription"></param>
        /// <param name="partNumber"></param>
        /// <param name="pricePerItem"></param>
        /// <param name="quantity"></param>
        public Invoice(string partDescription, string partNumber, decimal pricePerItem, int quantity)
        {
            PartDescription = partDescription;
            PartNumber = partNumber;
            PricePerItem = pricePerItem;
            Quantity = quantity;
        }
        
        public string PartDescription 
        { 
            get { return partDescription; } 
            set { partDescription = value; }
        }
        public string PartNumber
        {
            get { return partNumber; }
            set { partNumber = value; }
        }
        public decimal PricePerItem
        {
            get { return pricePerItem; }
            set { pricePerItem = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        /// <summary>
        /// Calculates invoice total price
        /// </summary>
        /// <returns>invoice total price</returns>
        public decimal GetInvoiceAmount()
        {
            return PricePerItem <= 0 || Quantity <= 0 ? 0 : PricePerItem * Quantity;
        }
    }
}