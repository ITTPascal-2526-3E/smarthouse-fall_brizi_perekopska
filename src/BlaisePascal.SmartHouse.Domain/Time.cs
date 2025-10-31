using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Time
    {
        public int Hours{ get; set;}
        public int Minutes { get; set;}
        public int Seconds { get; set;}

        public Time(int hours, int minutes, int seconds)
        {
            if (hours <= 23 && hours >= 0)
            {
                Hours = hours;
            }

            if (minutes <= 59 && minutes >= 0)
            {
                Minutes = minutes;
            }

            if (seconds <= 59 && seconds >= 0)
            {
                Seconds = seconds;
            }
        }
    }
}
