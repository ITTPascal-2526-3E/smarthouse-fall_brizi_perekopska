using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Door
    {
        private bool IsLocked;

        public Door(bool isClosed)
        {
            IsLocked = isClosed;
        }


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
