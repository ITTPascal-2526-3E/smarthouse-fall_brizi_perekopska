using System;
using System.Threading;
using System.Threading.Tasks;
namespace BlaisePascal.SmartHouse.Domain
{


    class Program
    {
        static async Task Main(string[] args)
        {
            EcoLamp EcoLamp1 = new EcoLamp(false, 50, "EcoLED", 10.7447, new Time(10, 00, 00), new Time(12, 00, 00), new Time(00, 00, 016));
            Lamp Lamp1 = new Lamp(false, 100, [100, 10, 50], "LED", 20.0999, new Time(23, 23, 23), new Time(10, 10, 12));
            Console.WriteLine("Lamp1: " + Lamp1.TurnOnOrOff() + ", brightness = " + Lamp1.Brightness);
            Console.WriteLine("EcoLamp1: " + EcoLamp1.TurnOnOrOff() + ", brightness = " + EcoLamp1.Brightness);
            TwoLampDevice TwoLampDevice1 = new TwoLampDevice(Lamp1, EcoLamp1);

            Lamp1.ChangeLampColor([120, 120, 120]);

            TwoLampDevice1.ChangeBothLampState();
            do {
                Console.Clear();
                Console.WriteLine("Lamp1: "+ Lamp1.TurnOnOrOff() + ", brightness = " + Lamp1.Brightness);
                Console.WriteLine("EcoLamp1: "+ EcoLamp1.TurnOnOrOff() + ", brightness = " + EcoLamp1.Brightness);
                Thread.Sleep(5000);
            } while(true);
            
            /*Console.WriteLine(EcoLamp1.TurnOnOrOff());
            await Task.Delay(6000);
            Console.WriteLine(EcoLamp1.TurnOnOrOff());
            Console.WriteLine(EcoLamp1.TurnOnOrOff());
            */
        }
    }
}
