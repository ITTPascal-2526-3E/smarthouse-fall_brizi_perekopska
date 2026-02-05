using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.ValueObjects.Temperature
{
    public sealed class ACTemperature
    {
        public float Value { get; }
        public const float Default = 20;
        public const float Min = 16;
        public const float Max = 35;
        private ACTemperature(float value)
        {
            Value = Math.Clamp(value, Min, Max);
        }
        public static ACTemperature From(float value) => new ACTemperature(value);
    }
}
