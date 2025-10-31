namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp
    {
        
        //Attributes:
        public bool IsOn { get; set; }
        public byte Brightness { get; set; }
        public string Color {  get; set; }
        private string Type;
        private double ConsumeAtMaxBrightnessPerHour;
        public Time OnTime;
        public Time OffTime;

        public Lamp(bool isOn,byte brightness,string color,string type,double consumeAtMaxBrightnessPerHour,Time onTime,Time offTime) 
        { 
            IsOn = isOn;
            if(brightness>=1 && brightness <= 100)
            {
                Brightness = brightness;
            }
            if (!string.IsNullOrEmpty(color))
            {
                Color = color;
            }
            if (!string.IsNullOrEmpty(type)) 
            { 
                Type = type;
            }
            if (consumeAtMaxBrightnessPerHour>0.0) 
            { 
                ConsumeAtMaxBrightnessPerHour = consumeAtMaxBrightnessPerHour;
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
        
    }
}
