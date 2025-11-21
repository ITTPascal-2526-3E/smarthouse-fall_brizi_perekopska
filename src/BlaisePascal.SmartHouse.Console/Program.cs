using BlaisePascal.SmartHouse.Domain.HomeAppliances;
using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Temperature;
using BlaisePascal.SmartHouse.Domain.UsefullClasses;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //THERMOSTAT
            Thermostat Thermostat1 = new Thermostat(true, 19.5f, 23.5f);
            Thermostat1.DisplayCurrentTemperature();
            Thermostat1.IncreaseSetpointTemperature(1);
            Console.ReadKey();
            await Thermostat1.RaiseCurrentTemperature();
            Thermostat1.DisplayCurrentTemperature();
            Console.ReadKey();

            //AIR CONDITIONER
            AirConditioner AirConditioner1 = new AirConditioner(true);
            AirConditioner1.StartAirConditioner(AirConditioner.AirType.Cool, 25.0f , 90);

            //AIRFRYER
            AirFryer AirFryer1 = new AirFryer(true);
            //await AirFryer1.StartTheCooking(AirFryer.CookingType.Null, 200, new Time(00, 00, 10));

            // FLASHING LAMP
            EcoLamp EcoLamp1 = new EcoLamp(false, 50, "EcoLED", new Time(10, 00, 00), new Time(12, 00, 00), new Time(00, 00, 016));
            Lamp Lamp1 = new Lamp(false, 100, [100, 10, 50], "LED", new Time(23, 23, 23), new Time(10, 10, 12));
            TwoLampDevice TwoLampDevice1 = new TwoLampDevice(Lamp1, EcoLamp1);

            Random rnd = new Random();

            TwoLampDevice1.ChangeBothLampState();

            //CCTV
            CCTV Camera1 = new CCTV(false, false, true);
            Camera1.StartOrStopRecording();
            Camera1.TurnOnOrOff();
            Camera1.StartOrStopRecording();

            //DISPLAY LAMPS STATUS IN LOOP
            do
            {
                Console.Clear();
                Console.WriteLine("Lamp1: " + Lamp1.TurnOnOrOff() + ", brightness = " + Lamp1.Brightness);
                Console.WriteLine("EcoLamp1: " + EcoLamp1.TurnOnOrOff() + ", brightness = " + EcoLamp1.Brightness);
                Thread.Sleep(3000);

                Lamp1.ChangeBrightness((byte)rnd.Next(1, 101));
                EcoLamp1.ChangeBrightness((byte)rnd.Next(1, 66));
            } while (true);

            ///RUN THE TIMER
            //Console.WriteLine(EcoLamp1.TurnOnOrOff());
            //await Task.Delay(6000);
            //Console.WriteLine(EcoLamp1.TurnOnOrOff());
            //Console.WriteLine(EcoLamp1.TurnOnOrOff());

            
            


            
        }
    }
}
