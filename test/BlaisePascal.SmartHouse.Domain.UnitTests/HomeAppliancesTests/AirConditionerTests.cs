using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.HomeAppliances;

namespace BlaisePascal.SmartHouse.Domain.UnitTests.HomeAppliancesTests
{
    public class AirConditionerTests
    {
        // Constructor test
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            var airConditioner = new AirConditioner(isOn: true);
            Assert.True(airConditioner.IsOn);
        }

        //StartAirConditioner tests
        [Fact]
        public void StartAirConditioner_SetsPropertiesCorrectly()
        {
            var airConditioner = new AirConditioner(isOn: true);
            airConditioner.StartAirConditioner(AirConditioner.AirTypeList.Heat, 25, 60);
            Assert.Equal(AirConditioner.AirTypeList.Heat.ToString(), airConditioner.AirType);
            Assert.Equal(25, airConditioner.Temperature);
            Assert.Equal(60, airConditioner.Speed);
        }

        [Fact]
        public void StartAirConditioner_InvalidTemperature_DoesNotChangeTemperature()
        {
            var airConditioner = new AirConditioner(isOn: false);
            Assert.Throws<Exception>(() => airConditioner.StartAirConditioner(AirConditioner.AirTypeList.Fan, 10, 110));
        }

        [Fact]
        public void StartAirConditioner_InvalidSpeed_DoesNotChangeSpeed()
        {
            var airConditioner = new AirConditioner(isOn: false);
            Assert.Throws<Exception>(() => airConditioner.StartAirConditioner(AirConditioner.AirTypeList.Fan, 20, 150)); // Invalid speed
        }

        [Fact]
        public void StartAirConditioner_WhenOff_ThrowsException()
        {
            var airConditioner = new AirConditioner(isOn: false);
            var exception = Assert.Throws<Exception>(() => airConditioner.StartAirConditioner(AirConditioner.AirTypeList.Cool, 22, 50));
            Assert.Equal("Air Conditioner is off", exception.Message);
        }

        // TurnOnOrOff tests
        [Fact]
        public void TurnOnOrOff_TurnsOffAirConditioner_SavesPreviousSettings()
        {
            var airConditioner = new AirConditioner(isOn: true);
            airConditioner.StartAirConditioner(AirConditioner.AirTypeList.Cool, 22, 50);
            var newState = airConditioner.TurnOnOrOff();
            Assert.False(newState);
            Assert.Equal(0, airConditioner.Speed);
            Assert.Equal(20, airConditioner.Temperature);
            Assert.Equal(50, airConditioner.SpeedBeforeTurnOff);
            Assert.Equal(22, airConditioner.TemperatureBeforeTurnOff);
        }

        [Fact]
        public void TurnOnOrOff_ToggleMultipleTimes_MaintainsCorrectState()
        {
            var airConditioner = new AirConditioner(isOn: true);
            airConditioner.StartAirConditioner(AirConditioner.AirTypeList.Dry, 26, 80);
            // Turn off
            airConditioner.TurnOnOrOff();
            Assert.False(airConditioner.IsOn);
            // Turn on
            airConditioner.TurnOnOrOff();
            Assert.True(airConditioner.IsOn);
            Assert.Equal(80, airConditioner.Speed);
            Assert.Equal(26, airConditioner.Temperature);
            // Turn off again
            airConditioner.TurnOnOrOff();
            Assert.False(airConditioner.IsOn);
            // Turn on again
            airConditioner.TurnOnOrOff();
            Assert.True(airConditioner.IsOn);
            Assert.Equal(80, airConditioner.Speed);
            Assert.Equal(26, airConditioner.Temperature);
        }
    }
}
