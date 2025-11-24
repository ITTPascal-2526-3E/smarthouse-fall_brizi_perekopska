using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Temperature
{
    public class Thermostat
    {
        //Attributes:
        private bool IsOn;

        const float MaxThermostatTemperature = 35;
        const float MinThermostatTemperature = 5;
        public float CurrentTemperature { get; private set; }
        public float SetpointTemperature { get; private set; }
        public float CurrentTemperatureBeforeTurnOff { get; private set; }
        public float SetpointTemperatureBeforeTurnOff { get; private set; }

        //Constructor:
        public Thermostat(bool isOn, float currentTemperature, float setpointTemperature)
        {
            IsOn = isOn;
            if (setpointTemperature >= MinThermostatTemperature && setpointTemperature <= MaxThermostatTemperature)
                SetpointTemperature = setpointTemperature;
            if (currentTemperature <= MaxThermostatTemperature)
                CurrentTemperature = currentTemperature;
        }

        // Change the state of the thermostat, on/off
        public bool TurnOnOrOff()
        {
            if (IsOn == true)
            {
                CurrentTemperatureBeforeTurnOff = CurrentTemperature;
                SetpointTemperatureBeforeTurnOff = SetpointTemperature;
                CurrentTemperature = 0;
                SetpointTemperature = 0;
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
            if (SetpointTemperature < MaxThermostatTemperature && clicks > 0)
            {
                Console.WriteLine("[Increased setpoint temperature from " + SetpointTemperature + "°C by " + 0.5 * clicks + "°C]");
                SetpointTemperature += 0.5f * clicks;
                if (SetpointTemperature > MaxThermostatTemperature)
                    SetpointTemperature = MaxThermostatTemperature;
                RaiseCurrentTemperature();
            }
            else
                Console.WriteLine("Setpoint temperature is already at maximum value");
        }

        public void DecreaseSetpointTemperature(byte clicks)
        {
            if (SetpointTemperature > MinThermostatTemperature && clicks > 0)
            {
                Console.WriteLine("[Decreased setpoint temperature from " + SetpointTemperature + "°C by " + 0.5 * clicks + "°C]");
                SetpointTemperature -= 0.5f * clicks;
                if (SetpointTemperature < MinThermostatTemperature)
                    SetpointTemperature = MinThermostatTemperature;
                RaiseCurrentTemperature();
            }
            else 
                Console.WriteLine("Setpoint temperature is already at minimum value");
        }

        public async Task RaiseCurrentTemperature()
        {
            //string[] changingTemperature = { ".", "..", "..." };

            while (CurrentTemperature < SetpointTemperature + 1)
            {
                /*foreach (string points in changingTemperature) // "Animation effect"
                {
                    Console.Clear();
                    Console.WriteLine("\n" + points + "\n");
                    await Task.Delay(100);
                }*/
                CurrentTemperature += 0.5f;
                if(CurrentTemperature == 35.0f)
                    return;
                Console.Clear();
            }
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
            {
                Console.WriteLine("Cante display current temperature if thermostat is turned off");
            }
        }
    }
}