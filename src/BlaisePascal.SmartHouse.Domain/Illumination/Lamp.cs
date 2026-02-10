using BlaisePascal.SmartHouse.Domain.Interface;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Illumination;

namespace BlaisePascal.SmartHouse.Domain.Illumination
{
    public sealed class Lamp : Device, IIllumination
    {
        //Attributes:
        public Brightness Brightness { get; private set; }
        const float ConsumeAtMaxBrightnessPerHour = 100.0f;
        private Brightness BrightnessBeforeTurnOff;

        public Color Color; //RGB
        public string Type { get; private set; }

        public Time OnTime;
        public Time OffTime;

        //Constructor:
        public Lamp(Name name, bool isOn, Brightness brightness, Color color,string type,Time onTime,Time offTime) : base(name, isOn) 
        { 
            IsOn = isOn;
            Color = color;
            try
            {
                Brightness = brightness;
                BrightnessBeforeTurnOff = Brightness;

                if (!string.IsNullOrEmpty(type))
                    Type = type;
                else
                    throw new Exception();

                if (onTime.Hours.Value > offTime.Hours.Value)
                    OnTime = onTime;
                else
                    throw new Exception();
                
                if (onTime.Hours.Value > offTime.Hours.Value)
                    OffTime = offTime;
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        /// Change the state of the Lamp, on or off.
        public bool TurnOnOrOff() 
        {
            if (IsOn == true)
            {
                IsOn = false;
                Brightness = Brightness.From(0);
                BrightnessBeforeTurnOff = Brightness;
            }
            else 
            {
                IsOn = true;
                Brightness = BrightnessBeforeTurnOff;
            }

            return IsOn;
        }

        /// Changes the brightness of the lamp
        public void ChangeBrightness(byte newBrightness)
        {
            try
            {
                Brightness = Brightness.From(newBrightness);
                BrightnessBeforeTurnOff = Brightness;
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
                return;
            }
        }

        // Changes the color of the  lamp
        public void ChangeLampColor(Color colors)
        {
            Color = colors;
        }

    }
}
