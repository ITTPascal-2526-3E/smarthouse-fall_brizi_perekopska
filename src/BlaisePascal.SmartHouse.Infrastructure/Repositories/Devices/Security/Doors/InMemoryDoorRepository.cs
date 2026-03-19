using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Security.Doors
{
    public class InMemoryDoorRepository : IDoorRepository
    {
        private readonly List<Door> _doors;

        public InMemoryDoorRepository()
        {
            _doors = new List<Door>
            {
                new Door(Name.From("Name")),
                new Door(Name.From("Name2"))
            };
        }

        public List<Door> GetAll()
        {
            return _doors;
        }

        public Door GetById(Guid id)
        {
            return _doors.FirstOrDefault(door => door.Id == id);
        }

        public void Add(Door door)
        {
            if (door == null)
                throw new ArgumentNullException(nameof(door));
            _doors.Add(door);
        }

        public void Remove(Guid id)
        {
            var led = GetById(id);
            if (led != null)
                _doors.Remove(led);
        }

        public void Update(Door door)
        {
            // Not to do
        }
    }
}
