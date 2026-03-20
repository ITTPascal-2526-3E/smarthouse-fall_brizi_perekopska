using BlaisePascal.SmartHouse.Domain.HomeAppliances;
using BlaisePascal.SmartHouse.Domain.HomeAppliances.Repositories;
using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Illumination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.HomeAppliance.AirFtryers
{
    public class CsvAirFryerRepository : IAirFryerRepository
    {
        private readonly string _filePath = "airFryers.csv";
        public CsvAirFryerRepository()
        {
            var solutionRoot = LocalPathHelper.GetSolutionRoot();

            var dataFolder = Path.Combine(solutionRoot, "data");
            Directory.CreateDirectory(dataFolder);

            _filePath = Path.Combine(dataFolder, "airFryers.csv");

            if (!File.Exists(_filePath))
            {
                Save(new List<AirFryer>());
            }
        }

        public List<AirFryer> GetAll()
        {
            return Load();
        }

        public AirFryer GetById(Guid id)
        {
            return Load().FirstOrDefault(airFryer => airFryer.Id == id);
        }

        public void Add(AirFryer airFryer)
        {
            var airFryers = Load();
            airFryers.Add(airFryer);
            Save(airFryers);
        }

        public void Remove(Guid id)
        {
            var airFryers = Load();
            var airFryer = airFryers.First(a => a.Id == id);
            airFryers.Remove(airFryer);
            Save(airFryers);
        }

        public void Update(AirFryer airFryer)
        {
            var airFryers = Load();
            var index = airFryers.FindIndex(a => a.Id == airFryer.Id);
            if (index == -1)
                throw new Exception("AirFryer not found");
            airFryers[index] = airFryer;
            Save(airFryers);
        }

        private void Save(List<AirFryer> airFryers)
        {
            var dtos = airFryers;
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

        private List<AirFryer> Load()
        {
            if (!File.Exists(_filePath)) return new List<AirFryer>();

            var lines = File.ReadAllLines(_filePath);
            if (lines.Length <= 1) return new List<AirFryer>();

            var leds = new List<AirFryer>();
            foreach (var line in lines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var values = line.Split(',');
                if (values.Length < 5) continue;

                try
                {
                    var dto = new AirFryer(
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