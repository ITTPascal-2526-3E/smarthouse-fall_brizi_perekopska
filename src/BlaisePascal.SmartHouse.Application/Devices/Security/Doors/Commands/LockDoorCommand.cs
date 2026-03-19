using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Security.Doors.Commands
{
    public class LockDoorCommand
    {
        private IDoorRepository _doorRepository;

        public LockDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Guid doorId)
        {
            var door = _doorRepository.GetById(doorId);
            if (door != null)
            {
                if (door.IsLocked == false)
                {
                    door.LockUnlockTheDoor();
                    door.LastModified = DateTime.Now;
                }
                _doorRepository.Update(door);
            }
        }
    }
}
