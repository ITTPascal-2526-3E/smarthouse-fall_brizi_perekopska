using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.ValueObjects
{
    public sealed class Speed
    {
        public byte Value { get; }
        public const byte Min = 1;
        public const byte Max = 100;
        private Speed(byte value)
        {
            Value = Math.Clamp(value, Min, Max);
        }
        public static Speed From(byte value) => new Speed(value);
    }
}
