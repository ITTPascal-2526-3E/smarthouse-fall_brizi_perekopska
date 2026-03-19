using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Security.Doors.Commands
{
    public class AddDoorCommand
    {
        private IDoorRepository _doorRepository;

        public AddDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Name name)
        {
            var door = new Door(name);
            door.Creation = DateTime.Now;
            door.LastModified = DateTime.Now;
            _doorRepository.Add(door);

        }
    }
}
