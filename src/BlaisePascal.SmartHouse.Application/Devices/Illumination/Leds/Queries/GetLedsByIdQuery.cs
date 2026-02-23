using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Illumination.Leds.Queries
{
    public class GetLedsByIdQuery
    {
        private readonly ILedRepository _repository;

        public GetLedsByIdQuery(ILedRepository repository)
        {
            _repository = repository;
        }

        public Led Execute(Guid id)
        {
            return _repository.GetById(id);
        }
    }
}
