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

        public Door(bool isClosed)
        {
            IsLocked = isClosed;
        }

        // Lock or unlock the door
        public bool LockUnlockTheDoor()
        {
            if(IsLocked == true)
            {
                IsLocked = false;
            }
            else
            {
                IsLocked = true;
            }
            return IsLocked;
        }
    }
}
