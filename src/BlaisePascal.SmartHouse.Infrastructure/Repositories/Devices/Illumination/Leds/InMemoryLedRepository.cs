using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Illumination.Leds
{
    public class InMemoryLedRepository : ILedRepository
    {
        private readonly List<Led> _leds;

        public InMemoryLedRepository()
        {
            _leds = new List<Led>
            {
                new Led(Name.From("Name")),
                new Led(Name.From("Name2"))
            };
        }

        public List<Led> GetAll()
        {
            return _leds;
        }

        public Led GetById(Guid id)
        {
            return _leds.FirstOrDefault(led => led.Id == id);
        }

        public void Add(Led led)
        {
            if (led == null)
                throw new ArgumentNullException(nameof(led));
            _leds.Add(led);
        }

        public void Remove(Guid id)
        {
            var led = GetById(id);
            if (led != null)
                _leds.Remove(led);
        }

        public void Update(Led led)
        {
            // Not to do
        }
    }
}
