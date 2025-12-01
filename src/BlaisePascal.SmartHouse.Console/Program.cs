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
        static void Main(string[] args)
        {
            //Illumination Devices
            Lamp Lamp1 = new Lamp(false, 100, [100, 10, 50], "LED", new Time(23, 23, 23), new Time(10, 10, 12));
            EcoLamp EcoLamp1 = new EcoLamp(false, 50, "EcoLED", new Time(10, 00, 00), new Time(12, 00, 00), new Time(00, 00, 016));
            TwoLampDevice TwoLampDevice1 = new TwoLampDevice(Lamp1, EcoLamp1);
            //Temperature Devices
            Thermostat Thermostat1 = new Thermostat(true, 19.5f, 23.5f);
            //Home Appliances
            AirConditioner AirConditioner1 = new AirConditioner(true);
            AirFryer AirFryer1 = new AirFryer(true);
            //Security Devices
            CCTV Camera1 = new CCTV(true, false, true);
            Door Door1 = new Door(true);
            //Commands Handler
            CommandsHandler CommandsHandler = new CommandsHandler(Lamp1, EcoLamp1, TwoLampDevice1, Thermostat1, AirConditioner1, AirFryer1, Camera1, Door1);
            
            string CommandsList = @"Available Commands:
- turn on/off lamp1
- turn on/off ecolamp1
- change lamp1 brightness [value from 1 to 100]
- change ecolamp1 brightness [value from 1 to 66]
- change both lamps state
- change both lamps brightness [lamp1 value from 1 to 100] [ecolamp1 value from 1 to 66]
- turn on/off thermostat
- increase thermostat1 setpoint temperature [number of clicks]
- decrease thermostat1 setpoint temperature [number of clicks]
- start/stop air conditioner1
- start/stop air fryer1
- turn on/off camera1
- start/stop camera1 recording
- lock/unlock the door1
- display current temperature
";
            do
            {
                //Command Processing
                Console.WriteLine(CommandsList);
                string commandInput = Console.ReadLine().ToLower();

                CommandsHandler.Process(commandInput);
            } while (true);
        }
    }
}
