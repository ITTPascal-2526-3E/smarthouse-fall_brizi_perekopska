using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Illumination;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Illumination.Leds
{
    public class CsvLedRepository : ILedRepository
    {
        private readonly string _filePath = "leds.csv";
        public CsvLedRepository()
        {
            var solutionRoot = LocalPathHelper.GetSolutionRoot();

            var dataFolder = Path.Combine(solutionRoot, "data");
            Directory.CreateDirectory(dataFolder);

            _filePath = Path.Combine(dataFolder, "leds.csv");

            if (!File.Exists(_filePath))
            {
                Save(new List<Led>());
            }
        }

        public List<Led> GetAll()
        {
            return Load();
        }

        public Led GetById(Guid id)
        {
            return Load().FirstOrDefault(led => led.Id == id);
        }

        public void Add(Led led)
        {
            var leds = Load();
            leds.Add(led);
            Save(leds);
        }

        public void Remove(Guid id)
        {
            var leds = Load();
            var led = leds.First(l => l.Id == id);
            leds.Remove(led);
            Save(leds);
        }

        public void Update(Led led)
        {
            var leds = Load();
            var index = leds.FindIndex(l => l.Id == led.Id);
            if (index == -1)
                throw new Exception("Led not found");
            leds[index] = led;
            Save(leds);
        }

        private void Save(List<Led> leds)
        {
            var dtos = leds;
            var lines = new List<string>
            {
                "Id,Name,IsOn,Brightness,ColorR,ColorG,ColorB,CreatedTime,LastModifyTime"
            };

            foreach (var dto in dtos)
            {
                lines.Add(string.Join(",",
                    dto.Id,
                    dto.Name?.Value ?? "Not named",
                    dto.IsOn,
                    dto.Brightness?.Value ?? 0,
                    dto.Color.R,
                    dto.Color.G,
                    dto.Color.B,
                    dto.Creation,
                    dto.LastModified
                ));
            }

            File.WriteAllLines(_filePath, lines);
        }

        private List<Led> Load()
        {
            if (!File.Exists(_filePath)) return new List<Led>();

            var lines = File.ReadAllLines(_filePath);
            if (lines.Length <= 1) return new List<Led>();

            var leds = new List<Led>();
            foreach (var line in lines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var values = line.Split(',');
                if (values.Length < 9) continue;

                try
                {
                    var dto = new Led(
                        Guid.Parse(values[0]),
                        Name.From(values[1]),
                        bool.Parse(values[2]),
                        Brightness.From(byte.Parse(values[3])),
                        Color.From(byte.Parse(values[4]), byte.Parse(values[5]), byte.Parse(values[6])),
                        DateTime.Parse(values[7]),
                        DateTime.Parse(values[8])
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
