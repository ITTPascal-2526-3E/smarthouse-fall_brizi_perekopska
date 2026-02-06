using BlaisePascal.SmartHouse.Domain.Interface;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Temperature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.HomeAppliances
{
    public sealed class AirFryer : Device, ISwitchable
    {
        //Attributes
        private ARTemperature CookingTemperature;
        private ARTemperature LastCookingTemperature;

        public enum CookingType { Null, Fryed, Roasted, Sweets, Grilled, Dehydrated, Baked, Dryed, SlowCooked, Steamed, Pizza, Reheated, Tosted, KeepWarmed, Pasta}

        public CookingType LastCookingMethod { get; private set;  }
        
        public bool Stop { get; private set; }

        //Constructor
        public AirFryer(Name name, bool isOn) : base(name, isOn)
        {
            IsOn = isOn;
        }

        public bool TurnOnOrOff() 
        {
            if (IsOn == true)
            {
                IsOn = false;
                LastCookingTemperature = CookingTemperature;
                CookingTemperature = ARTemperature.From(0);
            }
            else
            {
                IsOn = true;
                CookingTemperature = LastCookingTemperature;
            }
            return IsOn;
        }

        //Start of the cooking, using a timer.
        public async Task StartTheCooking(CookingType type, ARTemperature cookingTemperature, Time timer)
        {
            try
            {
                CookingTemperature = cookingTemperature;
                LastCookingTemperature = CookingTemperature;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return;
            }
            LastCookingMethod = type;

            int time = (timer.Hours.Value * 3600 + timer.Minutes.Value * 60 + timer.Seconds.Value) * 1000;
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
