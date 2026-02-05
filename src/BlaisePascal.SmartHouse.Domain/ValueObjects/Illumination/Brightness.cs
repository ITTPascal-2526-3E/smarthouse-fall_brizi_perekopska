using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.ValueObjects.Illumination
{
    public sealed class Brightness
    {
        public byte Value { get; }

        public const int Min = 1;
        public const int Max = 100;

        private Brightness(int value)
        {
            Value = Convert.ToByte(Math.Clamp(value, Min, Max));
        }

        public static Brightness From(int value) => new Brightness(value);
    }
}
