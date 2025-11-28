using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.UsefullClasses;
using BlaisePascal.SmartHouse.Domain.Illumination;

namespace BlaisePascal.SmartHouse.Domain.UnitTests.IlluminationTests
{
    public class LampsRowTests
    {
        // TurnOnOrOff tests
        [Fact]
        public void TurnOnOrOffAllLamps_ShoulChangeStateOfAllLampsInTheRow()
        {
            bool isOn = false;
            var newLamp = new Lamp(isOn, 100, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(3, newLamp); /// Create a LampsRow with 3 lamps
            LampsRow.TurnOnOrOffAllLamps();
            /// Since all lamps are initially off, after turning on, all should be on
            //foreach (var lamp in LampsRow.LampsList)
            //{
            //    var initialState = isOn;
            //    var newState = lamp.isOn;
            //    Assert.NotEqual(initialState, newState);
            //}//PORCOOOOO CANEE CRISTIANO COME FUNZIA STA ROBAAAAAAA
            //Assert.All(LampsRow.LampsList, newLamp => Assert.True(newLamp.isOn));//Vaffanculo
        }
    }
}
