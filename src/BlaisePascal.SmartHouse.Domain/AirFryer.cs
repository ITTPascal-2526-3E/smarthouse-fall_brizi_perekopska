using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    internal class AirFryer
    {
        //Attributes
        private bool IsOn;

        const byte MaxTemperature = 200;
        const byte MinTemperature = 80;
        private byte CookingTemperature;

        public enum CookingType { Null, Fryed, Roasted, Sweets, Grilled, Dehydrated, Baked, Dryed, SlowCooked, Steamed, Pizza, Reheated, Tosted, KeepWarmed, Pasta}

        CookingType LastCookingMethod;
        
        private bool Stop = false;

        //Constructor
        public AirFryer(bool isOn)
        {
            IsOn = isOn;
        }

        //Start of the cooking, using a timer.
        public async Task StartTheCooking( CookingType type, byte cookingTemperature, Time timer)
        {

            if (cookingTemperature >= MinTemperature && cookingTemperature <= MaxTemperature)
                CookingTemperature = cookingTemperature;

            LastCookingMethod = type;

            int time = ((timer.Hours * 3600) + (timer.Minutes * 60) + timer.Seconds) * 1000;
            int temp = 0;
            while (temp < time) 
            {
                temp += 1;
                await Task.Delay(1);
                if (Stop == true)
                    break;
            }

            if (Stop == true)
                Console.WriteLine("🍗🍗🍗 FISHED COOKING 🍗🍗🍗");
            else
                Console.WriteLine("😭😭😭 COOKING STOPPED 😭😭😭");
            
            Stop = false;
        }

        //Voluntery stop the ayr fryer
        public void StopTheCooking() 
        { 
            Stop = true;
        }
    }
}
