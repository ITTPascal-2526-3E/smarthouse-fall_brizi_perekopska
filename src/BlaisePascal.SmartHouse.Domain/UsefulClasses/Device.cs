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
        public Name Name { get; init; }
        public Guid Id { get; init; }
        public bool IsOn { get; protected set; }
        public DateTime Creation;
        public DateTime LastModified;

        public Device(Name name, bool isOn)
        {
            Name = name;
            Id = Guid.NewGuid();
            IsOn = isOn;
        }
        public Device(Name name, bool isOn, Guid id, DateTime creation, DateTime lastModified)
        {
            Name = name;
            Id = id;
            IsOn = isOn;
            Creation = creation;
            LastModified = lastModified;
        }
    }
}
