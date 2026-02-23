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
        private ICCTVRepository _repository;

        public RemoveCCTVCommand(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            _repository.Remove(id);

        }
    }
}
