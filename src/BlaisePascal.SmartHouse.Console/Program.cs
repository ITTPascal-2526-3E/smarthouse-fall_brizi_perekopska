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
            GeneralController Controller = new GeneralController();
           
            do
            {
                System.Console.WriteLine();
                System.Console.WriteLine("-----DEVICES-----");
                System.Console.WriteLine("Choose a device:");
                System.Console.WriteLine("1- Lamp  ");
                System.Console.WriteLine("2- Led");
                System.Console.WriteLine("3- CCTV");
                System.Console.WriteLine("4- Door");
                System.Console.WriteLine("5- Thermostat");
								System.Console.WriteLine("6- AirConditioner");
								System.Console.WriteLine("7- AirFryer");
                System.Console.WriteLine("0) Exit");
                System.Console.WriteLine("Choosing: ");

                string action=System.Console.ReadLine();
                switch (action) 
                {
                    case "0":
                        return;
                    case "1":
                        Controller.Lamps();
                        break;
                    case "2":
                        Controller.Leds();
                        break;
                    case "3":
                        Controller.CCTVs();
                        break;
                    case "4":
                        Controller.Doors();
                        break;
                    case "5":
                        Controller.Thermostats();
                        break;
										case "6":
                        Controller.AirConditioners();
                        break;
                    case "7":
                        Controller.AirFryers();
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
