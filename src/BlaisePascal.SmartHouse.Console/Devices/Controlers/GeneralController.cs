using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Illumination.Lamps;
using BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Illumination.Leds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Console.Devices.Controlers
{
    public class GeneralController
    {
        ILampRepository _lampRepository = new CsvLampRepository();
        LampController LampController;
        ILedRepository _ledRrepository = new CsvLedRepository();
        LedController LedController;

        public GeneralController() 
        {
            LampController = new LampController(_lampRepository);
            LedController = new LedController(_ledRrepository);
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
                System.Console.WriteLine("1) Add a led");
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
    }
}
