using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Time;

namespace BlaisePascal.SmartHouse.Domain.UsefulClasses
{
    public sealed class Time
    {
        //Attributes:
        public Hour Hours{ get; set;}
        public Minutes Minutes { get; set;}
        public Seconds Seconds { get; set;}

        //Constructor:
        public Time(Hour hours, Minutes minutes, Seconds seconds)
        {
            Hours = hours;
            Minutes = minutes;   
            Seconds = seconds;
                
            
        }
    }
}
