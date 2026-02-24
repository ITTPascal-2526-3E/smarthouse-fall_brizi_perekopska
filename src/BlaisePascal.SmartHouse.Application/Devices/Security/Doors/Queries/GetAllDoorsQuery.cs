using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Security.Doors.Queries
{
    internal class GetAllDoorsQuery
    {
        private readonly IDoorRepository _doorRepository;

        public GetAllDoorsQuery(IDoorRepository repository)
        {
            _doorRepository = repository;
        }

        public List<Door> Execute()
        {
            return _doorRepository.GetAll();
        }
    }
}
