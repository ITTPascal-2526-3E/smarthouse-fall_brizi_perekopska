using BlaisePascal.SmartHouse.Application.Devices.Illumination.Leds.Commands;
using BlaisePascal.SmartHouse.Application.Devices.Illumination.Leds.Queries;
using BlaisePascal.SmartHouse.Application.Devices.Security.CCTVs.Commands;
using BlaisePascal.SmartHouse.Application.Devices.Security.CCTVs.Queries;
using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Console.Devices.Controlers.Security
{
    public class CCTVController
    {
        private readonly ICCTVRepository _repository;
        private GetAllCCTVQuery _query;
        public CCTVController(ICCTVRepository repository)
        {
            _repository = repository;
            _query = new GetAllCCTVQuery(_repository);
        }


        //Add new CCTV obj to a specific repo
        public void AddCCTV()
        {
            System.Console.Write("CCTV name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }

            new AddCCTVCommand(_repository).Execute(Name.From(name));
            System.Console.WriteLine("!CCTV added!");
            return;
        }

        //Remove a CCTV obj from a specific repo
        public void RemoveCCTV()
        {
            System.Console.Write("CCTV name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }
            List<CCTV> list = _query.Execute();
            foreach (CCTV cctv in list)
            {
                if (name == cctv.Name.Value)
                {
                    new RemoveCCTVCommand(_repository).Execute(cctv.Id);
                    System.Console.WriteLine("!CCTV removed!");
                    return;
                }
                if (name == cctv.Id.ToString())
                {
                    new RemoveCCTVCommand(_repository).Execute(cctv.Id);
                    System.Console.WriteLine($"!CCTV {cctv.Name.Value} removed!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }

        //Turn on the led selected
        public void SwitchOn()
        {
            System.Console.Write("CCTV name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }
            List<CCTV> list = _query.Execute();
            foreach (CCTV cctv in list)
            {
                if (name == cctv.Name.Value && cctv.IsOn == false)
                {
                    new SwitchCCTVOnCommand(_repository).Execute(cctv.Id);
                    System.Console.WriteLine($"!CCTV {cctv.Name.Value} switched on!");
                    return;
                }
                if (name == cctv.Id.ToString() && cctv.IsOn == false)
                {
                    new SwitchCCTVOnCommand(_repository).Execute(cctv.Id);
                    System.Console.WriteLine($"!CCTV  {cctv.Name.Value} switched on!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }
        //Turn off the led selected
        public void SwitchOff()
        {
            System.Console.Write("CCTV name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }
            List<CCTV> list = _query.Execute();
            foreach (CCTV cctv in list)
            {
                if (name == cctv.Name.Value && cctv.IsOn == true)
                {
                    new SwitchCCTVOffCommand(_repository).Execute(cctv.Id);
                    System.Console.WriteLine($"!CCTV {cctv.Name.Value} switched off!");
                    return;
                }
                if (name == cctv.Id.ToString() && cctv.IsOn == true)
                {
                    new SwitchCCTVOffCommand(_repository).Execute(cctv.Id);
                    System.Console.WriteLine($"!CCTV  {cctv.Name.Value} switched off!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }
        //Start recording the cctv selected
        public void StartRecording() 
        {
            System.Console.Write("CCTV name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }
            List<CCTV> list = _query.Execute();
            foreach (CCTV cctv in list)
            {
                if (name == cctv.Name.Value && cctv.IsOn == true)
                {
                    new StartCCTVRecordingCommand(_repository).Execute(cctv.Id);
                    System.Console.WriteLine($"!CCTV {cctv.Name.Value} start recording!");
                    return;
                }
                if (name == cctv.Id.ToString() && cctv.IsOn == true)
                {
                    new StartCCTVRecordingCommand(_repository).Execute(cctv.Id);
                    System.Console.WriteLine($"!CCTV  {cctv.Name.Value} start recording!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }
        //Stop recording the cctv selected
        public void StopRecording()
        {
            System.Console.Write("CCTV name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }
            List<CCTV> list = _query.Execute();
            foreach (CCTV cctv in list)
            {
                if (name == cctv.Name.Value && cctv.IsOn == true)
                {
                    new StopCCTVRecordingCommand(_repository).Execute(cctv.Id);
                    System.Console.WriteLine($"!CCTV {cctv.Name.Value} stop recording!");
                    return;
                }
                if (name == cctv.Id.ToString() && cctv.IsOn == true)
                {
                    new StopCCTVRecordingCommand(_repository).Execute(cctv.Id);
                    System.Console.WriteLine($"!CCTV  {cctv.Name.Value} stop recording!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }
        //Save the screen about the cctv selected
        public void SaveScreen()
        {
            System.Console.Write("CCTV name: ");
            string name = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Name not valid");
                return;
            }
            List<CCTV> list = _query.Execute();
            foreach (CCTV cctv in list)
            {
                if (name == cctv.Name.Value && cctv.IsOn == true)
                {
                    new SaveScreenCCTVCommand(_repository).Execute(cctv.Id);
                    System.Console.WriteLine($"!CCTV {cctv.Name.Value} save the screen!");
                    return;
                }
                if (name == cctv.Id.ToString() && cctv.IsOn == true)
                {
                    new SaveScreenCCTVCommand(_repository).Execute(cctv.Id);
                    System.Console.WriteLine($"!CCTV  {cctv.Name.Value} save the screen!");
                    return;
                }
            }
            System.Console.WriteLine("Name not valid");
            return;
        }
        public void ShowAllCCTVs()
        {
            List<CCTV> list = _query.Execute();
            System.Console.WriteLine("----------CCTVS----------");
            foreach (CCTV cctv in list)
            {
                System.Console.WriteLine($"CCTV name: {cctv.Name.Value}");
                System.Console.WriteLine($"CCTV id: {cctv.Id.ToString()}");
                System.Console.WriteLine($"CCTV state: {cctv.IsOn}");
                System.Console.WriteLine($"CCTV is recording: {cctv.IsRecording}");
                System.Console.WriteLine($"CCTV has night vision: {cctv.HasNightVision}");
                System.Console.WriteLine($"Creation time: {cctv.Creation}");
                System.Console.WriteLine($"Last modified time: {cctv.LastModified}");
                System.Console.WriteLine();
            }
            return;
        }
    }
}