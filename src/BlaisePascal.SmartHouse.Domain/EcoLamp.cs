using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BlaisePascal.SmartHouse.Domain
{
    public class EcoLamp
    {
        //Attributes:
        private bool IsOn;
        public byte Brightness { get; set; }
        private byte BrightnessBeforeTurnOff;
        const byte MaxBrightness = 65;
        private byte[] Color = new byte[3] { 255, 255, 255 }; //white; can't be changed
        private string Type;
        private double ConsumeAtMaxBrightnessPerHour;
        public Time OnTime;
        public Time OffTime;
        public Time _Timer;
        

        //Constructor:
        public EcoLamp(bool isOn, byte brightness, string type, double consumeAtMaxBrightnessPerHour, Time onTime, Time offTime, Time timer) 
        {
            _Timer = timer;

            IsOn = isOn;
            if (IsOn)
            {
                TimerToTurnOff();
            }

            if (brightness >= 1 && brightness <= 65)
            {
                Brightness = brightness;
                BrightnessBeforeTurnOff = Brightness;
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

        }



        /// <summary>
        /// Change the state of the Lamp, on or off.
        /// </summary>
        public bool TurnOnOrOff() 
        {
            if (IsOn == true)
            {
                Brightness = 0;
                IsOn = false;
            }
            else
            {
                Brightness = BrightnessBeforeTurnOff;
                IsOn = true;
                TimerToTurnOff(); 
            }
            return IsOn;
        }



        /// <summary>
        /// Set the timer to turn off the eco lapm.
        /// </summary>
        private async Task TimerToTurnOff() 
        {
            int time = ((_Timer.Hours * 3600) + (_Timer.Minutes * 60) + _Timer.Seconds)*1000;
            await Task.Delay(time);
            BrightnessBeforeTurnOff = Brightness;
            Brightness = 0;
            IsOn = false;
        }


    }
}
