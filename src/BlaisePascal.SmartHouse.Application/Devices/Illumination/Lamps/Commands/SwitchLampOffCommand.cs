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
        private IThermostatRepository _lampRepository;

        public SwitchLampOffCommand(IThermostatRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid lampId)
        {
            var lamp = _lampRepository.GetById(lampId);
            if (lamp != null)
            {
                if (lamp.TurnOnOrOff() == false)
                {
                    lamp.TurnOnOrOff();
                }
                _lampRepository.Update(lamp);
            }
        }
    }
}
