using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Temperature;

namespace BlaisePascal.SmartHouse.Domain.UnitTests.TemperatureTests
{
    public class ThermostatTests
    {
        //TurnOnOrOff Tests
        [Fact]
        public void Thermostat_TurnOnOrOff_ChangesStateToOnIfOffAndToOffIfOn()
        {
            bool isOn = false;
            var thermostat = new Thermostat(isOn, currentTemperature: 20.0f, setpointTemperature: 22.0f);

            var initialState = isOn;
            var newState = thermostat.TurnOnOrOff();
            Assert.NotEqual(initialState, newState);
        }

        [Fact]
        public void Thermostat_TurnOnOrOff_SetsCurrentAndSetpointTemperratureToZero()
        {
            var thermostat = new Thermostat(isOn: true, currentTemperature: 20.0f, setpointTemperature: 22.0f);
            thermostat.TurnOnOrOff(); /// Turn off

            Assert.Equal(0, thermostat.CurrentTemperature);
            Assert.Equal(0, thermostat.SetpointTemperature);
        }

        [Fact]
        public void Thermostat_TurnOnOrOff_RestoresPreviousTemperaturesWhenTurnedOnAgain()
        {
            var thermostat = new Thermostat(isOn: true, currentTemperature: 20.0f, setpointTemperature: 22.0f);
            thermostat.TurnOnOrOff(); /// Turn off
            thermostat.TurnOnOrOff(); /// Turn on
            Assert.Equal(20.0f, thermostat.CurrentTemperature);
            Assert.Equal(22.0f, thermostat.SetpointTemperature);
        }
        // IncreaseSetpointTemperature Tests
        [Fact]
        public void Thermostat_IncreaseSetpointTemperature_IncreasesSetpointBy2C()
        {
            var thermostat = new Thermostat(isOn: true, currentTemperature: 20.0f, setpointTemperature: 22.0f);

            byte clicks = 4; /// Increase by 2.0°C
            thermostat.IncreaseSetpointTemperature(clicks);
            Assert.Equal(24.0f, thermostat.SetpointTemperature);
        }

        [Fact]
        public void Thermostat_IncreaseSetpointTemperature_DoesNotExceedMaxTemperature()
        {
            var thermostat = new Thermostat(isOn: true, currentTemperature: 30.0f, setpointTemperature: 34.0f);
            byte clicks = 4; /// Attempt to increase by 2.0°C, exceeding max
            thermostat.IncreaseSetpointTemperature(clicks);
            Assert.Equal(35.0f, thermostat.SetpointTemperature); /// Max is 35°C
        }

        [Fact]
        public void Thermostat_IncreaseSetpointTemperature_NoChangeWhenClicksIsZero()
        {
            var thermostat = new Thermostat(isOn: true, currentTemperature: 20.0f, setpointTemperature: 22.0f);
            byte clicks = 0; /// No increase
            thermostat.IncreaseSetpointTemperature(clicks);
            Assert.Equal(22.0f, thermostat.SetpointTemperature); // Should remain unchanged
        }

        // DecreaseSetpointTemperature Tests
        [Fact]
        public void Thermostat_DecreaseSetpointTemperature_DecreasesSetpointBy1C()
        {
            var thermostat = new Thermostat(isOn: true, currentTemperature: 20.0f, setpointTemperature: 22.0f);

            byte clicks = 2; /// Decrease by 1.0°C
            thermostat.DecreaseSetpointTemperature(clicks);
            Assert.Equal(21.0f, thermostat.SetpointTemperature);
        }

        [Fact]
        public void Thermostat_DecreaseSetpointTemperature_DoesNotGoBelowMinTemperature()
        {
            var thermostat = new Thermostat(isOn: true, currentTemperature: 10.0f, setpointTemperature: 6.0f);
            byte clicks = 4; /// Attempt to decrease by 2.0°C, going below min
            thermostat.DecreaseSetpointTemperature(clicks);
            Assert.Equal(5.0f, thermostat.SetpointTemperature); /// Min is 5°C
        }

        [Fact]
        public void Thermostat_DecreaseSetpointTemperature_NoChangeWhenClicksIsZero()
        {
            var thermostat = new Thermostat(isOn: true, currentTemperature: 20.0f, setpointTemperature: 22.0f);
            byte clicks = 0; /// No decrease
            thermostat.DecreaseSetpointTemperature(clicks);
            Assert.Equal(22.0f, thermostat.SetpointTemperature); /// Should remain unchanged
        }

        // RaiseCurrentTemperature Tests
        [Fact]
        public async Task Thermostat_RaiseCurrentTemperature_AdjustsCurrentTowardsSetpointPlusOne()
        {
            var thermostat = new Thermostat(isOn: true, currentTemperature: 20.0f, setpointTemperature: 25.0f);
            thermostat.RaiseCurrentTemperature();
            Assert.Equal(26.0f, thermostat.CurrentTemperature);
        }

        [Fact]
        public async Task Thermostat_RaiseCurrentTemperature_DoesNotExceedMaxTemperature()
        {
            var thermostat = new Thermostat(isOn: true, currentTemperature: 34.0f, setpointTemperature: 35.0f);
            thermostat.RaiseCurrentTemperature();
            Assert.Equal(35.0f, thermostat.CurrentTemperature); /// Max is 35°C
        }
    }
}
