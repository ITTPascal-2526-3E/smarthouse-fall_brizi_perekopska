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
        public LampsRow(int lampsNum, Lamp defaultLamp) {
            LampsList = new List<Lamp>();
            if (lampsNum <= 0)
            {
                if (lampsNum == 0)
                    return; ///If 0 lamps are specified, initialize an empty LampsRow
                else
                    throw new ArgumentException("Number of lamps cannot be negative");
            }
            else
            {
                ///Initialize the LampsList with the specified number of lamps
                for (int i = 0; i < lampsNum; i++)
                    LampsList.Add(defaultLamp);
            }
             
        }

        //Counts the total number of lamps in the LampsRow
        public int CountLamps()
        {
            return LampsList.Count;
        }

        //Adds a new lamp to the LampsRow
        public void AddLamp(Lamp newLamp)
        {
            if (newLamp != null)
                LampsList.Add(newLamp);
            else
                throw new ArgumentNullException("Lamp to add cannot be null");
        }

        // Inserts a lamp at the specified position in the LampsRow
        public void InsertLampInPosition(Lamp lampToInsert, int position)
        {
            if (lampToInsert != null && position >= 0 && position <= LampsList.Count)
                LampsList.Insert(position, lampToInsert);
            else
                throw new ArgumentOutOfRangeException("Position is out of range or lamp is null");
        }

        //Removes a lamp from the LampsRow
        public void RemoveLamp(Lamp lampToRemove)
        {
            if (lampToRemove != null && LampsList.Contains(lampToRemove))
                LampsList.Remove(lampToRemove);
            else
                throw new ArgumentException("Lamp to remove is null or does not exist in the LampsRow");
        }

        //Removes a lamp at the specified position in the LampsRow
        public void RemoveLampInPosition(int position)
        {
            if (position >= 0 && position < LampsList.Count)
                LampsList.RemoveAt(position);
            else
                throw new ArgumentOutOfRangeException("Position is out of range");
        }

        //Turns on or off all lamps in the LampsRow
        public void TurnOnOrOffAllLamps()
        {
            foreach(var lamp in LampsList)
                lamp.TurnOnOrOff();
        }

        //Changes the brightness of all lamps in the LampsRow to the specified value
        public void ChangeBrightnessForAllLamps(byte newBrightness)
        {
            foreach (var lamp in LampsList)
                lamp.ChangeBrightness(newBrightness);
        }

        //Changes the color of all lamps in the LampsRow to the specified RGB value
        public void ChangeColorForAllLamps(byte[] newColor)
        {
            foreach (var lamp in LampsList)
                lamp.ChangeLampColor(newColor);
        }
    }
}
