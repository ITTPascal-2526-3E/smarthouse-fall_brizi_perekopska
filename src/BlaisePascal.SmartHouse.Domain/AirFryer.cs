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

        private Time _Timer;

        //Constructor
        public AirFryer(bool isOn, byte cookingTemperature)
        {
            IsOn = isOn;
            CookingTemperature = cookingTemperature;
            if(cookingTemperature>=MinTemperature && cookingTemperature<=MaxTemperature)
            {
                CookingTemperature = cookingTemperature;
            }
        }

        public void Start()
        {

        }

    }
}
