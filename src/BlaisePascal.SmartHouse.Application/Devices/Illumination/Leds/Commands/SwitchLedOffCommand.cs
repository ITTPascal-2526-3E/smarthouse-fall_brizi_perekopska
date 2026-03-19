using BlaisePascal.SmartHouse.Domain.Illumination;
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

        public void Execute(Guid ledId)
        {
            var led = _ledRepository.GetById(ledId);
            if (led != null)
            {
                if (led.IsOn == true)
                {
                    
                    led.TurnOnOrOff();
                    led.LastModified = DateTime.Now;
                }
                _ledRepository.Update(led);
            }
        }
    }
}
