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
        private ILampRepository _lampRepository;

        public SwitchLampOnCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid lampId)
        {
            var lamp = _lampRepository.GetById(lampId);
            if (lamp != null)
            {
                if (lamp.IsOn == false)
                {
                    lamp.TurnOnOrOff();
                    lamp.LastModified = DateTime.Now;
                }
                _lampRepository.Update(lamp);
            }
        }
    }
}
