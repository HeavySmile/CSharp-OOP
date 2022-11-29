using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    /// <summary>
    /// Represents 1/4 of a year
    /// </summary>
    public enum YearlyQuarter 
    { 
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4
    }
    /// <summary>
    /// Represents type of a certain item
    /// </summary>
    public enum Type 
    { 
        M = 'M',
        F = 'F'
    }
    /// <summary>
    /// Represents a product woth different attributes
    /// </summary>
    public class Product
    {
        #region Data members
        
        private static Random rnd = new Random();
        private long cnt;
        public string ID;
        public List<int> WeeklyPurchases;

        #endregion

        #region Constructors

        /// <summary>
        /// General-purpose constructor
        /// </summary>
        /// <param name="description"></param>
        /// <param name="category"></param>
        /// <param name="weeklyPurchases"></param>
        /// <param name="price"></param>
        public Product(string description, Type category, List<int> weeklyPurchases, decimal price)
        {
            Description = description;
            Category = category;
            WeeklyPurchases = weeklyPurchases;
            Price = price;
            Quarter = (YearlyQuarter)rnd.Next(1, 5);
            ID = CreateID();
        }

        #endregion
        
        #region Properties

        public Type Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public YearlyQuarter Quarter { get; set; }

        #endregion

        #region Methods
        /// <summary>
        /// Creates a unuqie ID
        /// </summary>
        /// <returns>new ID</returns>
        private string CreateID()
        {
            int number = rnd.Next(1, 1000000);
            int digitCount = number.ToString().Length;

            string zeros = "";
            for (int i = digitCount; i < 6; i++) zeros += "0";

            return Category.ToString() + zeros + number.ToString();
        }
        public override string ToString()
        {
            return ID.ToString() + ": " + String.Join(", ", WeeklyPurchases);
        } 
        #endregion
    }
}
