using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Illumination.Leds.Commands
{
    public class SwitchLedOffCommand
    {
        private ILedRepository _ledRepository;

        public SwitchLedOffCommand(ILedRepository repository)
        {
            _ledRepository = repository;
        }

        public void Execute(Guid lampId)
        {
            var lamp = _ledRepository.GetById(lampId);
            if (lamp != null)
            {
                if (lamp.TurnOnOrOff() == false)
                {
                    lamp.TurnOnOrOff();
                }
                _ledRepository.Update(lamp);
            }
        }
    }
}
