using BlaisePascal.SmartHouse.Application.Devices.Illumination.Leds.Commands;
using BlaisePascal.SmartHouse.Application.Devices.Illumination.Leds.Queries;
using BlaisePascal.SmartHouse.Application.Devices.Temerature.Thermostat.Commands;
using BlaisePascal.SmartHouse.Application.Devices.Temerature.Thermostats.Queries;
using BlaisePascal.SmartHouse.Application.Devices.Temerature.Thrmostats.Commands;
using BlaisePascal.SmartHouse.Application.Devices.Temperature.Thermostats.Commands;
using BlaisePascal.SmartHouse.Application.Devices.Temperature.Thermostats.Coomands;
using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using BlaisePascal.SmartHouse.Domain.Temperature;
using BlaisePascal.SmartHouse.Domain.Temperature.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Console.Devices.Controlers.Temperature
{
    public class ThermostatController
    {
        private readonly IThermostatRepository _repository;
        private GetAllThermostatsQuery _query;
        public ThermostatController(IThermostatRepository repository)
        {
            _repository = repository;
            _query = new GetAllThermostatsQuery(_repository);
        }


        //Add new thermostat obj to a specific repo
        public void AddThermostat()
        {
            System.Console.Write("Thermostat name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }

            new AddThermostatCommand(_repository).Execute(Name.From(name));
            System.Console.WriteLine("!Thermostat added!");
            return;
        }

        //Remove a thermostat obj from a specific repo
        public void RemoveThermostat()
        {
            System.Console.Write("Thermostat name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }
            List<Thermostat> list = _query.Execute();
            foreach (Thermostat thermostat in list)
            {
                if (name == thermostat.Name.Value)
                {
                    new RemoveThermostatCommand(_repository).Execute(thermostat.Id);
                    System.Console.WriteLine("!Thermostat removed!");
                    return;
                }
                if (name == thermostat.Id.ToString())
                {
                    new RemoveThermostatCommand(_repository).Execute(thermostat.Id);
                    System.Console.WriteLine($"!Thermostat {thermostat.Name.Value} removed!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }

        //Turn on the thermostat selected
        public void SwitchOn()
        {
            System.Console.Write("Thermostat name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }
            List<Thermostat> list = _query.Execute();
            foreach (Thermostat thermostat in list)
            {
                if (name == thermostat.Name.Value && thermostat.IsOn == false)
                {
                    new SwitchThermostatOnCommand(_repository).Execute(thermostat.Id);
                    System.Console.WriteLine($"!Thermostat  {thermostat.Name.Value} switched on!");
                    return;
                }
                if (name == thermostat.Id.ToString() && thermostat.IsOn == false)
                {
                    new SwitchThermostatOnCommand(_repository).Execute(thermostat.Id);
                    System.Console.WriteLine($"!Thermostat  {thermostat.Name.Value} switched on!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }
        //Turn off the thermostat selected
        public void SwitchOff()
        {
            System.Console.Write("Thermostat name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }
            List<Thermostat> list = _query.Execute();
            foreach (Thermostat thermostat in list)
            {
                if (name == thermostat.Name.Value && thermostat.IsOn == true)
                {
                    new SwitchThermostatOffCommand(_repository).Execute(thermostat.Id);
                    System.Console.WriteLine($"!Thermostat   {thermostat.Name.Value} switched off!");
                    return;
                }
                if (name == thermostat.Id.ToString() && thermostat.IsOn == true)
                {
                    new SwitchThermostatOffCommand(_repository).Execute(thermostat.Id);
                    System.Console.WriteLine($"!Thermostat   {thermostat.Name.Value}!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }
        //Increase the setpoint temperature to the thermostat selected
        public void IncreaseSetpointTemperature()
        {
            System.Console.Write("Thermostat name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }
            System.Console.Write("Clicks to set: ");
            byte quantity = Convert.ToByte(System.Console.ReadLine());
            List<Thermostat> list = _query.Execute();
            foreach (Thermostat thermostat in list)
            {
                if (name == thermostat.Name.Value && thermostat.IsOn == true)
                {
                    new IncreaseSetpointTemperatureCommand(_repository).Execute(thermostat.Id, quantity);
                    System.Console.WriteLine($"!Thermostat {thermostat.Name.Value} increased setpoint temperature!");
                    return;
                }
                if (name == thermostat.Id.ToString() && thermostat.IsOn == true)
                {
                    new IncreaseSetpointTemperatureCommand(_repository).Execute(thermostat.Id, quantity);
                    System.Console.WriteLine($"!Thermostat  {thermostat.Name.Value} increased setpoint temperature !");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }
        //Decrease the setpoint temperature to the thermostat selected
        public void DecreaseSetpointTemperature()
        {
            System.Console.Write("Thermostat name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }
            System.Console.Write("Clicks to set: ");
            byte quantity = Convert.ToByte(System.Console.ReadLine());
            List<Thermostat> list = _query.Execute();
            foreach (Thermostat thermostat in list)
            {
                if (name == thermostat.Name.Value && thermostat.IsOn == true)
                {
                    new DecreaseSetpointTemperatureCommand(_repository).Execute(thermostat.Id, quantity);
                    System.Console.WriteLine($"!Thermostat {thermostat.Name.Value} decreased setpoint temperature!");
                    return;
                }
                if (name == thermostat.Id.ToString() && thermostat.IsOn == true)
                {
                    new DecreaseSetpointTemperatureCommand(_repository).Execute(thermostat.Id, quantity);
                    System.Console.WriteLine($"!Thermostat  {thermostat.Name.Value} decreased setpoint temperature!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }
        //Decrease the setpoint temperature to the thermostat selected
        public void RaiseCurrentTemperatureTemperature()
        {
            System.Console.Write("Thermostat name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }
            List<Thermostat> list = _query.Execute();
            foreach (Thermostat thermostat in list)
            {
                if (name == thermostat.Name.Value && thermostat.IsOn == true)
                {
                    new RaiseCurrentTemperatureCommand(_repository).Execute(thermostat.Id);
                    System.Console.WriteLine($"!Thermostat {thermostat.Name.Value} raised temperature!");
                    return;
                }
                if (name == thermostat.Id.ToString() && thermostat.IsOn == true)
                {
                    new RaiseCurrentTemperatureCommand(_repository).Execute(thermostat.Id);
                    System.Console.WriteLine($"!Thermostat  {thermostat.Name.Value} raised temperature!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }

        public void ShowAllThermostats()
        {
            List<Thermostat> list = _query.Execute();
            System.Console.WriteLine("----------Thermostats----------");
            foreach (Thermostat thermostat in list)
            {
                System.Console.WriteLine($"Thermostat name: {thermostat.Name.Value}");
                System.Console.WriteLine($"Thermostat id: {thermostat.Id.ToString()}");
                System.Console.WriteLine($"Thermostat state: {(thermostat.IsOn ? "On" : "Off")}");
                System.Console.WriteLine($"Thermostat Setpoint Temperature: {thermostat.SetpointTemperature.Value}");
                System.Console.WriteLine($"Thermostat Current Temperature: {thermostat.CurrentTemperature.Value}");
                System.Console.WriteLine($"Creation time: {thermostat.Creation}");
                System.Console.WriteLine($"Last modified time: {thermostat.LastModified}");
                System.Console.WriteLine();
            }
            return;
        }
    }
}
