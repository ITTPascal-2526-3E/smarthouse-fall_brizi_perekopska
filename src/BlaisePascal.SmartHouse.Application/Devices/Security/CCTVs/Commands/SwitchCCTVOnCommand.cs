using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Security.CCTVs.Commands
{
    public class SwitchCCTVOnCommand
    {
        private ICCTVRepository _ledRepository;

        public SwitchCCTVOnCommand(ICCTVRepository cctvRepository)
        {
            _ledRepository = cctvRepository;
        }

        public void Execute(Guid id)
        {
            var cctv = _ledRepository.GetById(id);
            if (cctv != null)
            {
                if (cctv.TurnOnOrOff() == false)
                {
                    cctv.TurnOnOrOff();
                }
                _ledRepository.Update(cctv);
            }
        }
    }
}
