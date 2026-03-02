using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Security.Doors.Queries
{
    public class GetAllDoorsQuery
    {
        private readonly IDoorRepository _doorRepository;

        public GetAllDoorsQuery(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public List<Door> Execute()
        {
            return _doorRepository.GetAll();
        }
    }
}
