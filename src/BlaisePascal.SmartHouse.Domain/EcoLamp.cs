using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class EcoLamp
    {
        //Attributes:
        public bool IsOn { get; set; }
        public byte Brightness { get; set; }
        const byte MaxBrightness = 65;
        private byte[] Color = new byte[3] { 255, 255, 255 }; //white; can't be changed
        private string Type;
        private double ConsumeAtMaxBrightnessPerHour;
        public Time OnTime;
        public Time OffTime;
        public Time Timer;
        

        //Constructor:
        public EcoLamp(bool isOn, byte brightness, string type, double consumeAtMaxBrightnessPerHour, Time onTime, Time offTime, Time timer) 
        {
            IsOn = isOn;


            if (brightness >= 1 && brightness <= 65)
            {
                Brightness = brightness;
            }


            if (!string.IsNullOrEmpty(type))
            {
                Type = type;
            }


            if (consumeAtMaxBrightnessPerHour > 0.0)
            {
                ConsumeAtMaxBrightnessPerHour = consumeAtMaxBrightnessPerHour;
            }


            if (onTime.Hours > offTime.Hours)
            {
                OnTime = onTime;
            }


            if (onTime.Hours > offTime.Hours)
            {
                OffTime = offTime;
            }

            Timer = timer;

        }
    }
}
