using BlaisePascal.SmartHouse.Domain.Interface;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;
using BlaisePascal.SmartHouse.Domain.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Illumination
{
    public sealed class Lamp : Device, IIllumination
    {
        //Attributes:
        public Brightness Brightness { get; private set; }
        const float ConsumeAtMaxBrightnessPerHour = 100.0f;
        private Brightness BrightnessBeforeTurnOff;

        public byte[] Color = new byte[3] { 0,0,0}; //RGB
        public string Type { get; private set; }

        public Time OnTime;
        public Time OffTime;

        //Constructor:
        public Lamp(Name name, bool isOn, Brightness brightness, byte[] color,string type,Time onTime,Time offTime) : base(name, isOn) 
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

                if (onTime.Hours > offTime.Hours)
                    OnTime = onTime;
                else
                    throw new Exception();
                
                if (onTime.Hours > offTime.Hours)
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
                Console.WriteLine("The lamp is turned off");
            }
            else 
            {
                IsOn = true;
                Brightness = BrightnessBeforeTurnOff;
                Console.WriteLine("The lamp is turned on");
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
                Console.WriteLine($"The lamp brightness is changed to {Brightness}");
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
                return;
            }
        }

        // Changes the color of the  lamp
        public void ChangeLampColor(byte[] colors)
        {
            Color = colors;
            Console.WriteLine($"The lamp color is changed to RGB({Color[0]}, {Color[1]}, {Color[2]})");
        }

    }
}
