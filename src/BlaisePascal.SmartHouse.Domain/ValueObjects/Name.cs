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
        private Guid IfEmpty = Guid.NewGuid();

        private Name(string value) 
        {
            if (string.IsNullOrEmpty(value))
                Value = IfEmpty.ToString();
            else Value = value;
        }

        public static Name From(string value)=> new Name(value);
    }
}
