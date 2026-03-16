using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Illumination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Illumination.Lamps.Commands
{
    public class ChangeColorCommand
    {
        private ILampRepository _lampRepository;

        public ChangeColorCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid lampId, Byte r, Byte g, Byte b)
        {
            var lamp = _lampRepository.GetById(lampId);
            if (lamp != null)
            {
                Color color=Color.From(r,g,b);
                lamp.ChangeLampColor(color);
                _lampRepository.Update(lamp);
            }
        }
    }
}
