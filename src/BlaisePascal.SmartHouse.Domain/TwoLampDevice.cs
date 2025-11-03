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


        /// <summary>
        /// Change state to the first lamp.
        /// </summary>
        public void ChangeLamp1State()
        {

            FirstLamp.TurnOnOrOff();
        }



        /// <summary>
        /// Change state to the second lamp.
        /// </summary>
        public void ChangeLamp2State() { 
            SecondLamp.TurnOnOrOff();
        }



        /// <summary>
        /// Change state to both the lamp.
        /// </summary>
        public void ChangeBothLampState() {
            FirstLamp.TurnOnOrOff();
            SecondLamp.TurnOnOrOff();
        }


        /// <summary>
        /// Change first lamp brightness.
        /// </summary>
        /// <param name="brightness"></param>
        public void ChangeLamp1Brightness(byte brightness)
        {
            FirstLamp.Brightness = brightness;
        }



        /// <summary>
        /// Change second lamp brightness.
        /// </summary>
        /// <param name="brightness"></param>
        public void ChangeLamp2Brightness(byte brightness)
        {
            SecondLamp.Brightness = brightness;
        }



        /// <summary>
        /// Change both lamps brightness.
        /// </summary>
        /// <param name="firstLampBrightness"></param>
        /// <param name="secondLampBrightness"></param>
        public void ChangeBothLampBrightness(byte firstLampBrightness, byte secondLampBrightness)
        {
            FirstLamp.Brightness = firstLampBrightness;
            SecondLamp.Brightness = secondLampBrightness;
        }



        /// <summary>
        /// Change color to the first lamp.
        /// </summary>
        /// <param name="colors"></param>
        public void ChangeLamp1Color(byte[] colors) 
        { 
            FirstLamp.Color = colors;
        }



        /// <summary>
        /// Change color to the seond lamp.
        /// </summary>
        /// <param name="colors"></param>
        /*the color of eco lamp cant be changed because it's Eco
        public void ChangeLamp2Color(byte[] colors)
        {
            SecondLamp.Color = colors;
        }
        */ 


        /// <summary>
        /// Change both lamps colors.
        /// </summary>
        /// <param name="firstLampColors"></param>
        /// <param name="secondLampColors"></param>
        /*NO need
        public void ChangeBothLampColor(byte[] firstLampColors, byte[] secondLampColors)
        {
            FirstLamp.Color = firstLampColors;
            SecondLamp.Color = secondLampColors;
        }
        */
    }
}
