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
        private ILampRepository _repository;

        public SwitchLampOnCommand(ILampRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid lampId)
        {
            var lamp = _repository.GetById(lampId);
            if (lamp != null)
            {
                if (lamp.TurnOnOrOff() == true)
                {
                    lamp.TurnOnOrOff();
                }
                _repository.Update(lamp);
            }
        }
    }
}
