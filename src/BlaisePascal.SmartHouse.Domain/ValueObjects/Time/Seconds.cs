using BlaisePascal.SmartHouse.Domain.ValueObjects.Illumination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.ValueObjects.Time
{
    public sealed class Seconds
    {
        public byte Value { get; }

        public const int Min = 0;
        public const int Max = 59;

        private Seconds(int value)
        {
            Value = Convert.ToByte(Math.Clamp(value, Min, Max));
        }

        public static Seconds From(int value) => new Seconds(value);
    }
}
