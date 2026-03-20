using BlaisePascal.SmartHouse.Application.Devices.Illumination.Lamps.Commands;
using BlaisePascal.SmartHouse.Application.Devices.Illumination.Lamps.Queries;
using BlaisePascal.SmartHouse.Application.Devices.Illumination.Leds.Commands;
using BlaisePascal.SmartHouse.Application.Devices.Illumination.Leds.Queries;
using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Console.Devices.Controlers.Illumination
{
    public class LedController
    {
        private readonly ILedRepository _repository;
        private GetAllLedQuery _query;
        public LedController(ILedRepository repository)
        {
            _repository = repository;
            _query = new GetAllLedQuery(_repository);
        }


        //Add new led obj to a specific repo
        public void AddLed()
        {
            System.Console.Write("Led name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }

            new AddLedCommand(_repository).Execute(Name.From(name));
            System.Console.WriteLine("!Led added!");
            return;
        }

        //Remove a led obj from a specific repo
        public void RemoveLed()
        {
            System.Console.Write("Led name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }
            List<Led> list = _query.Execute();
            foreach (Led led in list)
            {
                if (name == led.Name.Value)
                {
                    new RemoveLedCommand(_repository).Execute(led.Id);
                    System.Console.WriteLine("!Led removed!");
                    return;
                }
                if (name == led.Id.ToString())
                {
                    new RemoveLedCommand(_repository).Execute(led.Id);
                    System.Console.WriteLine($"!Led {led.Name.Value} removed!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }

        //Turn on the led selected
        public void SwitchOn()
        {
            System.Console.Write("Led name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }
            List<Led> list = _query.Execute();
            foreach (Led led in list)
            {
                if (name == led.Name.Value && led.IsOn == false)
                {
                    new SwitchLedOnCommand(_repository).Execute(led.Id);
                    System.Console.WriteLine($"!Led {led.Name.Value} switched on!");
                    return;
                }
                if (name == led.Id.ToString() && led.IsOn == false)
                {
                    new SwitchLedOnCommand(_repository).Execute(led.Id);
                    System.Console.WriteLine($"!Led {led.Name.Value} switched on!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }
        //Turn off the led selected
        public void SwitchOff()
        {
            System.Console.Write("Led name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }
            List<Led> list = _query.Execute();
            foreach (Led led in list)
            {
                if (name == led.Name.Value && led.IsOn == true)
                {
                    new SwitchLedOffCommand(_repository).Execute(led.Id);
                    System.Console.WriteLine($"!Led {led.Name.Value} switched off!");
                    return;
                }
                if (name == led.Id.ToString() && led.IsOn == true)
                {
                    new SwitchLedOffCommand(_repository).Execute(led.Id);
                    System.Console.WriteLine($"!Led {led.Name.Value}!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }
        //Turn on the led selected
        public void ChangeBrightness()
        {
            System.Console.Write("Led name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }
            System.Console.Write("Brightness to set[0-100]: ");
            byte quantity = Convert.ToByte(System.Console.ReadLine());
            List<Led> list = _query.Execute();
            foreach (Led led in list)
            {
                if (name == led.Name.Value && led.IsOn == true)
                {
                    new ChangeLedBrightnessCommand(_repository).Execute(led.Id, quantity);
                    System.Console.WriteLine($"!Led {led.Name.Value} Brightness changed!");
                    return;
                }
                if (name == led.Id.ToString() && led.IsOn == true)
                {
                    new ChangeLedBrightnessCommand(_repository).Execute(led.Id, quantity);
                    System.Console.WriteLine($"!Led {led.Name.Value} brightness changed!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }
        //Change color to the lamp selected
        public void ChangeColor()
        {
            System.Console.Write("Led name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }
            System.Console.Write("Red to set[0-255]: ");
            byte r = Convert.ToByte(System.Console.ReadLine());
            System.Console.Write("Green to set[0-255]: ");
            byte g = Convert.ToByte(System.Console.ReadLine());
            System.Console.Write("Blue to set[0-255]: ");
            byte b = Convert.ToByte(System.Console.ReadLine());
            List<Led> list = _query.Execute();
            foreach (Led led in list)
            {
                if (name == led.Name.Value && led.IsOn == true)
                {
                    new ChangeLedColorCommand(_repository).Execute(led.Id, r, g, b);
                    System.Console.WriteLine($"!Led  {led.Name.Value} color changed!");
                    return;
                }
                if (name == led.Id.ToString() && led.IsOn == true)
                {
                    new ChangeLedColorCommand(_repository).Execute(led.Id, r, g, b);
                    System.Console.WriteLine($"!Led {led.Name.Value} color changed!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }

        public void ShowAllLeds()
        {
            List<Led> list = _query.Execute();
            System.Console.WriteLine("----------LEDS----------");
            foreach (Led led in list)
            {
                System.Console.WriteLine($"Led name: {led.Name.Value}");
                System.Console.WriteLine($"Led id: {led.Id.ToString()}");
                System.Console.WriteLine($"Led state: {led.IsOn}");
                System.Console.WriteLine($"Led brightness: {led.Brightness.Value}");
                System.Console.WriteLine($"Led color: {led.Color.R}, {led.Color.G}, {led.Color.B}");
                System.Console.WriteLine($"Creation time: {led.Creation}");
                System.Console.WriteLine($"Last modified time: {led.LastModified}");
                System.Console.WriteLine();
            }
            return;
        }
    }
}
