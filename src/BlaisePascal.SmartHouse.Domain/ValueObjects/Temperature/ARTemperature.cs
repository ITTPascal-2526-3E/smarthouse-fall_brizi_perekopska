using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.ValueObjects.Temperature
{
    public sealed class ARTemperature
    {
        public float Value { get; }
        public const float Default = 20;
        public const float Min = 80;
        public const float Max = 200;
        private ARTemperature(float value)
        {
            Value = Math.Clamp(value, Min, Max);
        }
        public static ARTemperature From(float value) => new ARTemperature(value);
    }
}
