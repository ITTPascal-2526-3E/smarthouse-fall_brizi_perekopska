using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Illumination
{
    
    public class TwoLampDevice
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
        }

        // Change state to the second lamp.
        public void ChangeLamp2State() { 
            SecondLamp.TurnOnOrOff();
        }

        // Change state to both the lamp
        public void ChangeBothLampState() {
            FirstLamp.TurnOnOrOff();
            SecondLamp.TurnOnOrOff();
        }

        // Change first lamp brightness
        public void ChangeLamp1Brightness(byte brightness)
        {
            FirstLamp.ChangeBrightness(brightness);
        }

        // Change second lamp brightness.
        public void ChangeLamp2Brightness(byte brightness)
        {
            SecondLamp.Brightness = brightness;
        }

        // Change both lamps brightness
        public void ChangeBothLampBrightness(byte firstLampBrightness, byte secondLampBrightness)
        {
            FirstLamp.ChangeBrightness(firstLampBrightness);
            SecondLamp.ChangeBrightness(secondLampBrightness);
        }

        // Change color to the first lamp
        public void ChangeLamp1Color(byte[] colors) 
        { 
            FirstLamp.Color = colors;
        }
    }
}
