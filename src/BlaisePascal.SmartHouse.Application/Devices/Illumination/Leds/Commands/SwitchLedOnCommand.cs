using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Illumination.Leds.Commands
{
    public class SwitchLedOnCommand
    {
        private ILedRepository _repository;

        public SwitchLedOnCommand(ILedRepository repository)
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
