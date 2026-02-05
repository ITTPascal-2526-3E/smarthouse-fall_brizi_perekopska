using BlaisePascal.SmartHouse.Domain.HomeAppliances;
using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Temperature;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
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
            Lamp Lamp1 = new Lamp(Name.From("porta"),false, Brightness.From(100), [100, 10, 50], "LED", new Time(23, 23, 23), new Time(10, 10, 12));
            EcoLamp EcoLamp1 = new EcoLamp(Name.From("portaEco"),false, EcoBrightness.From(56), "EcoLED", new Time(10, 00, 00), new Time(12, 00, 00), new Time(00, 00, 016));
            TwoLampDevice TwoLampDevice1 = new TwoLampDevice(Lamp1, EcoLamp1);
            MatrixLed MatrixLed1 = new MatrixLed(2,3);
            //Temperature Devices
            Thermostat Thermostat1 = new Thermostat(Name.From("Thermostat1"), true, 19.5f, 23.5f);
            //Home Appliances
            AirConditioner AirConditioner1 = new AirConditioner(Name.From("AirConditioner1"), true);
            AirFryer AirFryer1 = new AirFryer(Name.From("AirFryer1"), true);
            //Security Devices
            CCTV Cameras = new CCTV(Name.From("Cameras"), true, false, true);
            Door Door1 = new Door(true);
            //Commands Handler
            CommandsHandler CommandsHandler = new CommandsHandler(Lamp1, EcoLamp1, TwoLampDevice1, Thermostat1, AirConditioner1, AirFryer1, Cameras, Door1, MatrixLed1);
            
            string CommandsList = $@"AVAILABLE COMANDS:
LAMPS COMANDS
- turn on/off lamp1
- change lamp1 brightness [value from 1 to 100]
- change lamp1 state
- change lamp 1 color

- turn on/off ecolamp1
- change ecolamp1 brightness [value from 1 to 66]
- change ecolamp1 state

- change both lamps state
- change both lamps brightness [lamp1 value from 1 to 100] [ecolamp1 value from 1 to 66]

-switch all led on
-switch all led off
-set all intensity[value from 1 to 100]
-get led by row and column[value from 0 to {MatrixLed1.GetRowsNumber()}] [value from 0 to {MatrixLed1.GetColumnsNumber()}]//doesn't work
-get a row of led by the rows [value from 0 to {MatrixLed1.GetRowsNumber()}]//doesn't work
-get a columns of led by the columns [value from 0 to {MatrixLed1.GetColumnsNumber()}]//doesn't work

THERMOSTAT COMANDS
- turn on/off thermostat
- increase thermostat1 setpoint temperature [number of clicks]
- decrease thermostat1 setpoint temperature [number of clicks]
- display current temperature

AIRCONDITIONER COMANDS
- turn on/off air conditioner1
- start/stop air conditioner1

AIRFRYER COMANDS
- start/stop air fryer1

CCTV COMANDS
- turn on/off cameras
- start/stop cameras recording
- save cameras

DOOR COMANDS
- lock/unlock the door1
";
            do
            {
                //Command Processing
                Console.WriteLine(CommandsList);
                string commandInput = Console.ReadLine().ToLower();

                CommandsHandler.Process(commandInput);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            } while (true);
        }
    }
}
