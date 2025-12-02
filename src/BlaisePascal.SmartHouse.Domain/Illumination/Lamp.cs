using BlaisePascal.SmartHouse.Domain.UsefulClasses;

namespace BlaisePascal.SmartHouse.Domain.Illumination
{
    public class Lamp : Device
    {

        //Attributes:
        public byte Brightness { get; private set; }
        const double ConsumeAtMaxBrightnessPerHour = 100.0;
        private byte BrightnessBeforeTurnOff;
        const byte MaxBrightness = 100;
        const byte MinBrightness = 1;

        public byte[] Color = new byte[3] { 0,0,0}; //RGB
        private string Type;

        public Time OnTime;
        public Time OffTime;

        //Constructor:
        public Lamp(string name, bool isOn, byte brightness,byte[] color,string type,Time onTime,Time offTime) : base(name, isOn) 
        { 
            IsOn = isOn;
            Color = color;
            try
            {
                if (brightness >= MinBrightness && brightness <= MaxBrightness)
                {
                    Brightness = brightness;
                    BrightnessBeforeTurnOff = Brightness;
                }
                else 
                {
                    throw new Exception();
                }

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
                Brightness = 0;
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
                if (newBrightness >= MinBrightness && newBrightness <= MaxBrightness)
                {
                    Brightness = newBrightness;
                    BrightnessBeforeTurnOff = Brightness;
                    Console.WriteLine($"The lamp brightness is changed to {Brightness}");
                }
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
