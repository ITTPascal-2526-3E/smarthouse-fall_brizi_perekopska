using BlaisePascal.SmartHouse.Domain.Interface;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Temperature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.HomeAppliances
{
    public sealed class AirConditioner : Device, ISwitchable
    {
        //Attributes
        public ACTemperature TemperatureBeforeTurnOff { get; private set; }
        public ACTemperature Temperature { get; private set; }

        const byte MaxSpeed = 100;
        const byte MinSpeed = 1;
        public byte SpeedBeforeTurnOff { get; private set; }
        public byte Speed {  get; private set; }

        public string AirType { get; private set; }
        public enum AirTypeList { Cool, Heat, Fan, auto, Dry }

        //Constructor
        public AirConditioner(Name name, bool isOn) : base(name, isOn)
        {
            IsOn = isOn;
        }

        //Start the air condinioter
        public void StartAirConditioner(AirTypeList airType, ACTemperature temperature, byte speed)
        {
            if (!IsOn)
                throw new Exception("Air Conditioner is off");

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
                Temperature = ACTemperature.From(ACTemperature.Default);
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
