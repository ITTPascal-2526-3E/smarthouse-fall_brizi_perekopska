using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.UsefullClasses;

namespace BlaisePascal.SmartHouse.Domain.Illumination
{
    public class LampsRow
    {
        //Attributes
        public List<Lamp> LampsList { get; private set; }

        //Constructor
        public LampsRow(int lampsNum, Lamp newLamp) {
            LampsList = new List<Lamp>();
            //Initialize the LampsList with the specified number of lamps
            for (int i = 0; i < lampsNum; i++)
                LampsList.Add(newLamp);
        }

        //Adds a new lamp to the LampsRow
        public void AddLamp(Lamp newLamp)
        {
            LampsList.Add(newLamp);
        }

        //Turns on or off all lamps in the LampsRow
        public void TurnOnOrOffAllLamps()
        {
            foreach(var lamp in LampsList)
                lamp.TurnOnOrOff();
        }

        //Changes the brightness of all lamps in the LampsRow to the specified value
        public void ChangeBrightnessAllLamps(byte newBrightness)
        {
            foreach (var lamp in LampsList)
                lamp.ChangeBrightness(newBrightness);
        }

        //Changes the color of all lamps in the LampsRow to the specified RGB value
        public void ChangeColorAllLamps(byte[] newColor)
        {
            foreach (var lamp in LampsList)
                lamp.ChangeLampColor(newColor);
        }
    }
}
