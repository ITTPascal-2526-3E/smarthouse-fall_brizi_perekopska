using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.ValueObjects
{
    public sealed class Color
    {
        public byte R {get; }
        public byte G { get; }
        public byte B { get; }

        public const byte min = 0;
        public const byte max = 255;

        public byte[] C = new byte[3] {0,0,0};
        private Color(byte r, byte g, byte b)
        {
            R = Math.Clamp(r, min, max);
            G = Math.Clamp(g, min, max);
            B = Math.Clamp(b, min, max);
            C[0] = R;
            C[1] = G;
            C[2] = B;
        }
    }
}
