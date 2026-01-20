using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;

namespace BlaisePascal.SmartHouse.Domain.Illumination
{
    
    public sealed class TwoLampDevice
    {
        //Attributes:
        private Lamp FirstLamp;
        private EcoLamp SecondLamp;

        //Constructor:
        public TwoLampDevice(Lamp firstLamp, EcoLamp secondLamp) 
        { 
            FirstLamp=firstLamp;
            SecondLamp = secondLamp;
        }

        // Change state to the first lamp.
        public void ChangeLamp1State()
        {
            FirstLamp.TurnOnOrOff();
            Console.WriteLine("First lamp state changed");
        }

        // Change state to the second lamp.
        public void ChangeLamp2State() { 
            SecondLamp.TurnOnOrOff();
            Console.WriteLine("Second lamp state changed");
        }

        // Change state to both the lamp
        public void ChangeBothLampState() {
            FirstLamp.TurnOnOrOff();
            SecondLamp.TurnOnOrOff();
            Console.WriteLine("Both lamps state changed");
        }

        // Change first lamp brightness
        public void ChangeLamp1Brightness(byte brightness)
        {
            FirstLamp.ChangeBrightness(brightness);
            Console.WriteLine("First lamp brightness changed to " + brightness);
        }

        // Change second lamp brightness.
        public void ChangeLamp2Brightness(byte brightness)
        {
            SecondLamp.Brightness = brightness;
            Console.WriteLine("Second lamp brightness changed to " + brightness);
        }

        // Change both lamps brightness
        public void ChangeBothLampBrightness(byte firstLampBrightness, byte secondLampBrightness)
        {
            FirstLamp.ChangeBrightness(firstLampBrightness);
            SecondLamp.ChangeBrightness(secondLampBrightness);
            Console.WriteLine("Both lamps brightness changed to " + firstLampBrightness + " and " + secondLampBrightness);
        }

        // Change color to the first lamp
        public void ChangeLamp1Color(byte[] colors) 
        { 
            FirstLamp.Color = colors;
            Console.WriteLine("First lamp color changed to RGB(" + colors[0] + ", " + colors[1] + ", " + colors[2] + ")");
        }
    }
}
