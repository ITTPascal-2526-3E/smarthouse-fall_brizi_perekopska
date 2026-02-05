using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Interface;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Temperature;

namespace BlaisePascal.SmartHouse.Domain.Temperature
{
    public sealed class Thermostat : Device, ISwitchable
    {
        //Attributes:
        public ThermostatTemperature CurrentTemperature { get; private set; }
        public ThermostatTemperature SetpointTemperature { get; private set; }
        private ThermostatTemperature CurrentTemperatureBeforeTurnOff;
        private ThermostatTemperature SetpointTemperatureBeforeTurnOff;

        //Constructor:
        public Thermostat(Name name, bool isOn, ThermostatTemperature currentTemperature, ThermostatTemperature setpointTemperature) : base(name, isOn)
        {
            SetpointTemperature = setpointTemperature;
            CurrentTemperature = currentTemperature;
        }

        // Change the state of the thermostat, on/off
        public bool TurnOnOrOff()
        {
            if (IsOn == true)
            {
                CurrentTemperatureBeforeTurnOff = CurrentTemperature;
                CurrentTemperature = ThermostatTemperature.From(0);
                SetpointTemperatureBeforeTurnOff = SetpointTemperature;
                SetpointTemperature = ThermostatTemperature.From(0);
                IsOn = false;
            }
            else
            {
                CurrentTemperature = CurrentTemperatureBeforeTurnOff;
                SetpointTemperature = SetpointTemperatureBeforeTurnOff;
                IsOn = true;
            }
            return IsOn;
        }

        public void IncreaseSetpointTemperature(byte clicks)
        {
            if (clicks >= 0)
            {
                Console.WriteLine("[Increased setpoint temperature from " + SetpointTemperature + "°C by " + 0.5 * clicks + "°C]");
                SetpointTemperature = ThermostatTemperature.From(SetpointTemperature.Value + 0.5f * clicks);
                RaiseCurrentTemperature();
            }
            else
                throw new ArgumentException("Number of clicks must be a positive value");
        }

        public void DecreaseSetpointTemperature(byte clicks)
        {
            if (clicks > 0)
            {
                Console.WriteLine("[Decreased setpoint temperature from " + SetpointTemperature + "°C by " + 0.5 * clicks + "°C]");
                SetpointTemperature = ThermostatTemperature.From(SetpointTemperature.Value - 0.5f * clicks);
                RaiseCurrentTemperature();
            }
            else 
                throw new ArgumentException("Number of clicks must be a positive value");
        }

        public void RaiseCurrentTemperature()
        {
            if (CurrentTemperature.Value < SetpointTemperature.Value + 1)
                CurrentTemperature = ThermostatTemperature.From(SetpointTemperature.Value + 1);
        }

        public void DisplayCurrentTemperature()
        {
            if (IsOn)
            {
                Console.WriteLine("\t ----------------------------- ");
                Console.WriteLine("\t| Current Temperature: " + CurrentTemperature + "°C |");
                Console.WriteLine("\t ----------------------------- ");
            }
            else
                Console.WriteLine("Can't display current temperature if the thermostat is off");
        }
    }
}