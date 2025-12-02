using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;

namespace BlaisePascal.SmartHouse.Domain.UnitTests.UsefulClassesTests
{
    public class DeviceTests
    {
        //Constructor tests
        [Fact]
        public void Constructor_InvalidParameters_ShouldThrowExeption()
        {
            string deviceName = "";
            bool isOn = true;
            Assert.Throws<ArgumentException>(() => new Device(deviceName, isOn));
        }
    }
}
