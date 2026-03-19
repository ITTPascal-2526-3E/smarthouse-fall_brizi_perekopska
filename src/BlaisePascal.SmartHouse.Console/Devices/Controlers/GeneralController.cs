using BlaisePascal.SmartHouse.Application.Devices.Security.CCTVs.Queries;
using BlaisePascal.SmartHouse.Console.Devices.Controlers.Illumination;
using BlaisePascal.SmartHouse.Console.Devices.Controlers.Security;
using BlaisePascal.SmartHouse.Console.Devices.Controlers.Temperature;
using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using BlaisePascal.SmartHouse.Domain.Temperature;
using BlaisePascal.SmartHouse.Domain.Temperature.Repositories;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Illumination.Lamps;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Illumination.Leds;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Security.CCTVs;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Security.Doors;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Temperature.Thermostats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Console.Devices.Controlers
{
    public class GeneralController
    {
        private ILampRepository _lampRepository = new CsvLampRepository();
        private LampController LampController;
        private ILedRepository _ledRrepository = new CsvLedRepository();
        private LedController LedController;
        private ICCTVRepository _cctvRepository = new CsvCCTVRepository();
        private CCTVController CCTVController;
        private IDoorRepository _doorRepository= new CsvDoorRepository();
        private DoorController DoorController;
        private IThermostatRepository _thermostatRepository = new CsvThermostatRepository();
        private ThermostatController ThermostatController;


        public GeneralController() 
        {
            LampController = new LampController(_lampRepository);
            LedController = new LedController(_ledRrepository);
            CCTVController=new CCTVController(_cctvRepository);
            DoorController = new DoorController(_doorRepository);
            ThermostatController= new ThermostatController(_thermostatRepository);
        }

        public void Lamps() 
        {
            do
            {
                LampController.ShowAllLamps();
                System.Console.WriteLine();
                System.Console.WriteLine("Lamp name: ");
                System.Console.WriteLine("Commands:");
                System.Console.WriteLine("1) Add a lamp");
                System.Console.WriteLine("2) Remove a Lamp");
                System.Console.WriteLine("3) Turn On");
                System.Console.WriteLine("4) Turn Off");
                System.Console.WriteLine("5) Change Brightness");
                System.Console.WriteLine("6) Change Color");
                System.Console.WriteLine("0) Exit");
                System.Console.WriteLine("Choosing: ");

                string action = System.Console.ReadLine();
                switch (action)
                {
                    case "0":
                        return;
                    case "1":
                        LampController.AddLamp();
                        break;
                    case "2":
                        LampController.RemoveLamp();
                        break;
                    case "3":
                        LampController.SwitchOn();
                        break;
                    case "4":
                        LampController.SwitchOff();
                        break;
                    case "5":
                        LampController.ChangeBrightness();
                        break;
                    case "6":
                        LampController.ChangeColor();
                        break;
                    default:
                        System.Console.WriteLine("Invalid option");
                        break;
                }
                System.Console.Clear();

            } while (true);
        }

        public void Leds()
        {
            do
            {
                LedController.ShowAllLeds();
                System.Console.WriteLine();
                System.Console.WriteLine("Led name: ");
                System.Console.WriteLine("Commands:");
                System.Console.WriteLine("1) Add a Led");
                System.Console.WriteLine("2) Remove a Led");
                System.Console.WriteLine("3) Turn On");
                System.Console.WriteLine("4) Turn Off");
                System.Console.WriteLine("5) Change Brightness");
                System.Console.WriteLine("6) Change Color");
                System.Console.WriteLine("0) Exit");
                System.Console.WriteLine("Choosing: ");

                string action = System.Console.ReadLine();
                switch (action)
                {
                    case "0":
                        return;
                    case "1":
                        LedController.AddLed();
                        break;
                    case "2":
                        LedController.RemoveLed();
                        break;
                    case "3":
                        LedController.SwitchOn();
                        break;
                    case "4":
                        LedController.SwitchOff();
                        break;
                    case "5":
                        LedController.ChangeBrightness();
                        break;
                    case "6":
                        LedController.ChangeColor();
                        break;
                    default:
                        System.Console.WriteLine("Invalid option");
                        break;
                }
                System.Console.Clear();

            } while (true);
        }
        public void CCTVs()
        {
            do
            {
                CCTVController.ShowAllCCTVs();
                System.Console.WriteLine();
                System.Console.WriteLine("CCTV name: ");
                System.Console.WriteLine("Commands:");
                System.Console.WriteLine("1) Add a CCTV");
                System.Console.WriteLine("2) Remove a CCTV");
                System.Console.WriteLine("3) Turn On");
                System.Console.WriteLine("4) Turn Off");
                System.Console.WriteLine("5) Start Recording");
                System.Console.WriteLine("6) Stop Recording");
                System.Console.WriteLine("7) Save The Screen");
                System.Console.WriteLine("0) Exit");
                System.Console.WriteLine("Choosing: ");

                string action = System.Console.ReadLine();
                switch (action)
                {
                    case "0":
                        return;
                    case "1":
                        CCTVController.AddCCTV();
                        break;
                    case "2":
                        CCTVController.RemoveCCTV();
                        break;
                    case "3":
                        CCTVController.SwitchOn();
                        break;
                    case "4":
                        CCTVController.SwitchOff();
                        break;
                    case "5":
                        CCTVController.StartRecording();
                        break;
                    case "6":
                        CCTVController.StopRecording();
                        break;
                    case "7":
                        CCTVController.SaveScreen();
                        break;
                    default:
                        System.Console.WriteLine("Invalid option");
                        break;
                }
                System.Console.Clear();

            } while (true);
        }
        public void Doors()
        {
            do
            {
                DoorController.ShowAllDoors();
                System.Console.WriteLine();
                System.Console.WriteLine("Door name: ");
                System.Console.WriteLine("Commands:");
                System.Console.WriteLine("1) Add a Door");
                System.Console.WriteLine("2) Remove a Door");
                System.Console.WriteLine("3) Lock");
                System.Console.WriteLine("4) Unlock");
                System.Console.WriteLine("0) Exit");
                System.Console.WriteLine("Choosing: ");

                string action = System.Console.ReadLine();
                switch (action)
                {
                    case "0":
                        return;
                    case "1":
                        DoorController.AddDoor();
                        break;
                    case "2":
                        DoorController.RemoveDoor();
                        break;
                    case "3":
                        DoorController.Lock();
                        break;
                    case "4":
                        DoorController.Unlock();
                        break;
                    default:
                        System.Console.WriteLine("Invalid option");
                        break;
                }
                System.Console.Clear();

            } while (true);
        }
        public void Thermostats()
        {
            do
            {
                ThermostatController.ShowAllThermostats();
                System.Console.WriteLine();
                System.Console.WriteLine("Thermostat name: ");
                System.Console.WriteLine("Commands:");
                System.Console.WriteLine("1) Add a Thermostat");
                System.Console.WriteLine("2) Remove a Thermostat");
                System.Console.WriteLine("3) Turn On");
                System.Console.WriteLine("4) Turn Off");
                System.Console.WriteLine("5) Increase Setpoint Temperature");
                System.Console.WriteLine("6) Decrease Setpoint Temperature");
                System.Console.WriteLine("7) Raise Current Temperature");
                System.Console.WriteLine("0) Exit");
                System.Console.WriteLine("Choosing: ");

                string action = System.Console.ReadLine();
                switch (action)
                {
                    case "0":
                        return;
                    case "1":
                        ThermostatController.AddThermostat();
                        break;
                    case "2":
                        ThermostatController.RemoveThermostat();
                        break;
                    case "3":
                        ThermostatController.SwitchOn();
                        break;
                    case "4":
                        ThermostatController.SwitchOff();
                        break;
                    case "5":
                        ThermostatController.IncreaseSetpointTemperature();
                        break;
                    case "6":
                        ThermostatController.DecreaseSetpointTemperature();
                        break;
                    case "7":
                        ThermostatController.RaiseCurrentTemperatureTemperature();
                        break;
                    default:
                        System.Console.WriteLine("Invalid option");
                        break;
                }
                System.Console.Clear();

            } while (true);
        }
    }
}
