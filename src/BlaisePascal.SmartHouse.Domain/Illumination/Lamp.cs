using BlaisePascal.SmartHouse.Domain.UsefullClasses;

namespace BlaisePascal.SmartHouse.Domain.Illumination
{
    public class Lamp
    {

        //Attributes:
        private bool IsOn;

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
        public Lamp(bool isOn,byte brightness,byte[] color,string type,Time onTime,Time offTime) 
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

        /// Change the state of the Lamp, on or off.
        public bool TurnOnOrOff() 
        {
            if (IsOn == true)
            {
                IsOn = false;
                Brightness = 0;
            }
            else 
            {
                Brightness = BrightnessBeforeTurnOff;
                IsOn = true;
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
        }

    }
}
