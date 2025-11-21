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
        private float CurrentTemperature { get; set; }
        private float SetpointTemperature {  get; set; }
        private float CurrentTemperatureBeforeTurnOff;
        private float SetpointTemperatureBeforeTurnOff;

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
            if (SetpointTemperature <= MaxThermostatTemperature && clicks > 0){
                Console.WriteLine("[Increased setpoint temperature from " + SetpointTemperature + "°C by " + 0.5 * clicks + "°C]");
                SetpointTemperature += 0.5f * clicks;
            }
        }

        public void DecreaseSetpointTemperature(byte clicks)
        {
            if (SetpointTemperature >= MinThermostatTemperature && clicks > 0){
                Console.WriteLine("[Decreased setpoint temperature from " + SetpointTemperature + "°C by " + 0.5 * clicks + "°C]");
                SetpointTemperature -= 0.5f * clicks;
            }
        }

        public async Task RaiseCurrentTemperature()
        {
            string[] changingTemperature = {".", "..", "..."};

            while (CurrentTemperature < SetpointTemperature + 1)
            {
                foreach (string points in changingTemperature){
                    Console.Clear();
                    Console.WriteLine("\n" + points + "\n");
                    await Task.Delay(100);
                }
                CurrentTemperature += 0.5f;
                Console.Clear();
            }
        }

        public void DisplayCurrentTemperature()
        {
            Console.WriteLine("  ----------------------------- ");
            Console.WriteLine(" | Current Temperature: " + CurrentTemperature + "°C |");
            Console.WriteLine("  ----------------------------- ");
            //Console.WriteLine("Setpoint temperature: " + SetpointTemperature + "°C");
        }
    }
}