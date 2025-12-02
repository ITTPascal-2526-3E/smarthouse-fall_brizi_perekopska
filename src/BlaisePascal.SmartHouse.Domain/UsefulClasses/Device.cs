using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UsefulClasses
{
    public class Device
    {
        protected string Name { get; set; }
        protected Guid Id { get; set; }
        public bool IsOn { get; set; }

        public Device(string name, bool isOn)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Device name cannot be null or empty.", nameof(name));
            else
                Name = name;

            Id = Guid.NewGuid();
            IsOn = isOn;
        }
    }
}
