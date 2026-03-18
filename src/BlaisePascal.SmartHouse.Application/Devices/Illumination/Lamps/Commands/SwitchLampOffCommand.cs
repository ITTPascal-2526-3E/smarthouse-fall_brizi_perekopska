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
        private ILampRepository _lampRepository;

        public SwitchLampOffCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid lampId)
        {
            var lamp = _lampRepository.GetById(lampId);
            if (lamp != null)
            {
                if (lamp.IsOn == true)
                {
                    lamp.TurnOnOrOff();
                    lamp.ChangeBrightness(0);
                    lamp.LastModified = DateTime.Now;
                }
                _lampRepository.Update(lamp);
            }
        }
    }
}
