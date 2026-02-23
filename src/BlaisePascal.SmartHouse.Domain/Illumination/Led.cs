using BlaisePascal.SmartHouse.Domain.Interface;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Illumination;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Illumination
{
    public sealed class Led : Device, IIllumination
    {
        // Attributes
        public Brightness Brightness { get; private set; }
        public Color Color; //RGB
        private Brightness BrightnessBeforeTurnOff;

        //Constructor
        public Led(Name name, bool isOn, Brightness brightness, Color color): base(name,isOn) 
        {
            try
            {
                Brightness = brightness;
                BrightnessBeforeTurnOff = Brightness;
            }
            catch (Exception ex)
            {
                return;
            }
            Color = color;
        }

        public Led(Name name) : base(name, AssigmentIsOn())
        {
            Color = Color.From(0, 0, 0);
            Brightness = Brightness.From(0);
        }
        private static bool AssigmentIsOn()
        {
            return false;
        }

        //Turn on the led
        public bool TurnOnOrOff()
        {
            if (IsOn == true)
            {
                IsOn = false;
                Brightness = Brightness.From(0);
                BrightnessBeforeTurnOff = Brightness;
                return IsOn;
            }
            else
            {
                IsOn = true;
                Brightness = BrightnessBeforeTurnOff;
                return IsOn;
            }
            
        }

        //Change the brightness of the led
        public void ChangeBrightness(byte newBrightness)
        {
            try
            {
                Brightness = Brightness.From(newBrightness);
                BrightnessBeforeTurnOff = Brightness;
            }
            catch (Exception ex)
            {
                return;
            }
        }

        // Changes the color of the led
        public void ChangeColor(Color colors)
        {
            Color = colors;
        }
    }
}
