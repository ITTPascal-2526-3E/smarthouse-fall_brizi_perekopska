using BlaisePascal.SmartHouse.Domain.HomeAppliances;
using BlaisePascal.SmartHouse.Domain.HomeAppliances.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.HomeAppliance.AirConditioners
{
    public class CsvAirConditionerRepository : IAirConditionerRepository
    {
        private readonly string _filePath = "airConditioners.csv";
        public CsvAirConditionerRepository()
        {
            var solutionRoot = LocalPathHelper.GetSolutionRoot();

            var dataFolder = Path.Combine(solutionRoot, "data");
            Directory.CreateDirectory(dataFolder);

            _filePath = Path.Combine(dataFolder, "airConditioners.csv");

            if (!File.Exists(_filePath))
            {
                Save(new List<AirConditioner>());
            }
        }

        public List<AirConditioner> GetAll()
        {
            return Load();
        }

        public AirConditioner GetById(Guid id)
        {
            return Load().FirstOrDefault(airConditioner => airConditioner.Id == id);
        }

        public void Add(AirConditioner airConditioner)
        {
            var airConditioners = Load();
            airConditioners.Add(airConditioner);
            Save(airConditioners);
        }

        public void Remove(Guid id)
        {
            var airConditioners = Load();
            var airConditioner = airConditioners.First(a => a.Id == id);
            airConditioners.Remove(airConditioner);
            Save(airConditioners);
        }

        public void Update(AirConditioner airConditioner)
        {
            var airConditioners = Load();
            var index = airConditioners.FindIndex(a => a.Id == airConditioner.Id);
            if (index == -1)
                throw new Exception("AirConditioner not found");
            airConditioners[index] = airConditioner;
            Save(airConditioners);
        }

        private void Save(List<AirConditioner> airConditioners)
        {
            var dtos = airConditioners;
            var lines = new List<string>
            {
                "Id,Name,IsOn,CreatedTime,LastModifyTime"
            };

            foreach (var dto in dtos)
            {
                lines.Add(string.Join(",",
                    dto.Id,
                    dto.Name?.Value ?? "Not named",
                    dto.IsOn,
                    dto.Creation,
                    dto.LastModified
                ));
            }

            File.WriteAllLines(_filePath, lines);
        }

        private List<AirConditioner> Load()
        {
            if (!File.Exists(_filePath)) return new List<AirConditioner>();

            var lines = File.ReadAllLines(_filePath);
            if (lines.Length <= 1) return new List<AirConditioner>();

            var leds = new List<AirConditioner>();
            foreach (var line in lines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var values = line.Split(',');
                if (values.Length < 5) continue;

                try
                {
                    var dto = new AirConditioner(
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
