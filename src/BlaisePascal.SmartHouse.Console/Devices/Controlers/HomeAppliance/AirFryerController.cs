using BlaisePascal.SmartHouse.Application.Devices.HomeAppliances.AirFryers.Commands;
using BlaisePascal.SmartHouse.Application.Devices.HomeAppliances.AirFryers.Queries;
using BlaisePascal.SmartHouse.Domain.HomeAppliances;
using BlaisePascal.SmartHouse.Domain.HomeAppliances.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Console.Devices.Controlers.HomeAppliance
{
    public class AirFryerController
    {
        private readonly IAirFryerRepository _repository;
        private GetAllAirFryersQuery _query;

        public AirFryerController(IAirFryerRepository repository)
        {
            _repository = repository;
            _query = new GetAllAirFryersQuery(_repository);
        }

        // Add new airfryer obj to a specific repo
        public void AddAirFryer()
        {
            System.Console.Write("AirFryer name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }

            new AddAirFryerCommand(_repository).Execute(Name.From(name));
            System.Console.WriteLine("!AirFryer added!");
        }

        // Remove an airfryer obj from a specific repo
        public void RemoveAirFryer()
        {
            System.Console.Write("AirFryer name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }

            List<AirFryer> list = _query.Execute();
            foreach (AirFryer af in list)
            {
                if (name == af.Name.Value || name == af.Id.ToString())
                {
                    new RemoveAirFryerCommand(_repository).Execute(af.Id);
                    System.Console.WriteLine($"!AirFryer {af.Name.Value} removed!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
        }

        // Turn on the airfryer selected
        public void SwitchOn()
        {
            System.Console.Write("AirFryer name: ");
            string name = System.Console.ReadLine();

            List<AirFryer> af = _query.Execute();
            foreach (AirFryer airFryer in af)
                if (name == airFryer.Name.Value && airFryer.IsOn == false)
                {
                    new SwitchAirFryerOnCommand(_repository).Execute(airFryer.Id);
                    System.Console.WriteLine($"!AirFryer {airFryer.Name.Value} switched on!");
                    return;
                }
            System.Console.WriteLine("Name not valid");
        }

        // Turn off the airfryer selected
        public void SwitchOff()
        {
            System.Console.Write("AirFryer name: ");
            string name = System.Console.ReadLine();

            List<AirFryer> af = _query.Execute();
            foreach (AirFryer airFryer in af)
                if (name == airFryer.Name.Value && airFryer.IsOn == true)
                {
                    new SwitchAirFryerOffCommand(_repository).Execute(airFryer.Id);
                    System.Console.WriteLine($"!AirFryer {airFryer.Name.Value} switched on!");
                    return;
                }
            System.Console.WriteLine("Name not valid");
        }

        // Start the cooking process
        public async Task StartCooking()
        {
            System.Console.Write("AirFryer name: ");
            string name = System.Console.ReadLine();
            List<AirFryer> af = _query.Execute();
            foreach (AirFryer airFryer in af)
            {
                if (name == airFryer.Name.Value && airFryer.IsOn == true)
                {
                    System.Console.Write("Cooking Type (e.g. Fryed, Pizza): ");
                    string typeStr = System.Console.ReadLine();
                    var type = (AirFryer.CookingType)Enum.Parse(typeof(AirFryer.CookingType), typeStr, true);

                    System.Console.Write("Temperature [byte]: ");
                    byte temp = Convert.ToByte(System.Console.ReadLine());

                    System.Console.Write("Timer - Hours: ");
                    byte h = Convert.ToByte(System.Console.ReadLine());
                    System.Console.Write("Timer - Minutes: ");
                    byte m = Convert.ToByte(System.Console.ReadLine());
                    System.Console.Write("Timer - Seconds: ");
                    byte s = Convert.ToByte(System.Console.ReadLine());

                    await new StartTheCookingCommand(_repository).Execute(airFryer.Id, type, temp, h, m, s);
                    System.Console.WriteLine($"!AirFryer {airFryer.Name.Value} cooking started!");
                    return;

                }
                System.Console.WriteLine("Name not valid");
                return;



            }
        }

        // Stop the cooking process
        public void StopCooking()
        {
            System.Console.Write("AirFryer name: ");
            string name = System.Console.ReadLine();
            List<AirFryer> af = _query.Execute();
            foreach (AirFryer airFryer in af)
            {
                if (name == airFryer.Name.Value && airFryer.IsOn == true)
                {

                    new StopTheCookingCommand(_repository).Execute(airFryer.Id);
                    System.Console.WriteLine($"!AirFryer {airFryer.Name.Value} cooking stopped!");
                    return;

                }
            }
            System.Console.WriteLine("Name not valid");
        }

        public void ShowAllAirFryers()
        {
            List<AirFryer> list = _query.Execute();
            System.Console.WriteLine("----------AIR FRYERS----------");
            foreach (AirFryer af in list)
            {
                System.Console.WriteLine($"Name: {af.Name.Value}");
                System.Console.WriteLine($"ID: {af.Id}");
                System.Console.WriteLine($"State: {(af.IsOn ? "On" : "Off")}");
                System.Console.WriteLine($"Last Method: {af.LastCookingMethod}");
                System.Console.WriteLine($"Creation: {af.Creation}");
                System.Console.WriteLine($"Last MOdify: {af.LastModified}");
                System.Console.WriteLine();
            }
        }
    }
}
