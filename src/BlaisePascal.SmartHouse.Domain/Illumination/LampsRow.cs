using BlaisePascal.SmartHouse.Domain.UsefulClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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

        //Removers a lamp by name from the LampsRow
        public void RemoveLampByName(string lampName)
        {
            var lampToRemove = LampsList.FirstOrDefault(lamp => lamp.Name == lampName);
            if (lampToRemove != null)
                LampsList.Remove(lampToRemove);
            else
                throw new ArgumentException("Lamp with the specified name does not exist in the LampsRow");
        }

        //Removes a lamp by ID from the LampsRow
        public void RemoveLampById(Guid lampId)
        {
            var lampToRemove = LampsList.FirstOrDefault(lamp => lamp.Id == lampId);
            if (lampToRemove != null)
                LampsList.Remove(lampToRemove);
            else
                throw new ArgumentException("Lamp with the specified ID does not exist in the LampsRow");
        }

        //Turns on or off all lamps in the LampsRow
        public void TurnOnOrOffAllLamps()
        {
            foreach(var lamp in LampsList)
                lamp.TurnOnOrOff();
        }

        //Turns on or off one lamp by name in the LampsRow
        public void TurnOnOrOffLampByName(string lampName)
        {
            bool found = false;
            foreach (var lamp in LampsList)
            {
                if (lamp.Name == lampName)
                {
                    lamp.TurnOnOrOff();
                    found = true;
                    return;
                }
            }
            if (!found)
                throw new ArgumentException("Lamp with the specified name does not exist in this LampsRow");
        }

        //Turns on or off one lamp by ID in the LampsRow
        public void TurnOnOrOffLampById(Guid lampId)
        {
            var lamp = LampsList.FirstOrDefault(l => l.Id == lampId);
            if (lamp != null)
                lamp.TurnOnOrOff();
            else
                throw new ArgumentException("Lamp with the specified ID does not exist in this LampsRow");
        }

        //Changes the brightness of all lamps in the LampsRow to the specified value
        public void ChangeBrightnessForAllLamps(byte newBrightness)
        {
            foreach (var lamp in LampsList)
                lamp.ChangeBrightness(newBrightness);
        }

		//Changes the brightness of one lamp or more by name
		public void ChangeBrightnessByName(string name, byte brightness)
        {
            bool found = false;
            foreach (var lamp in LampsList)
            {
                if (lamp.Name == name) { 
                    lamp.ChangeBrightness(brightness);
                    found = true;
                }
            }
            if (!found)
                throw new ArgumentException("Lamp with the specified name does not exist in this LampsRow");
        }

		//Changes the brightness of one lamp by its id
		public void ChangeBrightnessById(Guid id, byte brightness)
		{
            bool found = false;
            foreach (var lamp in LampsList)
            {
                if (lamp.Id == id) {
                    lamp.ChangeBrightness(brightness);
                    found = true; 
                }
            }
            if (!found)
                throw new ArgumentException("Lamp with the specified Id does not exist in this LampsRow");
        }

        //Changes the color of all lamps in the LampsRow to the specified RGB value
        public void ChangeColorForAllLamps(byte[] newColor)
        {
            foreach (var lamp in LampsList)
                lamp.ChangeLampColor(newColor);
        }

		//Changes the color of one lamp or more by name
		public void ChangeColorByName(string name, byte[] color)
		{
            bool found = false;
            foreach (var lamp in LampsList)
            {
                if (lamp.Name == name)
                {
                    lamp.ChangeLampColor(color);
                    found = true;
                }
            }
            if (!found)
                throw new ArgumentException("Lamp with the specified name does not exist in this LampsRow");
        }

        //Changes the color of one lamp by its id
        public void ChangeColorById(Guid id, byte[] color)
        {
            bool found = false;
            foreach (var lamp in LampsList)
            {
                if (lamp.Id == id) {
                    lamp.ChangeLampColor(color);
                    found = true;
                }
            }
            if (!found)
                throw new ArgumentException("Lamp with the specified Id does not exist in this LampsRow");
        }
    }
}
