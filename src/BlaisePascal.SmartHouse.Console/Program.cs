using System;
using System.Threading;
namespace BlaisePascal.SmartHouse.Domain
{


    class Program
    {
        static void Main(string[] args)
        {
            EcoLamp EcoLamp1 = new EcoLamp(true, 50, "EcoLED", 10.7447, new Time(10, 00, 00), new Time(12, 00, 00), new Time(00, 15, 00));
            Lamp Lamp1 = new Lamp(true, 100, [100, 10, 50], "LED", 20.0999, new Time(23, 23, 23), new Time(10, 10, 12));
            Console.WriteLine("Lamp1: " + Lamp1.TurnOnOrOff() + ", brightness = " + Lamp1.Brightness);
            Console.WriteLine("EcoLamp1: " + EcoLamp1.TurnOnOrOff() + ", brightness = " + EcoLamp1.Brightness);
            TwoLampDevice TwoLampDevice1 = new TwoLampDevice(Lamp1, EcoLamp1);

            TwoLampDevice1.ChangeBothLampState();
            do {
                Console.Clear();
                Console.WriteLine("Lamp1: "+ Lamp1.TurnOnOrOff() + ", brightness = " + Lamp1.Brightness);
                Console.WriteLine("EcoLamp1: "+ EcoLamp1.TurnOnOrOff() + ", brightness = " + EcoLamp1.Brightness);
                Thread.Sleep(1500);
            } while(true);
            
        }
    }
}
