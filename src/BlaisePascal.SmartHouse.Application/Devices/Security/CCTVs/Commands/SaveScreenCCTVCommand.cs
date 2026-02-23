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
        private readonly ICCTVRepository _repository;

        public SaveScreenCCTVCommand(ICCTVRepository repository)
        {
            _repository = repository;
        }
        public void Execute(Guid cctvId)
        {
            var cctv = _repository.GetById(cctvId);
            if (cctv != null)
            {
                cctv.Save();
                _repository.Update(cctv);
            }
        }
    }
}
