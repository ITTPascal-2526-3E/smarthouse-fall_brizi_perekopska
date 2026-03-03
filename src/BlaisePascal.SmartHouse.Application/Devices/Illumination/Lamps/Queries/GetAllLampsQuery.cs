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
        private readonly ILampRepository _lampRepository;

        public GetAllLampQuery(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public List<Lamp> Execute()
        {
            return _lampRepository.GetAll();
        }
    }
}
