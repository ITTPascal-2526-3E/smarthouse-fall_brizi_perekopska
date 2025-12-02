using BlaisePascal.SmartHouse.Domain.UsefullClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using BlaisePascal.SmartHouse.Domain.UsefullClasses;
namespace BlaisePascal.SmartHouse.Domain.Illumination
{
    public class EcoLamp 
    {
        //Attributes:
        private bool IsOn;
        public byte Brightness { get; set; }
        const double ConsumeAtMaxBrightnessPerHour= 65.0;
        private byte BrightnessBeforeTurnOff;
        const byte MaxBrightness = 65;
        const byte MinBrightness = 1;

        private byte[] Color = new byte[3] { 255, 255, 255 }; //white; can't be changed
        private string Type;

        public Time OnTime;
        public Time OffTime;
        public Time _Timer;

        //Constructor:
        public EcoLamp(bool isOn, byte brightness, string type, Time onTime, Time offTime, Time timer) 
        {
            _Timer = timer;
            IsOn = isOn;
            try
            {
                if (brightness >= MinBrightness && brightness <= MaxBrightness)
                {
                    Brightness = brightness;
                    BrightnessBeforeTurnOff = Brightness;
                }
                if (IsOn)
                    TimerToTurnOff();

                if (!string.IsNullOrEmpty(type))
                    Type = type;

                if (onTime.Hours > offTime.Hours)
                    OnTime = onTime;

                if (onTime.Hours > offTime.Hours)
                    OffTime = offTime;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        // Change the state of the Lamp, on or off
        public bool TurnOnOrOff() 
        {
            if (IsOn == true)
            {
                BrightnessBeforeTurnOff = Brightness;
                Brightness = 0;
                IsOn = false;
                Console.WriteLine("Eco lamp is turned off");
            }
            else
            {
                Brightness = BrightnessBeforeTurnOff;
                IsOn = true;
                TimerToTurnOff(); 
                Console.WriteLine("Eco lamp is turned on and the timer to turn off is set");
            }
            return IsOn;
        }
      
        // Changes the brightness of the eco lamp
        public void ChangeBrightness(byte newBrightness)
        {
            try
            {
                if (newBrightness >= MinBrightness && newBrightness <= MaxBrightness)
                {
                    Brightness = newBrightness;
                    BrightnessBeforeTurnOff = Brightness;
                    Console.WriteLine($"Eco lamp brightness changed to {Brightness}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        // Set the timer to turn off the eco lapm
        private async Task TimerToTurnOff()
        {
            try
            {
                int time = (_Timer.Hours * 3600 + _Timer.Minutes * 60 + _Timer.Seconds) * 1000;
                await Task.Delay(time);
                BrightnessBeforeTurnOff = Brightness;
                Brightness = 0;
                IsOn = false;
                Console.WriteLine("Eco lamp is turned off by timer");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
