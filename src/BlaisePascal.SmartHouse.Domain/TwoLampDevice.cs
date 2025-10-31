using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    
    public class TwoLampDevice
    {
        //Attributes:
        private Lamp NormalLamp;
        private EcoLamp EcoLamp;



        //Constructor:
        public TwoLampDevice(Lamp normalLamp, EcoLamp ecoLamp) 
        { 
            NormalLamp=normalLamp;
            EcoLamp = ecoLamp;
        }



        public void ChangeState(string witch) 
        {
            if (witch == "Normal") 
            {
                if (NormalLamp.IsOn == true)
                {
                    NormalLamp.IsOn = false;
                }
                else 
                { 
                    NormalLamp.IsOn=false;
                }
            }


            if (witch == "Eco")
            {
                if (EcoLamp.IsOn == true)
                {
                    EcoLamp.IsOn = false;
                }
                else
                {
                    EcoLamp.IsOn = false;
                }
            }


            if (witch == "Both") 
            {
                if (EcoLamp.IsOn == true)
                {
                    EcoLamp.IsOn = false;
                }
                else
                {
                    EcoLamp.IsOn = false;
                }


                if (NormalLamp.IsOn == true)
                {
                    NormalLamp.IsOn = false;
                }
                else
                {
                    NormalLamp.IsOn = false;
                }
            }
        }
    }
}
