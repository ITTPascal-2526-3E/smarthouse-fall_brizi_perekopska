using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;

namespace BlaisePascal.SmartHouse.Domain.UnitTests.IlluminationTests
{
    public class EcoLampTests
    {
        // TurnOnOrOff tests
        [Fact]
        public void TurnOnOrOff_ChangesState()
        {
            bool isOn = false;
            var ecoLamp = new EcoLamp("aaa", isOn, brightness: 50, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5), timer: new Time(0, 5, 0));

            var initialState = isOn;
            var newState = ecoLamp.TurnOnOrOff();

            Assert.NotEqual(initialState, newState);
        }

        [Fact]
        public void TurnOnOrOff_SetsBrightnessToZeroWhenOff()
        {
            bool isOn = true;
            var ecoLamp = new EcoLamp("aaa", isOn, brightness: 50, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5), timer: new Time(0, 5, 0));

            ecoLamp.TurnOnOrOff(); /// Turn off the lamp
            Assert.Equal(0, ecoLamp.Brightness);
        }

        // ChangeBrightness tests
        [Fact]
        public void ChangeBrightness_UpdatesBrightness()
        {
            bool isOn = true;
            var ecoLamp = new EcoLamp("aaa", isOn, brightness: 50, type: "LED", onTime: new Time(18, 0, 2), offTime: new Time(6, 0, 5), timer: new Time(0, 5, 0));

            byte newBrightness = 40;
            ecoLamp.ChangeBrightness(newBrightness);
            Assert.Equal(newBrightness, ecoLamp.Brightness);
        }
    }
}
