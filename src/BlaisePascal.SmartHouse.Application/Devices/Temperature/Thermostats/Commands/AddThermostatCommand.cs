using BlaisePascal.SmartHouse.Domain.Temperature;
using BlaisePascal.SmartHouse.Domain.Temperature.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Temerature.Thrmostats.Commands
{
    public class AddThermostatCommand
    {
        private IThermostatRepository _thermostatRepository;

        public AddThermostatCommand(IThermostatRepository thermostatRepository)
        {
            _thermostatRepository = thermostatRepository;
        }

        public void Execute(Guid id)
        {
            var thermostat = new Thermostat(id);
            _thermostatRepository.Add(thermostat);

        }
    }
}

