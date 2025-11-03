using System;
namespace BlaisePascal.SmartHouse.Domain
{


    class Program
    {
        static void Main(string[] args)
        {
            Lamp Lamp1 = new Lamp(true, 100, [100, 10, 50], "LED", 20.0999, new Time(23, 23, 23), new Time(10, 10, 12));
            Lamp1.Brightness = 70;
            Console.WriteLine(Lamp1.Brightness);
        }
    }
}
