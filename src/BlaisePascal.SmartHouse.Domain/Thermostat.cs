using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Thermostat
    {
        //Attributes:
        private bool IsOn;

        const float MaxThermostateTemperature = 35;
        const float MinThermostateTemperature = 5;
        private float CurrentTemperature { get; set; }
        private float SetpointTemperature {  get; set; }
        private float CurrentTemperatureBeforeTurnOff;
        private float SetpointTemperatureBeforeTurnOff;

        //Constructor:
        public Thermostat(bool isOn, float currentTemperature, float setpointTemperature)
        {
            IsOn = isOn;
            if (setpointTemperature >= MinThermostateTemperature && setpointTemperature <= MaxThermostateTemperature)
                SetpointTemperature = setpointTemperature;
            if (currentTemperature <= MaxThermostateTemperature)
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
            if (SetpointTemperature <= MaxThermostateTemperature && clicks > 0)
                SetpointTemperature += 0.5f * clicks;
        }

        public void DecreaseSetpointTemperature(byte clicks)
        {
            if (SetpointTemperature >= MinThermostateTemperature && clicks > 0)
                SetpointTemperature -= 0.5f * clicks;
        }

        public async Task ModifyCurrentTemperature()
        {
            while (SetpointTemperature != CurrentTemperature)
            {
                Console.WriteLine("Current Temperature += 0.5");
                await Task.Delay(1000);
                if (SetpointTemperature < CurrentTemperature)
                    CurrentTemperature -= 0.5f;
                if (SetpointTemperature > CurrentTemperature)
                    CurrentTemperature += 0.5f;
            }
        }

        public void DisplayCurrentTemperature()
        {
            Console.WriteLine("Current Temperature: " + CurrentTemperature + "°C");
            Console.WriteLine("Setpoint temperature: " + SetpointTemperature + "°C");
        }
    }
}