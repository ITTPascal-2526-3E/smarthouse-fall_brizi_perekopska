using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Security
{
    public sealed class Door
    {
        private bool IsLocked;
        public Guid Id { get; protected set; }

        public Door(Guid id, bool isClosed)
        {
            Id = id;
            IsLocked = isClosed;
        }
        public Door(Guid id)
        {
            Id = id;
            IsLocked = false;
        }

        // Lock or unlock the door
        public bool LockUnlockTheDoor()
        {
            if(IsLocked == true)
                IsLocked = false;
            else
                IsLocked = true;

            return IsLocked;
        }
    }
}
