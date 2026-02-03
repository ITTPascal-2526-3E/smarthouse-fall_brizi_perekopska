using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.ValueObjects
{
    public sealed class Brightness
    {
        public int Value { get; private set; }

        public const int Min = 0;
        public const int Max = 100;

        private Brightness(int value)
        {
            Value = value;
        }
    }
}
