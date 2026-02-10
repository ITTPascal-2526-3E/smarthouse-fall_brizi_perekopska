using BlaisePascal.SmartHouse.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Temperature.Repositories
{
    public interface IThermostatRepository
    {
        void Add(Thermostat thermostat);
        void Update(Thermostat thermostat);
        void Remove(Guid id);
        Thermostat GetById(Guid id);
        List<Thermostat> GetAll();
    }
}
