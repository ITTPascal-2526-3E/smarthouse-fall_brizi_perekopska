using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.ValueObjects.Time
{
    public sealed class Minutes
    {
        public byte Value { get; }

        public const int Min = 0;
        public const int Max = 59;

        private Minutes(int value)
        {
            Value = Convert.ToByte(Math.Clamp(value, Min, Max));
        }

        public static Minutes From(int value) => new Minutes(value);
    }
}
