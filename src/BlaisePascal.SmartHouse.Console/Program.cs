using System;
using System.Threading;
namespace BlaisePascal.SmartHouse.Domain
{


    class Program
    {
        static void Main(string[] args)
        {
            EcoLamp EcoLamp1 = new EcoLamp(true, 50, "EcoLED", 10.7447, new Time(10, 00, 00), new Time(12, 00, 00), new Time(00, 00, 00));
            Lamp Lamp1 = new Lamp(true, 100, [100, 10, 50], "LED", 20.0999, new Time(23, 23, 23), new Time(10, 10, 12));
            do {
                Console.Clear();
                Console.WriteLine("Lamp1: "+ Lamp1.IsOn + ", brightness = " + Lamp1.Brightness);
                Console.WriteLine("EcoLamp1: "+ EcoLamp1.IsOn + ", brightness = " + EcoLamp1.Brightness);
                Thread.Sleep(500);
                Console.Clear();
            } while(true);
        }
    }
}
