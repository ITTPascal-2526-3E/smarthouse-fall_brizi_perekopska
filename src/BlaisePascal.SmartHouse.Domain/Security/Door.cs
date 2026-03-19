using BlaisePascal.SmartHouse.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Security
{
    public sealed class Door
    {
        public Name Name { get; protected set; }
        public bool IsLocked { get; protected set; }
        public DateTime Creation { get; set; }
        public DateTime LastModified;

        public Guid Id { get; protected set; }

        public Door(Guid id, bool isClosed)
        {
            Id = id;
            IsLocked = isClosed;
        }
        public Door(Name name)
        {
            Name = name;
            Id = Guid.NewGuid();
            IsLocked = false;
        }
        public Door(Guid id, Name name,bool isClosed,DateTime creation, DateTime lastModify)
        {
            Id = id;
            Name = name;
            IsLocked = isClosed;
            Creation = creation;
            LastModified = lastModify;
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
