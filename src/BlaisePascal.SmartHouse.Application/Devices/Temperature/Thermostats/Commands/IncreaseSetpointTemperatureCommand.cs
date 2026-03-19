using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using BlaisePascal.SmartHouse.Domain.Temperature.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Temperature.Thermostats.Commands
{
    public class IncreaseSetpointTemperatureCommand
    {
        private IThermostatRepository _thermostatRepository;

        public IncreaseSetpointTemperatureCommand(IThermostatRepository lampRepository)
        {
            _thermostatRepository = lampRepository;
        }

        public void Execute(Guid lampId, Byte clicks)
        {
            var thermostat = _thermostatRepository.GetById(lampId);
            if (thermostat != null && thermostat.IsOn == true)
            {
                thermostat.IncreaseSetpointTemperature(clicks);
                thermostat.LastModified = DateTime.Now;
                _thermostatRepository.Update(thermostat);
            }
        }
    }
}
