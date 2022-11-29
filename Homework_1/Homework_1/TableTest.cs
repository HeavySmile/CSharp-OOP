using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    /// <summary>
    /// Passive class
    /// </summary>
    public class TableTest
    {
        #region Data members
        
        private double start;
        private double end;
        private int stepCount;
        private Table? table;

        #endregion

        #region Methods
        
        /// <summary>
        /// Reads values from keyboard
        /// </summary>
        public void ReadValues()
        {
            Console.Write("Input start value: ");
            start = Double.Parse(Console.ReadLine());
            Console.Write("Input end value: ");
            end = Double.Parse(Console.ReadLine());
            Console.Write("Input amount of steps: ");
            stepCount = int.Parse(Console.ReadLine());
        } 
        
        /// <summary>
        /// Checks if start and end are valid
        /// </summary>
        /// <returns>Validation of start and end</returns>
        public bool CheckStartEndValue()
        {
            if (start > end) (start, end) = (end, start);

            return start < end;
        }
        /// <summary>
        /// Initializes table object with data members
        /// </summary>
        public void Initialize()
        {
            table = new Table(start, end, stepCount);
        }
        /// <summary>
        /// Invokes MakeTable method for table data member
        /// </summary>
        public void MakeTable()
        {
            if (table == null)
            {
                Console.WriteLine("First initialize the object");
                return;
            }

            table.MakeTable();
        }

        #endregion
    }
}
