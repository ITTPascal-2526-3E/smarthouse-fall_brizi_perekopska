using BlaisePascal.SmartHouse.Domain.Temperature.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Temperature.Thermostats.Commands
{
    public class DecreaseSetpointTemperatureCommand
    {
        private IThermostatRepository _thermostatRepository;

        public DecreaseSetpointTemperatureCommand(IThermostatRepository lampRepository)
        {
            _thermostatRepository = lampRepository;
        }

        public void Execute(Guid lampId, Byte clicks)
        {
            var thermostat = _thermostatRepository.GetById(lampId);
            if (thermostat != null && thermostat.IsOn == true)
            {
                thermostat.DecreaseSetpointTemperature(clicks);
                thermostat.LastModified = DateTime.Now;
                _thermostatRepository.Update(thermostat);
            }
        }
    }
}
