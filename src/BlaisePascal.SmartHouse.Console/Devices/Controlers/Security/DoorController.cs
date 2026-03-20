using BlaisePascal.SmartHouse.Application.Devices.Security.CCTVs.Commands;
using BlaisePascal.SmartHouse.Application.Devices.Security.CCTVs.Queries;
using BlaisePascal.SmartHouse.Application.Devices.Security.Doors.Commands;
using BlaisePascal.SmartHouse.Application.Devices.Security.Doors.Queries;
using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using BlaisePascal.SmartHouse.Domain.Temperature;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Console.Devices.Controlers.Security
{
    public class DoorController
    {
        private readonly IDoorRepository _repository;
        private GetAllDoorsQuery _query;
        public DoorController(IDoorRepository repository)
        {
            _repository = repository;
            _query = new GetAllDoorsQuery(_repository);
        }


        //Add new Door obj to a specific repo
        public void AddDoor()
        {
            System.Console.Write("Door name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }

            new AddDoorCommand(_repository).Execute(Name.From(name));
            System.Console.WriteLine("!Door added!");
            return;
        }

        //Remove a Door obj from a specific repo
        public void RemoveDoor()
        {
            System.Console.Write("Door name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }
            List<Door> list = _query.Execute();
            foreach (Door door in list)
            {
                if (name == door.Name.Value)
                {
                    new RemoveDoorCommand(_repository).Execute(door.Id);
                    System.Console.WriteLine("!Door removed!");
                    return;
                }
                if (name == door.Id.ToString())
                {
                    new RemoveDoorCommand(_repository).Execute(door.Id);
                    System.Console.WriteLine($"!Door {door.Name.Value} removed!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }

        //Lock the Door selected
        public void Lock()
        {
            System.Console.Write("Door name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }
            List<Door> list = _query.Execute();
            foreach (Door door in list)
            {
                if (name == door.Name.Value && door.IsLocked == false)
                {
                    new LockDoorCommand(_repository).Execute(door.Id);
                    System.Console.WriteLine($"!Door {door.Name.Value} looked!");
                    return;
                }
                if (name == door.Id.ToString() && door.IsLocked == false)
                {
                    new LockDoorCommand(_repository).Execute(door.Id);
                    System.Console.WriteLine($"!Door  {door.Name.Value} locked!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }
        //Unlock the Door selected
        public void Unlock()
        {
            System.Console.Write("Door name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }
            List<Door> list = _query.Execute();
            foreach (Door door in list)
            {
                if (name == door.Name.Value && door.IsLocked == true)
                {
                    new UnlockDoorCommand(_repository).Execute(door.Id);
                    System.Console.WriteLine($"!Door {door.Name.Value} unlooked!");
                    return;
                }
                if (name == door.Id.ToString() && door.IsLocked == true)
                {
                    new UnlockDoorCommand(_repository).Execute(door.Id);
                    System.Console.WriteLine($"!Door  {door.Name.Value} unlocked!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }
        public void ShowAllDoors()
        {
            List<Door> list = _query.Execute();
            System.Console.WriteLine("----------DoorS----------");
            foreach (Door door in list)
            {
                System.Console.WriteLine($"Door name: {door.Name.Value}");
                System.Console.WriteLine($"Door id: {door.Id.ToString()}");
                System.Console.WriteLine($"Door state: {(door.IsLocked ? "Locked" : "Unlocked")}");
                System.Console.WriteLine($"Creation time: {door.Creation}");
                System.Console.WriteLine($"Last modified time: {door.LastModified}");
                System.Console.WriteLine();
            }
            return;
        }
    }
}
