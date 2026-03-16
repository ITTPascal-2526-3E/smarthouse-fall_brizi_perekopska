using BlaisePascal.SmartHouse.Domain.HomeAppliances;
using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Temperature;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Illumination;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Temperature;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Time;
using BlaisePascal.SmartHouse.Application.Devices.Illumination.Lamps.Queries;
using BlaisePascal.SmartHouse.Application.Devices.Illumination.Lamps.Commands;
using BlaisePascal.SmartHouse.Console.Devices.Controlers;
using System;
using System.Threading;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Illumination.Lamps;

namespace BlaisePascal.SmartHouse.Domain
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Illumination Devices
            Lamp Lamp1 = new Lamp(Name.From("porta"),false, Brightness.From(100), Color.From(100, 10, 50), "LED", new Time(Hour.From(23), Minutes.From(23), Seconds.From(23)), new Time(Hour.From(10), Minutes.From(10), Seconds.From(12)));
            EcoLamp EcoLamp1 = new EcoLamp(Name.From("portaEco"),false, EcoBrightness.From(56), "EcoLED", new Time(Hour.From(10), Minutes.From(00),Seconds.From( 00)), new Time(Hour.From(12), Minutes.From(00), Seconds.From(00)), new Time(Hour.From(00), Minutes.From(00), Seconds.From(16)));
            TwoLampDevice TwoLampDevice1 = new TwoLampDevice(Lamp1, EcoLamp1);
            MatrixLed MatrixLed1 = new MatrixLed(2,3);
            //Temperature Devices
            Thermostat Thermostat1 = new Thermostat(Name.From("Thermostat1"), true, ThermostatTemperature.From(19.5f), ThermostatTemperature.From(23.5f));
            //Home Appliances
            AirConditioner AirConditioner1 = new AirConditioner(Name.From("AirConditioner1"), true);
            AirFryer AirFryer1 = new AirFryer(Name.From("AirFryer1"), true);
            //Security Devices
            CCTV Cameras = new CCTV(Name.From("Cameras"), true, false, true);
            Door Door1 = new Door(new Guid(),true);
            //Commands Handler
            CommandsHandler CommandsHandler = new CommandsHandler(Lamp1, EcoLamp1, TwoLampDevice1, Thermostat1, AirConditioner1, AirFryer1, Cameras, Door1, MatrixLed1);
            ILampRepository _repository = new CsvLampRepository();
            LampController Controller = new LampController(_repository);
            /*
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
";*/
            do
            {
                Controller.ShowAllLamps();
                System.Console.Write("Lamp name: ");
                System.Console.WriteLine("Commands:");
                System.Console.WriteLine("1) Add a lamp");
                System.Console.WriteLine("2) Remove a Lamp");
                System.Console.WriteLine("3) Turn On");
                System.Console.WriteLine("4) Turn Off");
                System.Console.WriteLine("5) Change Brightness");
                System.Console.WriteLine("6) Change Color");
                System.Console.WriteLine("0) Exit");
                System.Console.Write("Choose: ");

                int action=Convert.ToInt32(System.Console.ReadLine());
                switch (action) 
                {
                    case 0:
                        break;
                    case 1:
                        Controller.AddLamp();
                        break;
                    case 2:
                        Controller.RemoveLamp();
                        break;
                    case 3:
                        Controller.SwitchOn();
                        break;
                    case 4:
                        Controller.SwitchOff();
                        break;
                    case 5:
                        Controller.ChangeBrightness();
                        break;
                    case 6:
                        Controller.ChangeColor();
                        break;
                    default:
                        System.Console.WriteLine("Invalid option");
                        await Task.Delay(5000);
                        break;
                }
                System.Console.Clear();

            } while (true);
        }
    }
}
