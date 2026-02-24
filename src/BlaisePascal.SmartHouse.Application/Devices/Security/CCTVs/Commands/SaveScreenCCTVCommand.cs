using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Security.CCTVs.Commands
{
    public class SaveScreenCCTVCommand
    {
        private readonly ICCTVRepository _ledRepository;

        public SaveScreenCCTVCommand(ICCTVRepository repository)
        {
            _ledRepository = repository;
        }
        public void Execute(Guid cctvId)
        {
            var cctv = _ledRepository.GetById(cctvId);
            if (cctv != null)
            {
                cctv.Save();
                _ledRepository.Update(cctv);
            }
        }
    }
}
