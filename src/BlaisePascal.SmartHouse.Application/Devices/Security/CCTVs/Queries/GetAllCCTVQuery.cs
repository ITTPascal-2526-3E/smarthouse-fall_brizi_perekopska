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
        private readonly ICCTVRepository _ledRepository;

        public GetAllCCTVQuery(ICCTVRepository repository)
        {
            _ledRepository = repository;
        }

        public List<CCTV> Execute()
        {
            return _ledRepository.GetAll();
        }
    }
}
