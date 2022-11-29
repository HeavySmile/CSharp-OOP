using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    /// <summary>
    /// Active class
    /// </summary>
    public class Table
    {
        #region Constants

        private const int DEFAULT_STEPCOUNT = 1;

        #endregion

        #region Data members

        private double start;
        private double end;
        private int stepCount;

        #endregion

        #region Constructors

        /// <summary>
        /// General-purpose constructor
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="stepCount"></param>
        public Table(double start, double end, int stepCount)
        {
            Start = start;
            End = end;
            StepCount = stepCount;
        }

        #endregion

        #region Properties

        public double Start 
        { 
            get { return start; }
            set { start = value; } 
        }
        public double End 
        {
            get { return end; }
            set { end = value; }
        }
        public int StepCount
        {
            get { return stepCount; }
            set { stepCount = value <= 0 ? value : DEFAULT_STEPCOUNT; }
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Calculates table for start, end and stepCount parameters
        /// </summary>
        public void MakeTable()
        {
            double step = (end - start) / (double)stepCount;

            double x = start;

            for (int i = 1; i <= stepCount + 1; i++)
            {
                if (i == stepCount + 1) x = Math.Round(x);

                double value = (Math.Pow(Math.Abs(x - 2), 2)) / (Math.Pow(x, 2) + 1);

                Console.WriteLine($"{Math.Round(x, 4)}\t{Math.Round(value, 4)}");

                x += step;

                if (i % 20 == 0)
                {
                    Console.WriteLine("Press return to continue");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        
        #endregion
    }
}
