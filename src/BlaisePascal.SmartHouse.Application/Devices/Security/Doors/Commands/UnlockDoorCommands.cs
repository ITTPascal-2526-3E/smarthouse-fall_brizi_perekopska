using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Security.Doors.Commands
{
    internal class UnlockDoorCommands
    {
        private IDoorRepository _doorRepository;

        public UnlockDoorCommands(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Guid doorId)
        {
            var door = _doorRepository.GetById(doorId);
            if (door != null)
            {
                if (door.LockUnlockTheDoor() == true)
                {
                    door.LockUnlockTheDoor();
                }
                _doorRepository.Update(door);
            }
        }
    }
}

