using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Illumination.Lamps.Queries
{
    public class GetAllLampQuery
    {
        private readonly ILampRepository _doorRepository;

        public GetAllLampQuery(ILampRepository repository)
        {
            _doorRepository = repository;
        }

        public List<Lamp> Execute()
        {
            return _doorRepository.GetAll();
        }
    }
}
