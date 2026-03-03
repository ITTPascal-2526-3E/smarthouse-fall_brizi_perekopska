using BlaisePascal.SmartHouse.Domain.Temperature;
using BlaisePascal.SmartHouse.Domain.Temperature.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Temerature.Thermostat.Commands
{
    public class RemoveThermostatCommand
    {
        private IThermostatRepository _thermostatRepository;

        public RemoveThermostatCommand(IThermostatRepository thermostatRepository)
        {
            _thermostatRepository = thermostatRepository;
        }

        public void Execute(Guid id)
        {
            _thermostatRepository.Remove(id);

        }
    }
}

