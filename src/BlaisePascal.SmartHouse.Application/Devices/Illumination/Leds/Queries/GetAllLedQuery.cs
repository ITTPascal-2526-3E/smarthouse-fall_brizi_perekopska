using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Illumination.Leds.Queries
{
    public class GetAllLedQuery
    {
        private readonly ILedRepository _ledRepository;

        public GetAllLedQuery(ILedRepository repository)
        {
            _ledRepository = repository;
        }

        public List<Led> Execute()
        {
            return _ledRepository.GetAll();
        }
    }
}
