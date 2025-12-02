using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.UsefullClasses;
using BlaisePascal.SmartHouse.Domain.Illumination;

namespace BlaisePascal.SmartHouse.Domain.UnitTests.IlluminationTests
{
    
    public class LampTests
    {
        //Constructor
        [Fact]
        public void Constructor_BrightnessIsGreaterThanMaxBrightness_BrightbessNotAssigned() 
        {
            byte brightness = 101;
            var Lamp = new Lamp(true,brightness , [0,0,0],"Led",new Time(11,11,11),new Time(11,11,11));
            Assert.NotEqual(brightness, Lamp.Brightness);
        }
        [Fact]
        public void Constructor_BrightnessIsLessThanMinBrightness_BrightbessIs0()
        {
            byte brightness = 0;
            var Lamp = new Lamp(true, brightness, [0, 0, 0], "Led", new Time(11, 11, 11), new Time(11, 11, 11));
            Assert.Equal(brightness, Lamp.Brightness);
        }
        [Fact]
        public void Constructor_BrightnessIsAcceptable_BrightbessIsSetted()
        {
            byte brightness = 99;
            var Lamp = new Lamp(true, brightness, [0, 0, 0], "Led", new Time(11, 11, 11), new Time(11, 11, 11));
            Assert.Equal(brightness, Lamp.Brightness);
        }
        [Fact]
        public void Constructor_TypeIsNull_TypeNotAssigned()
        {
            string type = "";
            var Lamp = new Lamp(true, 80, [0, 0, 0], type, new Time(11, 11, 11), new Time(11, 11, 11));
            Assert.Equal(type, Lamp.Type);
        }
        [Fact]
        public void Constructor_TypeIsNotNull_TypeAssigned()
        {
            string type = "LED";
            var Lamp = new Lamp(true, 80, [0, 0, 0], type, new Time(11, 11, 11), new Time(11, 11, 11));
            Assert.Equal(type, Lamp.Type);
        }
        [Fact]
        public void Constructor_OnTimeHourIsLessthanOffTimeHour_OnTimeNotAssigned()
        {
            var timeOn = new Time(10, 11, 11);
            var timeOff=new Time(11, 11, 11);
            var Lamp = new Lamp(true, 80, [0, 0, 0], "Led",timeOn , timeOff);
            Assert.NotEqual(timeOn, Lamp.OnTime);
        }


        // TurnOnOrOff tests
        [Fact]
        public void TurnOnOrOff_ChangesState()
        {
            bool isOn = false;
            var lamp = new Lamp(isOn, brightness: 50, color: new byte[] { 255, 0, 0 }, type: "LED", onTime: new Time(18, 0,2), offTime: new Time(6, 0,5));
            
            var initialState = isOn;
            var newState = lamp.TurnOnOrOff();

            Assert.NotEqual(initialState, newState);
        }

        [Fact]
        public void TurnOnOrOff_SetsBrightnessToZeroWhenOff()
        {
            bool isOn = true;
            var lamp = new Lamp(isOn, brightness: 70, color: new byte[] { 0, 0, 255 }, type: "Incandescent", onTime: new Time(20, 0, 4), offTime: new Time(8, 0, 7));

            lamp.TurnOnOrOff(); /// Turn off the lamp
            Assert.Equal(0, lamp.Brightness);
        }

        [Fact]
        public void TurnOnOrOff_RestoresBrightnessWhenOn()
        {
            bool isOn = false;
            var lamp = new Lamp(isOn, brightness: 60, color: new byte[] { 255, 255, 0 }, type: "CFL", onTime: new Time(17, 0,1), offTime: new Time(5, 0,4));
            
            lamp.TurnOnOrOff(); /// Turn on the lamp
            Assert.Equal(60, lamp.Brightness);
        }

        // ChangeBrightness tests
        [Fact]
        public void ChangeBrightness_UpdatesBrightness()
        {
            bool isOn = true;
            var lamp = new Lamp(isOn, brightness: 50, color: new byte[] { 0, 255, 0 }, type: "Halogen", onTime: new Time(19, 0,3), offTime: new Time(7, 0,6));
            
            byte newBrightness = 80;
            lamp.ChangeBrightness(newBrightness);
            Assert.Equal(newBrightness, lamp.Brightness);
        }

        // ChangeLampColor tests
        [Fact]
        public void ChangeLampColor_UpdateColor()
        {
            bool isOn = true;
            var initialColor = new byte[] { 52, 200, 105 };
            var lamp = new Lamp(isOn, brightness: 50, initialColor, type: "Halogen", onTime: new Time(19, 0, 3), offTime: new Time(7, 0, 6));
            var color = new byte[] { 22,235, 1 };
            lamp.ChangeLampColor(color);
            Assert.NotEqual (initialColor, lamp.Color);
        }


    }
}
