using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
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

        /// Change state to the first lamp.
        public void ChangeLamp1State()
        {
            FirstLamp.TurnOnOrOff();
        }

        /// Change state to the second lamp.
        public void ChangeLamp2State() { 
            SecondLamp.TurnOnOrOff();
        }

        /// Change state to both the lamp.
        public void ChangeBothLampState() {
            FirstLamp.TurnOnOrOff();
            SecondLamp.TurnOnOrOff();
        }

        /// Change first lamp brightness.
        /// <param name="brightness"></param>
        public void ChangeLamp1Brightness(byte brightness)
        {
            FirstLamp.Brightness = brightness;
        }

        /// Change second lamp brightness.
        /// <param name="brightness"></param>
        public void ChangeLamp2Brightness(byte brightness)
        {
            SecondLamp.Brightness = brightness;
        }

        /// Change both lamps brightness.
        /// <param name="firstLampBrightness"></param>
        /// <param name="secondLampBrightness"></param>
        public void ChangeBothLampBrightness(byte firstLampBrightness, byte secondLampBrightness)
        {
            FirstLamp.Brightness = firstLampBrightness;
            SecondLamp.Brightness = secondLampBrightness;
        }

        /// Change color to the first lamp.
        /// <param name="colors"></param>
        public void ChangeLamp1Color(byte[] colors) 
        { 
            FirstLamp.Color = colors;
        }
    }
}
