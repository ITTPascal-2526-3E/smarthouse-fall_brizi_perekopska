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

        [Fact]
        public void Constructor_NullName_ShouldThrowException()
        {
            string deviceName = null;
            bool isOn = false;
            Assert.Throws<ArgumentException>(() => new Device(deviceName, isOn));
        }

        [Fact]
        public void Constructor_ValidParameters_ShouldCreateDevice()
        {
            string deviceName = "TestDevice";
            bool isOn = true;
            Device device = new Device(deviceName, isOn);
            Assert.Equal(deviceName, device.Name);
            Assert.Equal(isOn, device.IsOn);
            Assert.NotEqual(Guid.Empty, device.Id);
        }
    }
}
