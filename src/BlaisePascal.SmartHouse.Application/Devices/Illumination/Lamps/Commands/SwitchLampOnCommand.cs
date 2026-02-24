using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Illumination.Lamps.Commands
{
    public class SwitchLampOnCommand
    {
        private ILampRepository _doorRepository;

        public SwitchLampOnCommand(ILampRepository repository)
        {
            _doorRepository = repository;
        }

        public void Execute(Guid lampId)
        {
            var lamp = _doorRepository.GetById(lampId);
            if (lamp != null)
            {
                if (lamp.TurnOnOrOff() == true)
                {
                    lamp.TurnOnOrOff();
                }
                _doorRepository.Update(lamp);
            }
        }
    }
}
