using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zad_1
{
    public class Time
    {
        private const int DEFAULT_HOUR = 12;
        private const int DEFAULT_MINUTE = 0;
        private const int DEFAULT_SECOND = 0;
        private int hour;
        private int minute;
        private int second;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Time()
        {
            Hour = DEFAULT_HOUR;
            Minute = DEFAULT_MINUTE;
            Second = DEFAULT_SECOND;
        }
        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="hour">Hour</param>
        /// <param name="minute">Minute</param>
        /// <param name="second">Second</param>
        public Time(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public int Hour 
        { 
            get { return hour; }
            set 
            { 
                if(hour >= 0 && hour <= 23) hour = value;
                else hour = DEFAULT_HOUR;
            }
        }
        public int Minute
        {
            get { return minute; }  
            set
            {
                if (minute >= 0 && minute <= 59) minute = value;
                else minute = DEFAULT_MINUTE;
            }
        }
        public int Second
        {
            get { return second; }
            set
            {
                if (second >= 0 && second <= 59) second = value;
                else second = DEFAULT_SECOND;
            }
        }
    }
}