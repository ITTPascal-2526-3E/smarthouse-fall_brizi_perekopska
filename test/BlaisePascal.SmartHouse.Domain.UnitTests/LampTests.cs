using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.UsefullClasses;
using BlaisePascal.SmartHouse.Domain.Illumination;

namespace BlaisePascal.SmartHouse.Domain.UnitTests
{
    
    public class LampTests
    {
        [Fact]
        public void Lamp_TurnOnOrOff_ChangesState()
        {
            bool isOn = false;
            var lamp = new Lamp(isOn, brightness: 50, color: new byte[] { 255, 0, 0 }, type: "LED", onTime: new Time(18, 0,2), offTime: new Time(6, 0,5));
            
            var initialState = isOn;
            var newState = lamp.TurnOnOrOff();

            Assert.NotEqual(initialState, newState);
        }

        [Fact]
        public void Lamp_TurnOnOrOff_SetsBrightnessToZeroWhenOff()
        {
            bool isOn = true;
            var lamp = new Lamp(isOn, brightness: 70, color: new byte[] { 0, 0, 255 }, type: "Incandescent", onTime: new Time(20, 0, 4), offTime: new Time(8, 0, 7));

            lamp.TurnOnOrOff(); // Turn off the lamp
            Assert.Equal(0, lamp.Brightness);
        }

        [Fact]
        public void Lamp_TurnOnOrOff_RestoresBrightnessWhenOn()
        {
            bool isOn = false;
            var lamp = new Lamp(isOn, brightness: 60, color: new byte[] { 255, 255, 0 }, type: "CFL", onTime: new Time(17, 0,1), offTime: new Time(5, 0,4));
            
            lamp.TurnOnOrOff(); // Turn on the lamp
            Assert.Equal(60, lamp.Brightness);
        }

        [Fact]
        public void Lamp_ChangeBrightness_UpdatesBrightness()
        {
            bool isOn = true;
            var lamp = new Lamp(isOn, brightness: 50, color: new byte[] { 0, 255, 0 }, type: "Halogen", onTime: new Time(19, 0,3), offTime: new Time(7, 0,6));
            
            byte newBrightness = 80;
            lamp.ChangeBrightness(newBrightness);
            Assert.Equal(newBrightness, lamp.Brightness);
        }


        
    }
}
