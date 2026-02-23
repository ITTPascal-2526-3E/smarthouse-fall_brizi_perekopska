using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Security.CCTVs.Queries
{
    public class GetAllCCTVQuery
    {
        private readonly ICCTVRepository _repository;

        public GetAllCCTVQuery(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public List<CCTV> Execute()
        {
            return _repository.GetAll();
        }
    }
}
