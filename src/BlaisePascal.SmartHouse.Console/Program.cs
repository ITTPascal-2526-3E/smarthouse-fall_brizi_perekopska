using System;
using System.Threading;
namespace BlaisePascal.SmartHouse.Domain
{


    class Program
    {
        static void Main(string[] args)
        {
            EcoLamp EcoLamp1 = new EcoLamp(true, 50, "EcoLED", 10,77, new Time(10, 00, 00), new Time(12, 00, 00);
            Lamp Lamp1 = new Lamp(true, 100, [100, 10, 50], "LED", 20.0999, new Time(23, 23, 23), new Time(10, 10, 12));
            TwoLampDevice TwoLampDevice1 = new TwoLampDevice();
            do {
                Console.Clear();
                Console.WriteLine("Lamp1: "+ Lamp1.IsOn + ", brightness = " + Lamp1.Brightness);
                Console.WriteLine("EcoLamp1: "+ EcoLamp1.IsOn + ", brightness = " + EcoLamp1.Brightness);
                Console.WriteLine("TwoLampDevice1: "+ TwoLampDevice1.IsOn + ", brightness = " + TwoLampDevice1.Brightness);
            } while(true);
        }
    }
}
