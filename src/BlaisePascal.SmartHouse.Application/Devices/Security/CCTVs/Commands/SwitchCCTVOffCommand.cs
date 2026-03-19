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
        private ICCTVRepository _ledRepository;

        public SwitchCCTVOffCommand(ICCTVRepository cctvRepository)
        {
            _ledRepository = cctvRepository;
        }

        public void Execute(Guid id) 
        {
            var cctv = _ledRepository.GetById(id);
            if (cctv != null)
            {
                if (cctv.IsOn == true)
                {
                    cctv.TurnOnOrOff();
                    cctv.LastModified = DateTime.Now;
                }
                _ledRepository.Update(cctv);
            }
        }
    }
}
