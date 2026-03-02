using BlaisePascal.SmartHouse.Domain.Temperature;
using BlaisePascal.SmartHouse.Domain.Temperature.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Temerature.Thermostats.Queries
{
    public class GetAllThermostatsQuery
    {
        private readonly IAirFryerRepository _thermostatRepository;

        public GetAllThermostatsQuery(IAirFryerRepository thermostatRepository)
        {
            _thermostatRepository = thermostatRepository;
        }

        public List<Thermostat> Execute()
        {
            return _thermostatRepository.GetAll();
        }
    }
}

