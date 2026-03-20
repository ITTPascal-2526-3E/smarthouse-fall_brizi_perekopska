using BlaisePascal.SmartHouse.Domain.HomeAppliances;
using BlaisePascal.SmartHouse.Domain.HomeAppliances.Repositories;
using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.HomeAppliance.AirFtryers
{
    public class InMemoryAirFryerRepository : IAirFryerRepository
    {
        private readonly List<AirFryer> _airFryers;

        public InMemoryAirFryerRepository()
        {
            _airFryers = new List<AirFryer>
            {
                new AirFryer(Name.From("Name")),
                new AirFryer(Name.From("Name2"))
            };
        }

        public List<AirFryer> GetAll()
        {
            return _airFryers;
        }

        public AirFryer GetById(Guid id)
        {
            return _airFryers.FirstOrDefault(airFryer => airFryer.Id == id);
        }

        public void Add(AirFryer airFryer)
        {
            if (airFryer == null)
                throw new ArgumentNullException(nameof(airFryer));
            _airFryers.Add(airFryer);
        }

        public void Remove(Guid id)
        {
            var led = GetById(id);
            if (led != null)
                _airFryers.Remove(led);
        }

        public void Update(AirFryer airFryer)
        {
            // Not to do
        }
    }
}
