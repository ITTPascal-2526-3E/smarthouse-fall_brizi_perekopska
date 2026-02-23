using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Illumination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Illumination.Leds.Commands
{
    public class AddLedCommands
    {
        private ILedRepository _ledRepository;

        public AddLedCommands(ILedRepository ledRepository)
        {
            _ledRepository = ledRepository;
        }

        public void Execute(Name name)
        {
            Led led = new Led(name);
            _ledRepository.Add(led);
        }
    }
}
