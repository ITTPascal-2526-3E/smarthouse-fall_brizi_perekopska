using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Illumination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Illumination.Lamps.Commands
{
    public class ChangeBrightnessCommand
    {
        private ILampRepository _lampRepository;

        public ChangeBrightnessCommand(ILampRepository repository)
        {
            _lampRepository = repository;
        }

        public void Execute(Guid lampId, Byte newBrightness)
        {
            var lamp = _lampRepository.GetById(lampId);
            if (lamp != null)
            {
                lamp.ChangeBrightness(newBrightness);
                _lampRepository.Update(lamp);
            }
        }
    }
}
