using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Security.CCTVs.Commands
{
    public class AddCCTVCommand
    {
        private ICCTVRepository _repository;

        public AddCCTVCommand(ICCTVRepository cctvRepository)
        {
            _repository = cctvRepository;
        }

        public void Execute(Name name)
        {
            var cctv = new CCTV(name);
            _repository.Add(cctv);

        }
    }
}
