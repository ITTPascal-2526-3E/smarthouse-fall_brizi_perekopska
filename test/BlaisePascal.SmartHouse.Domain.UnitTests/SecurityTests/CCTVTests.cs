using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Security;
namespace BlaisePascal.SmartHouse.Domain.UnitTests.SecurityTests
{
    public class CCTVTests
    {
        [Fact]
        public void turnOnOff_ChangeState()
        {
            bool isOn = false;
            CCTV cctv = new CCTV("camera 1", isOn, false, true);
            bool initialState = isOn;
            bool newState = cctv.TurnOnOrOff();
            Assert.NotEqual(initialState, newState);
        }
    }
}
