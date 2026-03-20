using BlaisePascal.SmartHouse.Application.Devices.HomeAppliances.AirConditioners.Queries;
using BlaisePascal.SmartHouse.Application.Devices.HomeAppliances.AIrConditioners.Commands;
using BlaisePascal.SmartHouse.Domain.HomeAppliances;
using BlaisePascal.SmartHouse.Domain.HomeAppliances.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Temperature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Console.Devices.Controlers.HomeAppliance
{
    public class AirConditionerController
    {
        private readonly IAirConditionerRepository _repository;
        private GetAllAirConditionersQuery _query;

        public AirConditionerController(IAirConditionerRepository repository)
        {
            _repository = repository;
            _query = new GetAllAirConditionersQuery(_repository);
        }

        // Add new airconditioner obj to a specific repo
        public void AddAirConditioner()
        {
            System.Console.Write("AirConditioner name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }

            new AddAirConditionerCommand(_repository).Execute(Name.From(name));
            System.Console.WriteLine("!AirConditioner added!");
        }

        // Remove an airconditioner obj from a specific repo
        public void RemoveAirConditioner()
        {
            System.Console.Write("AirConditioner name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }

            List<AirConditioner> list = _query.Execute();
            foreach (AirConditioner ac in list)
            {
                if (name == ac.Name.Value || name == ac.Id.ToString())
                {
                    new RemoveAirConditionerCommand(_repository).Execute(ac.Id);
                    System.Console.WriteLine($"!AirConditioner {ac.Name.Value} removed!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
        }

        // Turn on the airconditioner selected
        public void SwitchOn()
        {
            System.Console.Write("AirConditioner name: ");
            string name = System.Console.ReadLine();

            List<AirConditioner> acs = _query.Execute();
            foreach (AirConditioner airConditioner in acs)
            {
                if (name == airConditioner.Name.Value)
                {
                    new SwitchAirConditionerOnCommand(_repository).Execute(airConditioner.Id);
                    System.Console.WriteLine($"!AirConditioner {airConditioner.Name.Value} switched on!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
        }

        // Turn off the airconditioner selected
        public void SwitchOff()
        {
            System.Console.Write("AirConditioner name: ");
            string name = System.Console.ReadLine();

            List<AirConditioner> acs = _query.Execute();
            foreach (AirConditioner airConditioner in acs)
            {
                if (name == airConditioner.Name.Value)
                {
                    new SwitchAirConditionerOffCommand(_repository).Execute(airConditioner.Id);
                    System.Console.WriteLine($"!AirConditioner {airConditioner.Name.Value} switched off!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
        }

        // Start the air conditioning process
        public async Task StartAirConditioner()
        {
            System.Console.Write("AirConditioner name: ");
            string name = System.Console.ReadLine();
            List<AirConditioner> acs = _query.Execute();
            foreach (AirConditioner airConditioner in acs)
            {
                if (name == airConditioner.Name.Value)
                {
                    System.Console.Write("Air Type (Cool, Heat, Fan, auto, Dry): ");
                    string typeStr = System.Console.ReadLine();
                    var type = (AirConditioner.AirTypeList)Enum.Parse(typeof(AirConditioner.AirTypeList), typeStr, true);

                    System.Console.Write("Temperature [float]: ");
                    float tempVal = float.Parse(System.Console.ReadLine());

                    System.Console.Write("Speed [int]: ");
                    byte speedVal = byte.Parse(System.Console.ReadLine());
                    await new StartAirConditionerCommand(_repository).Execute(airConditioner.Id, type, tempVal, speedVal);
                    System.Console.WriteLine($"!AirConditioner {airConditioner.Name.Value} started!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
        }

        public void ShowAllAirConditioners()
        {
            List<AirConditioner> list = _query.Execute();
            System.Console.WriteLine("----------AIR CONDITIONERS----------");
            foreach (AirConditioner ac in list)
            {
                System.Console.WriteLine($"Name: {ac.Name.Value}");
                System.Console.WriteLine($"ID: {ac.Id}");
                System.Console.WriteLine($"State: {(ac.IsOn ? "On" : "Off")}");
                System.Console.WriteLine($"Mode: {ac.AirType}");
                System.Console.WriteLine($"Temp: {(ac.Temperature != null ? ac.Temperature.Value.ToString() : "N/A")}");
                System.Console.WriteLine($"Speed: {(ac.Speed != null ? ac.Speed.Value.ToString() : "N/A")}");
                System.Console.WriteLine($"Creation: {ac.Creation}");
                System.Console.WriteLine($"Last Modify: {ac.LastModified}");
                System.Console.WriteLine();
            }
        }
    } 
}

