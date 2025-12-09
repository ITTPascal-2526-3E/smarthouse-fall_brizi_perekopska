using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;

namespace BlaisePascal.SmartHouse.Domain.Illumination
{
    public class Led: Device
    {
        // Attributes
        public byte Brightness { get; private set; }
        public byte[] Color=new byte[3] { 0,0,0}; //RGB
        const byte MaxBrightness = 100;
        const byte MinBrightness = 1;
        private byte BrightnessBeforeTurnOff;

        //Constructor
        public Led(string name, bool isOn,byte brightness, byte[] color): base(name,isOn) 
        {
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        //Turn on the led.
        public bool TurnOn()
        {            
            IsOn = true;
            Brightness = BrightnessBeforeTurnOff;
            return IsOn;
        }
        //Turn offthe led.
        public bool TurnOff() 
        {
            IsOn = false;
            Brightness = 0;
            return IsOn;
        }

        //Change the brightness of the led.
        public void ChangeBrightness(byte newBrightness)
        {
            try
            {
                if (newBrightness >= MinBrightness && newBrightness <= MaxBrightness)
                {
                    Brightness = newBrightness;
                    BrightnessBeforeTurnOff = Brightness;                }
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
