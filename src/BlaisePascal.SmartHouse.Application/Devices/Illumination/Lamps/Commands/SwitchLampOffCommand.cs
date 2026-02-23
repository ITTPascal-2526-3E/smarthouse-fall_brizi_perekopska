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
        private ILampRepository _repository;

        public SwitchLampOffCommand(ILampRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid lampId)
        {
            var lamp = _repository.GetById(lampId);
            if (lamp != null)
            {
                if (lamp.TurnOnOrOff() == false)
                {
                    lamp.TurnOnOrOff();
                }
                _repository.Update(lamp);
            }
        }
    }
}
