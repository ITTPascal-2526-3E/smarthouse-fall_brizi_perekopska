using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Illumination;

namespace BlaisePascal.SmartHouse.Application.Devices.Illumination.Lamps.Commands
{
    public class AddLampCommands
    {
        private ILampRepository _lampRepository;

        public AddLampCommands(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(string name, string imageUrl)
        {
            var lamp = new Lamp();
            _lampRepository.Add(lamp);

        }
    }
}
