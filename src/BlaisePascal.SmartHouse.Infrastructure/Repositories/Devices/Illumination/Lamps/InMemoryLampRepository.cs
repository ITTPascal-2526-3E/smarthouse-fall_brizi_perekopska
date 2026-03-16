using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.ValueObjects;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Illumination.Lamps
{
    public class InMemoryLampRepository : ILampRepository
    {
        private readonly List<Lamp> _lamps;

        public InMemoryLampRepository()
        {
            _lamps = new List<Lamp>
            {
                new Lamp(Name.From("Name")),
                new Lamp(Name.From("Name2"))
            };
        }

        public List<Lamp> GetAll()
        {
            return _lamps;
        }

        public Lamp GetById(Guid id)
        {
            return _lamps.FirstOrDefault(lamp => lamp.Id == id);
        }

        public void Add(Lamp lamp)
        {
            if (lamp == null)
                throw new ArgumentNullException(nameof(lamp));
            _lamps.Add(lamp);
        }

        public void Remove(Guid id)
        {
            var lamp = GetById(id);
            if (lamp != null)
                _lamps.Remove(lamp);
        }

        public void Update(Lamp lamp)
        {
            // Not to do
        }
    }
}
