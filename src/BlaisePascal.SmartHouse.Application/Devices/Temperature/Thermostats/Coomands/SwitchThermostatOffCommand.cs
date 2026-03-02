using BlaisePascal.SmartHouse.Domain.Temperature;
using BlaisePascal.SmartHouse.Domain.Temperature.Repositories;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Temperature.Thermostats.Coomands
{
    public class SwitchThermostatOffCommand
    {
        private Domain.Illumination.Repositories.IThermostatRepository _thermostatRepository;

        public SwitchThermostatOffCommand(Domain.Illumination.Repositories.IThermostatRepository thermostatRepository)
        {
            _thermostatRepository = thermostatRepository;
        }

        public void Execute(Guid id)
        {
            var thermostat = _thermostatRepository.GetById(id);
            if (thermostat != null)
            {
                if (thermostat.TurnOnOrOff() == false)
                {
                    thermostat.TurnOnOrOff();
                }
                _thermostatRepository.Update(thermostat);
            }
        }
    }
}
