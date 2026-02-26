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
        public Speed SpeedBeforeTurnOff { get; private set; }
        public Speed Speed {  get; private set; }

        public string AirType { get; private set; }
        public enum AirTypeList { Cool, Heat, Fan, auto, Dry }

        //Constructor
        public AirConditioner(Name name, bool isOn) : base(name, isOn)
        {
            IsOn = isOn;
        }
        public AirConditioner(Name name) : base(name, AssigmentIsOn()){}
        private static bool AssigmentIsOn()
        {
            return false;
        }

        //Start the air condinioter
        public void StartAirConditioner(AirTypeList airType, ACTemperature temperature, Speed speed)
        {
            if (!IsOn)
                throw new Exception("Air Conditioner is off");
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
                Speed = Speed.From(0);
                TemperatureBeforeTurnOff = Temperature;
                Temperature = ACTemperature.From(ACTemperature.Default);
                IsOn = false;
            }
            else
            {
                Temperature = TemperatureBeforeTurnOff;
                Speed = SpeedBeforeTurnOff;
                IsOn = true;
            }
            return IsOn;
        }
    }
}
