using BlaisePascal.SmartHouse.Domain.Temperature;
using BlaisePascal.SmartHouse.Domain.Temperature.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Temperature.Thermostats.Queries
{
    public class GetThermostatByIdQuery
    {
        private readonly IAirFryerRepository _thermostatRepository;

        public GetThermostatByIdQuery(IAirFryerRepository thermostatRepository)
        {
            _thermostatRepository = thermostatRepository;
        }

        public Thermostat Execute(Guid id)
        {
            return _thermostatRepository.GetById(id);
        }
    }
}
