using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.ValueObjects
{
    public sealed class Name
    {
        public string Value { get; }
        private Name(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                Value = "Default name";
            }
            else
            {
                Value = value;
            }
        }
    }
}
