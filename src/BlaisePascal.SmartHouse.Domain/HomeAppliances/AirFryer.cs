using BlaisePascal.SmartHouse.Domain.UsefullClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;

namespace BlaisePascal.SmartHouse.Domain.HomeAppliances
{
    public class AirFryer : Device
    {
        //Attributes

        const byte MaxTemperature = 200;
        const byte MinTemperature = 80;
        private byte CookingTemperature;

        public enum CookingType { Null, Fryed, Roasted, Sweets, Grilled, Dehydrated, Baked, Dryed, SlowCooked, Steamed, Pizza, Reheated, Tosted, KeepWarmed, Pasta}

        public CookingType LastCookingMethod { get; private set;  }
        
        public bool Stop { get; private set; }

        //Constructor
        public AirFryer(string name, bool isOn) : base(name, isOn)
        {
            IsOn = isOn;
        }

        //Start of the cooking, using a timer.
        public async Task StartTheCooking(CookingType type, byte cookingTemperature, Time timer)
        {
            try
            {
                if (cookingTemperature >= MinTemperature && cookingTemperature <= MaxTemperature)
                {
                    CookingTemperature = cookingTemperature;
                }
                else 
                {
                    throw new Exception();
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return;
            }
            LastCookingMethod = type;

            int time = (timer.Hours * 3600 + timer.Minutes * 60 + timer.Seconds) * 1000;
            int temp = 0;
            while (temp < time) 
            {
                temp += 1;
                await Task.Delay(1);
                if (Stop == true)
                    break;
            }

            if (Stop == true)
            {
                Console.WriteLine("\t ------------------------------------ ");
                Console.WriteLine("\t|   🍗🍗🍗 FISHED COOKING 🍗🍗🍗   |");
                Console.WriteLine("\t| 🍽️🍽️🍽️ YOUR FOOD IS READY 🍽️🍽️🍽️ |");
                Console.WriteLine("\t ------------------------------------ ");
            }
            else
            {
                Console.WriteLine("\t ---------------------------------------------- ");
                Console.WriteLine("\t| 🧑‍🍳🧑‍🍳🧑‍🍳 COOKING STOPPED 🧑‍🍳🧑‍🍳🧑‍🍳 |");
                Console.WriteLine("\t ---------------------------------------------- ");
            }

            Stop = false;
        }

        //Voluntery stop the ayr fryer
        public void StopTheCooking() 
        { 
            Stop = true;
        }
    }
}
