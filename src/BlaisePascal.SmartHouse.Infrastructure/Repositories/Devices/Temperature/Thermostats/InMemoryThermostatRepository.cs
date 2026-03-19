using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using BlaisePascal.SmartHouse.Domain.Temperature;
using BlaisePascal.SmartHouse.Domain.Temperature.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Temperature.Thermostats
{
    public class InMemoryThermostatRepository : IThermostatRepository
    {
        private readonly List<Thermostat> _thermostats;

        public InMemoryThermostatRepository()
        {
            _thermostats = new List<Thermostat>
            {
                new Thermostat(Name.From("Name")),
                new Thermostat(Name.From("Name2"))
            };
        }

        public List<Thermostat> GetAll()
        {
            return _thermostats;
        }

        public Thermostat GetById(Guid id)
        {
            return _thermostats.FirstOrDefault(thermostat => thermostat.Id == id);
        }

        public void Add(Thermostat thermostat)
        {
            if (thermostat == null)
                throw new ArgumentNullException(nameof(thermostat));
            _thermostats.Add(thermostat);
        }

        public void Remove(Guid id)
        {
            var thermostat = GetById(id);
            if (thermostat  != null)
                _thermostats.Remove(thermostat);
        }

        public void Update(Thermostat thermostat)
        {
            // Not to do
        }
    }
}
