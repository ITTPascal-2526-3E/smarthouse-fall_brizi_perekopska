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
        /*
        //State
        [Fact]
        public void ChangeLamp1State_StateChangedTrue()
        {
            bool isOn1 = false;
            var firstLamp = new Lamp(isOn1, brightness: 50, color: new byte[] { 255, 0, 0 }, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5));
            var secondLamp = new EcoLamp(true, brightness: 50, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5), timer: new Time(0, 5, 0));
            var twoLampDevice = new TwoLampDevice(firstLamp, secondLamp);

            var initialState = isOn1;
            twoLampDevice.ChangeLamp1State();

            Assert.NotEqual(initialState,firstLamp.isOn1);
        }

        [Fact]
        public void ChangeLamp2State_StateChangedTrue()
        {
            bool isOn2 = false;
            var firstLamp = new Lamp(true, brightness: 50, color: new byte[] { 255, 0, 0 }, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5));
            var secondLamp = new EcoLamp(isOn2, brightness: 50, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5), timer: new Time(0, 5, 0));
            var twoLampDevice = new TwoLampDevice(firstLamp, secondLamp);

            var initialState = isOn2;
            twoLampDevice.ChangeBothLampState();

            Assert.NotEqual(initialState, secondLamp.isOn2);
        }

        [Fact]
        public void ChangeBothLampsState1_StateChangedTrue()
        {
            bool isOn2 = false;
            bool isOn1 = false;

            var firstLamp = new Lamp(isOn2, brightness: 50, color: new byte[] { 255, 0, 0 }, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5));
            var secondLamp = new EcoLamp(isOn2, brightness: 50, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5), timer: new Time(0, 5, 0));
            var twoLampDevice = new TwoLampDevice(firstLamp, secondLamp);

            var initialState1 = isOn2;
            var initialState = isOn1;
            twoLampDevice.();

            Assert.NotEqual(initialState, firstLamp.isOn1);
        }

        [Fact]
        public void ChangeBothLampsState2_StateChangedTrue()
        {
            bool isOn2 = false;
            bool isOn1 = false;

            var firstLamp = new Lamp(isOn2, brightness: 50, color: new byte[] { 255, 0, 0 }, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5));
            var secondLamp = new EcoLamp(isOn2, brightness: 50, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5), timer: new Time(0, 5, 0));
            var twoLampDevice = new TwoLampDevice(firstLamp, secondLamp);

            var initialState1 = isOn2;
            var initialState = isOn1;
            twoLampDevice.();

            Assert.NotEqual(initialState, secondLamp.isOn2);
        }

        //Brightness
        [Fact]
        public void ChangeLamp1Brightness_BrightnessChangedTrue()
        {
            byte brightness = 90;
            var firstLamp = new Lamp(true, brightness, color: new byte[] { 255, 0, 0 }, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5));
            var secondLamp = new EcoLamp(true, brightness: 50, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5), timer: new Time(0, 5, 0));
            var twoLampDevice = new TwoLampDevice(firstLamp, secondLamp);

            var initialState = brightness;
            twoLampDevice.();

            Assert.NotEqual(initialState, firstLamp.brightness);
        }

        [Fact]
        public void ChangeLamp2Brightness_BrightnessChangedTrue()
        {
            byte brightness = 50;
            var firstLamp = new Lamp(true, brightness: 50, color: new byte[] { 255, 0, 0 }, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5));
            var secondLamp = new EcoLamp(true, brightness, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5), timer: new Time(0, 5, 0));
            var twoLampDevice = new TwoLampDevice(firstLamp, secondLamp);

            var initialState = brightness;
            twoLampDevice.();

            Assert.NotEqual(initialState, secondLampLamp.brightness);
        }

        [Fact]
        public void ChangeBothLampBrightness1_BrightnessChangedTrue()
        {
            byte brightness2 = 50;
            byte brightness1 = 90;
            var firstLamp = new Lamp(true, brightness1, color: new byte[] { 255, 0, 0 }, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5));
            var secondLamp = new EcoLamp(true, brightness2, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5), timer: new Time(0, 5, 0));
            var twoLampDevice = new TwoLampDevice(firstLamp, secondLamp);

            var initialState1 = brightness2;
            var initialState = brightness1;
            twoLampDevice.();

            Assert.NotEqual(initialState, firstLamp.brightness1);
        }

        [Fact]
        public void ChangeBothLampBrightness2_BrightnessChangedTrue()
        {
            byte brightness2 = 50;
            byte brightness1 = 90;
            var firstLamp = new Lamp(true, brightness1, color: new byte[] { 255, 0, 0 }, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5));
            var secondLamp = new EcoLamp(true, brightness2, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5), timer: new Time(0, 5, 0));
            var twoLampDevice = new TwoLampDevice(firstLamp, secondLamp);

            var initialState1 = brightness2;
            var initialState = brightness1;
            twoLampDevice.();

            Assert.NotEqual(initialState, secondLamp.brightness2);
        }
        */
    }
}
