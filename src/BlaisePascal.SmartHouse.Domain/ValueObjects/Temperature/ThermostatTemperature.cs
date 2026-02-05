using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.ValueObjects.Temperature
{
    public sealed class ThermostatTemperature
    {
        public float Value { get; }
        public const float Min = 5.0f;
        public const float Max = 35.0f;
        private ThermostatTemperature(float value)
        {
            Value = Math.Clamp(value, Min, Max);
        }
        public static ThermostatTemperature From(float value) => new ThermostatTemperature(value);
    }
}
