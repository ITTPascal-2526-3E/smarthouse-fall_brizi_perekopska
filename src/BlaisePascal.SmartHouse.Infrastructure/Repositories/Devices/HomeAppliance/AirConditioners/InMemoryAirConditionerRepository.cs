using BlaisePascal.SmartHouse.Domain.HomeAppliances;
using BlaisePascal.SmartHouse.Domain.HomeAppliances.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.HomeAppliance.AirConditioners
{
    public class InMemoryAirConditionerRepository : IAirConditionerRepository
    {
        private readonly List<AirConditioner> _airConditioners;

        public InMemoryAirConditionerRepository()
        {
            _airConditioners = new List<AirConditioner>
            {
                new AirConditioner(Name.From("Name")),
                new AirConditioner(Name.From("Name2"))
            };
        }

        public List<AirConditioner> GetAll()
        {
            return _airConditioners;
        }

        public AirConditioner GetById(Guid id)
        {
            return _airConditioners.FirstOrDefault(airConditioner => airConditioner.Id == id);
        }

        public void Add(AirConditioner airConditioner)
        {
            if (airConditioner == null)
                throw new ArgumentNullException(nameof(airConditioner));
            _airConditioners.Add(airConditioner);
        }

        public void Remove(Guid id)
        {
            var airConditioner = GetById(id);
            if (airConditioner != null)
                _airConditioners.Remove(airConditioner);
        }

        public void Update(AirConditioner airConditioner)
        {
            // Not to do
        }
    }
}
