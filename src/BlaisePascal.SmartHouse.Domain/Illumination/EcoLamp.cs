using BlaisePascal.SmartHouse.Domain.Interface;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Illumination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BlaisePascal.SmartHouse.Domain.Illumination
{
    public sealed class EcoLamp : Device, IIllumination
    {
        //Attributes:
        public EcoBrightness Brightness { get; set; }
        const double ConsumeAtMaxBrightnessPerHour= 65.0;
        private EcoBrightness BrightnessBeforeTurnOff;

        private Color Color=Color.From ( 0,0, 0 ); //white; can't be changed
        private string Type;

        public Time OnTime;
        public Time OffTime;
        public Time _Timer;

        //Constructor:
        public EcoLamp(Name name, bool isOn, EcoBrightness brightness, string type, Time onTime, Time offTime, Time timer) : base(name, isOn)
        {
            _Timer = timer;
            IsOn = isOn;
            try
            {
                Brightness = brightness;
                BrightnessBeforeTurnOff = Brightness;
                if (IsOn)
                    TimerToTurnOff();

                if (!string.IsNullOrEmpty(type))
                    Type = type;

                if (onTime.Hours.Value > offTime.Hours.Value)
                    OnTime = onTime;

                if (onTime.Hours.Value > offTime.Hours.Value)
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
                Brightness = EcoBrightness.From(0);
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
                Brightness = EcoBrightness.From(newBrightness);
                BrightnessBeforeTurnOff = Brightness;
                Console.WriteLine($"Eco lamp brightness changed to {Brightness}");
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
                int time = (_Timer.Hours.Value * 3600 + _Timer.Minutes.Value * 60 + _Timer.Seconds.Value) * 1000;
                await Task.Delay(time);
                BrightnessBeforeTurnOff = Brightness;
                Brightness = EcoBrightness.From(0);
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
