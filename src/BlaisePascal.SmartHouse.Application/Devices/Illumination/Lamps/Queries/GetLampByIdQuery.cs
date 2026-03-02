using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.Illumination.Lamps.Queries
{
    public class GetLampByIdQuery
    {
        private readonly IThermostatRepository _doorRepository;

        public GetLampByIdQuery(IThermostatRepository repository)
        {
            _doorRepository = repository;
        }

        public Lamp Execute(Guid id) 
        { 
            return _doorRepository.GetById(id);
        }
    }
}
