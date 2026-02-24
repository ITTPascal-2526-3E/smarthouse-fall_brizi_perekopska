using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Security.Doors.Queries
{
    internal class GetDoorByIdQuery
    {
        private readonly IDoorRepository _doorRepository;

        public GetDoorByIdQuery(IDoorRepository repository)
        {
            _doorRepository = repository;
        }

        public Door Execute(Guid id)
        {
            return _doorRepository.GetById(id);
        }
    }
}
