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
        private IThermostatRepository _lampRepository;

        public SwitchLampOnCommand(IThermostatRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid lampId)
        {
            var lamp = _lampRepository.GetById(lampId);
            if (lamp != null)
            {
                if (lamp.TurnOnOrOff() == true)
                {
                    lamp.TurnOnOrOff();
                }
                _lampRepository.Update(lamp);
            }
        }
    }
}
