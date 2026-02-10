using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;
using BlaisePascal.SmartHouse.Domain.Illumination;

namespace BlaisePascal.SmartHouse.Domain.UnitTests.IlluminationTests
{
    public class LedTest
    {
        //Constructor
        [Fact]
        public void Constructor_BrightnessIsGreaterThanMaxBrightness_BrightbessNotAssigned()
        {
            byte brightness = 101;
            var Led = new Led("aaa", true, brightness, [0, 0, 0]);
            Assert.NotEqual(brightness, Led.Brightness);
        }
        [Fact]
        public void Constructor_BrightnessIsLessThanMinBrightness_BrightbessIs0()
        {
            byte brightness = 0;
            var Led = new Led("aaa", true, brightness, [0, 0, 0]);
            Assert.Equal(brightness, Led.Brightness);
        }
        [Fact]
        public void Constructor_BrightnessIsAcceptable_BrightbessIsSetted()
        {
            byte brightness = 99;
            var Led = new Led("aaa", true, brightness, [0, 0, 0]);
            Assert.Equal(brightness, Led.Brightness);
        }

        // TurnOnOrOff tests
        [Fact]
        public void TurnOn_ChangesState()
        {
            bool isOn = false;
            var Led = new Led("aaa", isOn, brightness: 50, color: new byte[] { 255, 0, 0 });

            var initialState = isOn;
            var newState = Led.TurnOnOrOff();

            Assert.NotEqual(initialState, newState);
        }
        [Fact]
        public void TurnOff_ChangesState()
        {
            bool isOn = true;
            var Led = new Led("aaa", isOn, brightness: 50, color: new byte[] { 255, 0, 0 });

            var initialState = isOn;
            var newState = Led.TurnOnOrOff();

            Assert.NotEqual(initialState, newState);
        }

        [Fact]
        public void TurnOnOrOff_SetsBrightnessToZeroWhenOff()
        {
            bool isOn = true;
            var Led = new Led("aaa", isOn, brightness: 70, color: new byte[] { 0, 0, 255 });

            Led.TurnOnOrOff(); /// Turn off the led
            Assert.Equal(0, Led.Brightness);
        }

        [Fact]
        public void TurnOnOrOff_RestoresBrightnessWhenOn()
        {
            bool isOn = false;
            var Led = new Led("aaa", isOn, brightness: 60, color: new byte[] { 255, 255, 0 });

            Led.TurnOnOrOff(); /// Turn on the led
            Assert.Equal(60, Led.Brightness);
        }

        // ChangeBrightness tests
        [Fact]
        public void ChangeBrightness_UpdatesBrightness()
        {
            bool isOn = true;
            var Led = new Led("aaa", isOn, brightness: 50, color: new byte[] { 0, 255, 0 });

            byte newBrightness = 80;
            Led.ChangeBrightness(newBrightness);
            Assert.Equal(newBrightness, Led.Brightness);
        }

        // ChangeLedColor tests
        [Fact]
        public void ChangeLedColor_UpdateColor()
        {
            bool isOn = true;
            var initialColor = new byte[] { 52, 200, 105 };
            var Led = new Led("aaa", isOn, brightness: 50, initialColor);
            var color = new byte[] { 22, 235, 1 };
            Led.ChangeColor(color);
            Assert.NotEqual(initialColor, Led.Color);
        }
    }
}
