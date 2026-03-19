using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using BlaisePascal.SmartHouse.Domain.Temperature.Repositories;
using BlaisePascal.SmartHouse.Domain.Temperature;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Illumination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Temperature;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Temperature.Thermostats
{
    public class CsvThermostatRepository : IThermostatRepository
    {
        private readonly string _filePath = "thermostats.csv";
        public CsvThermostatRepository()
        {
            var solutionRoot = LocalPathHelper.GetSolutionRoot();

            var dataFolder = Path.Combine(solutionRoot, "data");
            Directory.CreateDirectory(dataFolder);

            _filePath = Path.Combine(dataFolder, "thermostats.csv");

            if (!File.Exists(_filePath))
            {
                Save(new List<Thermostat>());
            }
        }

        public List<Thermostat> GetAll()
        {
            return Load();
        }

        public Thermostat GetById(Guid id)
        {
            return Load().FirstOrDefault(thermostat => thermostat.Id == id);
        }

        public void Add(Thermostat thermostat)
        {
            var thermostats = Load();
            thermostats.Add(thermostat);
            Save(thermostats);
        }

        public void Remove(Guid id)
        {
            var thermostats = Load();
            var thermostat = thermostats.First(t => t.Id == id);
            thermostats.Remove(thermostat);
            Save(thermostats);
        }

        public void Update(Thermostat thermostat)
        {
            var thermostats = Load();
            var index = thermostats.FindIndex(t => t.Id == thermostat.Id);
            if (index == -1)
                throw new Exception("Thermostat not found");
            thermostats[index] = thermostat;
            Save(thermostats);
        }

        private void Save(List<Thermostat> thermostats)
        {
            var dtos = thermostats;
            var lines = new List<string>
            {
                "Id,Name,IsOn,CurrentTemperature,SetPointTemperature,CreatedTime,LastModifyTime"
            };

            foreach (var dto in dtos)
            {
                lines.Add(string.Join(",",
                    dto.Id,
                    dto.Name?.Value ?? "Not named",
                    dto.IsOn,
                    dto.CurrentTemperature,
                    dto.SetpointTemperature,
                    dto.Creation,
                    dto.LastModified
                ));
            }

            File.WriteAllLines(_filePath, lines);
        }

        private List<Thermostat> Load()
        {
            if (!File.Exists(_filePath)) return new List<Thermostat>();

            var lines = File.ReadAllLines(_filePath);
            if (lines.Length <= 1) return new List<Thermostat>();

            var leds = new List<Thermostat>();
            foreach (var line in lines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var values = line.Split(',');
                if (values.Length < 7) continue;

                try
                {
                    var dto = new Thermostat(
                        Guid.Parse(values[0]),
                        Name.From(values[1]),
                        bool.Parse(values[2]),
                        ThermostatTemperature.From(float.Parse(values[3])),
                        ThermostatTemperature.From(float.Parse(values[4])),
                        DateTime.Parse(values[5]),
                        DateTime.Parse(values[6])
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
