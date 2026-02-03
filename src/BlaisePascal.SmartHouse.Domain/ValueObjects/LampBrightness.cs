using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.ValueObjects
{
    public sealed class LampBrightness
    {
        public byte Value { get; }

        public const int Min = 0;
        public const int Max = 100;

        private LampBrightness(int value)
        {
            Value = Convert.ToByte(Math.Clamp(value, Min, Max));
        }

        public static LampBrightness From(int value) => new LampBrightness(value);
    }
}
