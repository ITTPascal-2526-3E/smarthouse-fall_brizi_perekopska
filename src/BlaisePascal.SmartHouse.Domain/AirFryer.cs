using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private Time _Timer;

        //Constructor
        public AirFryer(bool isOn)
        {
            IsOn = isOn;
        }

        public void Start( CookingType type, byte cookingTemperature)
        {
            if (cookingTemperature >= MinTemperature && cookingTemperature <= MaxTemperature)
            {
                CookingTemperature = cookingTemperature;
            }
        }

    }
}
