using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Security.CCTVs.Queries
{
    internal class GetCCTVByIdQuery
    {
        private readonly ICCTVRepository _repository;

        public GetCCTVByIdQuery(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public CCTV Execute(Guid id)
        {
            return _repository.GetById(id);
        }
    }
}