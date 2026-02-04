using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.ValueObjects
{
    public sealed class EcoBrightness
    {
        public byte Value { get; }

        public const int Min = 1;
        public const int Max = 66;

        private EcoBrightness(int value)
        {
            Value = Convert.ToByte(Math.Clamp(value, Min, Max));
        }

        public static EcoBrightness From(int value) => new EcoBrightness(value);
    }
}
