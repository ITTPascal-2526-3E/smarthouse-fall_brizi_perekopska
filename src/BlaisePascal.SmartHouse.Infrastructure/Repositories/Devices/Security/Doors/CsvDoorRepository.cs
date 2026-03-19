using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Illumination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Security.Doors
{
    public class CsvDoorRepository : IDoorRepository
    {
        private readonly string _filePath = "doors.csv";
        public CsvDoorRepository()
        {
            var solutionRoot = LocalPathHelper.GetSolutionRoot();

            var dataFolder = Path.Combine(solutionRoot, "data");
            Directory.CreateDirectory(dataFolder);

            _filePath = Path.Combine(dataFolder, "doors.csv");

            if (!File.Exists(_filePath))
            {
                Save(new List<Door>());
            }
        }

        public List<Door> GetAll()
        {
            return Load();
        }

        public Door GetById(Guid id)
        {
            return Load().FirstOrDefault(door => door.Id == id);
        }

        public void Add(Door door)
        {
            var doors = Load();
            doors.Add(door);
            Save(doors);
        }

        public void Remove(Guid id)
        {
            var doors = Load();
            var door = doors.First(d => d.Id == id);
            doors.Remove(door);
            Save(doors);
        }

        public void Update(Door door)
        {
            var doors = Load();
            var index = doors.FindIndex(l => l.Id == door.Id);
            if (index == -1)
                throw new Exception("Door not found");
            doors[index] = door;
            Save(doors);
        }

        private void Save(List<Door> doors)
        {
            var dtos = doors;
            var lines = new List<string>
            {
                "Id,Name,IsLocked,CreatedTime,LastModifyTime"
            };

            foreach (var dto in dtos)
            {
                lines.Add(string.Join(",",
                    dto.Id,
                    dto.Name?.Value ?? "Not named",
                    dto.IsLocked,
                    dto.Creation,
                    dto.LastModified
                ));
            }

            File.WriteAllLines(_filePath, lines);
        }

        private List<Door> Load()
        {
            if (!File.Exists(_filePath)) return new List<Door>();

            var lines = File.ReadAllLines(_filePath);
            if (lines.Length <= 1) return new List<Door>();

            var leds = new List<Door>();
            foreach (var line in lines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var values = line.Split(',');
                if (values.Length < 5) continue;

                try
                {
                    var dto = new Door(
                        Guid.Parse(values[0]),
                        Name.From(values[1]),
                        bool.Parse(values[2]),
                        DateTime.Parse(values[3]),
                        DateTime.Parse(values[4])
                    );
                    leds.Add(dto);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Skip corrupted line: {line}. Error: {ex.Message}");
                }
            }
            return leds;
        }
    }
}
