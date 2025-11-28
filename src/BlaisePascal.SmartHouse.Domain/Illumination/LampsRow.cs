using BlaisePascal.SmartHouse.Domain.UsefullClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Illumination
{
    public class LampsRow
    {
        private List<Lamp> LampsList;

        public LampsRow(int lampsNum) {
            for (int i = 0; i < lampsNum; i++)
            {
                Lamp newLamp = new Lamp(false, 100, [255, 255, 255], "LED", new Time(0, 0, 0), new Time(0, 0, 0));
                LampsList.Add(newLamp);
            }
        }

        public void TurnOnOrOffAllLamps()
        {
            foreach(var lamp in LampsList)
            {
                lamp.TurnOnOrOff();
            }
        }
    }
}
