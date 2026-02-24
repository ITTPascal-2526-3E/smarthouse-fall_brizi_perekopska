using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.Illumination.Lamps.Commands
{
    public class SwitchLampOffCommand
    {
        private ILampRepository _doorRepository;

        public SwitchLampOffCommand(ILampRepository repository)
        {
            _doorRepository = repository;
        }

        public void Execute(Guid lampId)
        {
            var lamp = _doorRepository.GetById(lampId);
            if (lamp != null)
            {
                if (lamp.TurnOnOrOff() == false)
                {
                    lamp.TurnOnOrOff();
                }
                _doorRepository.Update(lamp);
            }
        }
    }
}
