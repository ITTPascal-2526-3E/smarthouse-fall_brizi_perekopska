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
        private readonly ILedRepository _repository;

        public GetAllLedQuery(ILedRepository repository)
        {
            _repository = repository;
        }

        public List<Led> Execute()
        {
            return _repository.GetAll();
        }
    }
}
