using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Application.Devices.Illumination.Lamps.Commands;
using BlaisePascal.SmartHouse.Application.Devices.Illumination.Lamps.Queries;

namespace BlaisePascal.SmartHouse.Console.Devices.Controlers
{
    public class LampController
    {
        private readonly ILampRepository _repository;
        private GetAllLampQuery _query;
        public LampController(ILampRepository repository)
        {
            _repository = repository;
            _query=new GetAllLampQuery(_repository);
        }


        //Add new lamp obj to a specific repo
        public void AddLamp() 
        {
            System.Console.Write("Lamp name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name)) 
            {
                System.Console.WriteLine("Name not valid");
                return;
            }

            new AddLampCommand(_repository).Execute(Name.From(name));
            System.Console.WriteLine("!Lamp added!");
            return;
        }

        //Remove a lamp obj from a specific repo
        public void RemoveLamp()
        {
            System.Console.Write("Lamp name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            } 
            List<Lamp> list =  _query.Execute();
            foreach (Lamp lamp in list) 
            {
                if (name == lamp.Name.Value) 
                {
                    new RemoveLampCommand(_repository).Execute(lamp.Id);
                    System.Console.WriteLine("!Lamp removed!");
                    return;
                }
                if (name == lamp.Id.ToString())
                {
                    new RemoveLampCommand(_repository).Execute(lamp.Id);
                    System.Console.WriteLine($"!Lamp {lamp.Name.Value} removed!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }

        //Turn on the lamp selected
        public void SwitchOn()
        {
            System.Console.Write("Lamp name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }
            List<Lamp> list = _query.Execute();
            foreach (Lamp lamp in list)
            {
                if (name == lamp.Name.Value)
                {
                    new SwitchLampOnCommand(_repository).Execute(lamp.Id);
                    System.Console.WriteLine($"!Lamp {lamp.Name.Value} switched on!");
                    return;
                }
                if (name == lamp.Id.ToString())
                {
                    new SwitchLampOnCommand(_repository).Execute(lamp.Id);
                    System.Console.WriteLine($"!Lamp {lamp.Name.Value} switched on!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }
        //Turn off the lamp selected
        public void SwitchOff()
        {
            System.Console.Write("Lamp name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }
            List<Lamp> list = _query.Execute();
            foreach (Lamp lamp in list)
            {
                if (name == lamp.Name.Value)
                {
                    new SwitchLampOffCommand(_repository).Execute(lamp.Id);
                    System.Console.WriteLine($"!Lamp {lamp.Name.Value} switched off!");
                    return;
                }
                if (name == lamp.Id.ToString())
                {
                    new SwitchLampOffCommand(_repository).Execute(lamp.Id);
                    System.Console.WriteLine($"!Lamp {lamp.Name.Value}!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }
        //Turn on the lamp selected
        public void ChangeBrightness()
        {
            System.Console.Write("Lamp name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }
            System.Console.Write("Brightness to set[0-100]: ");
            byte quantity = Convert.ToByte(System.Console.ReadLine());
            List<Lamp> list = _query.Execute();
            foreach (Lamp lamp in list)
            {
                if (name == lamp.Name.Value)
                {
                    new ChangeBrightnessCommand(_repository).Execute(lamp.Id,quantity);
                    System.Console.WriteLine($"!Lamp {lamp.Name.Value} Brightness changed!");
                    return;
                }
                if (name == lamp.Id.ToString()) 
                {
                    new ChangeBrightnessCommand(_repository).Execute(lamp.Id, quantity);
                    System.Console.WriteLine($"!Lamp {lamp.Name.Value} brightness changed!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }
        //Change color to the lamp selected
        public void ChangeColor()
        {
            System.Console.Write("Lamp name: ");
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
            List<Lamp> list = _query.Execute();
            foreach (Lamp lamp in list)
            {
                if (name == lamp.Name.Value)
                {
                    new ChangeColorCommand(_repository).Execute(lamp.Id, r, g, b);
                    System.Console.WriteLine($"!Lamp {lamp.Name.Value} color changed!");
                    return;
                }
                if (name == lamp.Id.ToString())
                {
                    new ChangeColorCommand(_repository).Execute(lamp.Id, r, g, b);
                    System.Console.WriteLine($"!Lamp {lamp.Name.Value} color changed!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }

        public void ShowAllLamps() 
        {
            List<Lamp> list = _query.Execute();
            System.Console.WriteLine("----------LAMPS----------");
            foreach (Lamp lamp in list)
            {
                System.Console.WriteLine($"Lamp name: {lamp.Name.Value}");
                System.Console.WriteLine($"Lamp id: {lamp.Id.ToString()}");
                System.Console.WriteLine($"Lamp state: {lamp.IsOn}");
                System.Console.WriteLine($"Lamp color: {lamp.Color.R}, {lamp.Color.G}, {lamp.Color.B}");
            }
            return;
        }
    }
}
