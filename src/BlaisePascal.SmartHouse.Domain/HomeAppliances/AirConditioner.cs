using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Interface;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;

namespace BlaisePascal.SmartHouse.Domain.HomeAppliances
{
    public sealed class AirConditioner : Device,ISwitchable
    {
        //Attributes
        const float MaxTemperature = 35;
        const float MinTemperature = 16;
        public float TemperatureBeforeTurnOff { get; private set; }
        const float AutoTemperature = 20;
        public float Temperature { get; private set; }

        const byte MaxSpeed = 100;
        const byte MinSpeed = 1;
        public byte SpeedBeforeTurnOff { get; private set; }
        public byte Speed {  get; private set; }

        public string AirType { get; private set; }
        public enum AirTypeList { Cool, Heat, Fan, auto, Dry }

        //Constructor
        public AirConditioner(string name, bool isOn) : base(name, isOn)
        {
            IsOn = isOn;
        }

        //Start the air condinioter
        public void StartAirConditioner(AirTypeList airType, float temperature, byte speed)
        {
            if (!IsOn)
                throw new Exception("Air Conditioner is off");
            if (temperature < MinTemperature || temperature > MaxTemperature)
                throw new Exception($"Temperature must be between {MinTemperature}°C and {MaxTemperature}°C");

            if (speed < MinSpeed || speed > MaxSpeed)
                throw new Exception($"Speed must be between {MinSpeed}% and {MaxSpeed}%");

            Temperature = temperature;
            Speed = speed;
            IsOn = true;
            AirType = airType.ToString();
        }

        // Change the state of the air conditioner, on or off
        public bool TurnOnOrOff()
        {
            if (IsOn == true)
            {
                SpeedBeforeTurnOff = Speed;
                Speed = 0;
                TemperatureBeforeTurnOff = Temperature;
                Temperature = AutoTemperature;
                IsOn = false;
                Console.WriteLine("Air Conditioner turned off");
            }
            else
            {
                Temperature = TemperatureBeforeTurnOff;
                Speed = SpeedBeforeTurnOff;
                IsOn = true;
                Console.WriteLine("Air Conditioner turned on");
            }
            return IsOn;
        }
    }
}
