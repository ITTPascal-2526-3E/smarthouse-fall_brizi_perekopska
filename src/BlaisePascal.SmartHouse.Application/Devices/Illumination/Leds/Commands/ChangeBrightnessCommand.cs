using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Illumination.Leds.Commands
{
    public class ChangeBrightnessCommand
    {
        private ILedRepository _ledRepository;

        public ChangeBrightnessCommand(ILedRepository repository)
        {
            _ledRepository = repository;
        }

        public void Execute(Guid lampId, Byte newBrightness)
        {
            var lamp = _ledRepository.GetById(lampId);
            if (lamp != null)
            {
                lamp.ChangeBrightness(newBrightness);
                _ledRepository.Update(lamp);
            }
        }
    }
}
