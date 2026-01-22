using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Interface
{
    public interface IIllumination: ISwitchable
    {
        void ChangeBrightness(byte newBrightness);
    }
}
