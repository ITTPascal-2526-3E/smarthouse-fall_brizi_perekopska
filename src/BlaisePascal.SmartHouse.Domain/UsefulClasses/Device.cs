using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.UsefulClasses
{
    public abstract class Device
    {
        public Name Name { get; protected set; }
        public Guid Id { get; protected set; }
        public bool IsOn { get; protected set; }

        public Device(Name name, bool isOn)
        {
            Name = name;
            Id = Guid.NewGuid();
            IsOn = isOn;
        }
    }
}
