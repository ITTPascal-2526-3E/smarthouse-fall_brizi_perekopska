using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Security.CCTVs.Commands
{
    public class RemoveCCTVCommand
    {
        private ICCTVRepository _ledRepository;

        public RemoveCCTVCommand(ICCTVRepository repository)
        {
            _ledRepository = repository;
        }

        public void Execute(Guid id)
        {
            _ledRepository.Remove(id);

        }
    }
}
