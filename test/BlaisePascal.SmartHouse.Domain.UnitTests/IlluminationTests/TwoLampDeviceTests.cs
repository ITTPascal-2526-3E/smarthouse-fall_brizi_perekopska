using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;

namespace BlaisePascal.SmartHouse.Domain.UnitTests
{
    public class TwoLampDeviceTests
    {
        //Brightness
        [Fact]
        public void ChangeLamp1Brightness_BrightnessChangedTrue()
        {
            byte brightness = 90;
            var firstLamp = new Lamp("lamp", true, brightness, color: new byte[] { 255, 0, 0 }, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5));
            var secondLamp = new EcoLamp("ecolamp", true, brightness: 50, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5), timer: new Time(0, 5, 0));
            var twoLampDevice = new TwoLampDevice(firstLamp, secondLamp);

            var initialState = brightness;
            twoLampDevice.ChangeLamp1Brightness(70);

            Assert.NotEqual(initialState, firstLamp.Brightness);
        }

        [Fact]
        public void ChangeLamp2Brightness_BrightnessChangedTrue()
        {
            byte brightness = 50;
            var firstLamp = new Lamp("lamp", true, brightness: 50, color: new byte[] { 255, 0, 0 }, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5));
            var secondLamp = new EcoLamp("ecoLamp", true, brightness, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5), timer: new Time(0, 5, 0));
            var twoLampDevice = new TwoLampDevice(firstLamp, secondLamp);

            var initialState = brightness;
            twoLampDevice.ChangeLamp2Brightness(40);

            Assert.NotEqual(initialState, secondLamp.Brightness);
        }

        [Fact]
        public void ChangeBothLampBrightness1_BrightnessChangedTrue()
        {
            byte brightness1 = 90;
            byte brightness2 = 50;
            var firstLamp = new Lamp("lamp", true, brightness1, color: new byte[] { 255, 0, 0 }, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5));
            var secondLamp = new EcoLamp("ecoLamp", true, brightness2, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5), timer: new Time(0, 5, 0));
            var twoLampDevice = new TwoLampDevice(firstLamp, secondLamp);

            var initialState1 = brightness1;
            var initialState2 = brightness2;
            twoLampDevice.ChangeBothLampBrightness(80, 30);

            Assert.NotEqual(initialState1, firstLamp.Brightness);
        }

        [Fact]
        public void ChangeBothLampBrightness2_BrightnessChangedTrue()
        {
            byte brightness1 = 90;
            byte brightness2 = 50;
            var firstLamp = new Lamp("lamp", true, brightness1, color: new byte[] { 255, 0, 0 }, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5));
            var secondLamp = new EcoLamp("ecoLamp", true, brightness2, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5), timer: new Time(0, 5, 0));
            var twoLampDevice = new TwoLampDevice(firstLamp, secondLamp);

            var initialState1 = brightness1;
            var initialState2 = brightness2;
            twoLampDevice.ChangeBothLampBrightness(80, 30);

            Assert.NotEqual(initialState2, secondLamp.Brightness);
        }

        //Color
        [Fact]
        public void ChangeLampColor_ColorChanged()
        {
            var color = new byte[] { 255, 0, 0 };
            var firstLamp = new Lamp("lamp", true, 100, color, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5));
            var secondLamp = new EcoLamp("ecoLamp", true, 40, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5), timer: new Time(0, 5, 0));
            var twoLampDevice = new TwoLampDevice(firstLamp, secondLamp);

            var initialState = color;
            twoLampDevice.ChangeLamp1Color(colors: new byte[] { 245, 68, 120 });

            Assert.NotEqual(initialState, firstLamp.Color);
        }

    }
}
