namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp
    {

        //Attributes:
        private bool IsOn;
        public byte Brightness { get; set; }
        public byte[] Color = new byte[3] { 0,0,0}; //RGB
        private string Type;
        private double ConsumeAtMaxBrightnessPerHour;
        public Time OnTime;
        public Time OffTime;



        //Constructor:
        public Lamp(bool isOn,byte brightness,byte[] color,string type,double consumeAtMaxBrightness,Time onTime,Time offTime) 
        { 
            IsOn = isOn;


            if(brightness>=1 && brightness <= 100)
            {
                Brightness = brightness;
            }
            

                Color = color;
            

            if (!string.IsNullOrEmpty(type)) 
            { 
                Type = type;
            }


            if (consumeAtMaxBrightness>0.0) 
            { 
                ConsumeAtMaxBrightnessPerHour = consumeAtMaxBrightness;
            }


            if (onTime.Hours > offTime.Hours)
            {
                OnTime = onTime;
            }


            if (onTime.Hours > offTime.Hours)
            {
                OffTime = offTime;
            }


        }




        /// <summary>
        /// Change the state of the Lamp, on or off.
        /// </summary>
        public bool TurnOnOrOff() 
        {
            if (IsOn == true)
            {
                IsOn = false;
            }
            else 
            { 
                IsOn=true;
            }
            return IsOn;
        }


        
    }
}
