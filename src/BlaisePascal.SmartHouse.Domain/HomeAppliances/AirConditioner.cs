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
                if (temperature >= MinTemperature && temperature <= MaxTemperature)
                    Temperature = temperature;

                if (speed >= MinSpeed && speed <= MaxSpeed)
                    Speed = speed;
                Console.WriteLine($"Air Conditioner started with {airType} mode, temperature set to {Temperature}°C and speed set to {Speed}%");
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
