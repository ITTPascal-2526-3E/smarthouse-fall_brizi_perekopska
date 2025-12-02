using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UsefulClasses
{
    public class Time
    {
        //Attributes:
        public int Hours{ get; set;}
        public int Minutes { get; set;}
        public int Seconds { get; set;}

        //Constructor:
        public Time(int hours, int minutes, int seconds)
        {
            try {
                if (hours <= 23 && hours >= 0)
                    Hours = hours;
                else
                    throw new Exception();

                if (minutes <= 59 && minutes >= 0)
                    Minutes = minutes;
                else
                    throw new Exception();

                if (seconds <= 59 && seconds >= 0)
                    Seconds = seconds;
                else
                    throw new Exception();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
