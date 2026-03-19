using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Illumination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Illumination.Lamps.Commands
{
    public class ChangeLampBrightnessCommand
    {
        private ILampRepository _lampRepository;

        public ChangeLampBrightnessCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid lampId, Byte newBrightness)
        {
            var lamp = _lampRepository.GetById(lampId);
            if (lamp != null && lamp.IsOn==true)
            {
                lamp.ChangeBrightness(newBrightness);
                lamp.LastModified = DateTime.Now;
                _lampRepository.Update(lamp);
            }
        }
    }
}
