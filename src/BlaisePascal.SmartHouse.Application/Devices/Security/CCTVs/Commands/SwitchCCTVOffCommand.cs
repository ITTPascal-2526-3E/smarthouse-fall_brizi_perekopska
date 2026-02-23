using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Security.CCTVs.Commands
{
    public class SwitchCCTVOffCommand
    {
        private ICCTVRepository _repository;

        public SwitchCCTVOffCommand(ICCTVRepository cctvRepository)
        {
            _repository = cctvRepository;
        }

        public void Execute(Guid id) 
        {
            var cctv = _repository.GetById(id);
            if (cctv != null)
            {
                if (cctv.TurnOnOrOff() == true)
                {
                    cctv.TurnOnOrOff();
                }
                _repository.Update(cctv);
            }
        }
    }
}
