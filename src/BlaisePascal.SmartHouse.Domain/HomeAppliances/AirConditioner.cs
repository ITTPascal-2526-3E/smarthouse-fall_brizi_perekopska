using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.HomeAppliances
{
    public class AirConditioner
    {
        //Attributes
        private bool IsOn;

        const float MaxTemperature = 35;
        const float MinTemperature = 16;
        private float TemperatureBeforeTurnOff;
        const float AutoTemperature = 20;
        public float Temperature { get; set; }

        const byte MaxSpeed = 100;
        const byte MinSpeed = 1;
        private byte SpeedBeforeTurnOff;
        public byte Speed {  get; set; }

        public enum AirType { Cool, Heat, Fan, auto, Dry}

        //Constructor
        public AirConditioner(bool isOn)
        {
            IsOn = isOn;
        }

        //Start the air condinioter
        public void StartAirConditioner(AirType airType, float temperature, byte speed)
        {
            try
            {
                if (Temperature >= MinTemperature && Temperature <= MaxTemperature)
                    Temperature = temperature;

                if (Temperature >= MinTemperature && Temperature <= MaxTemperature)
                    Temperature = temperature;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
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
