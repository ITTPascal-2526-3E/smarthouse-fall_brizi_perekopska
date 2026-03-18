using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Illumination;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Time;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;


namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Illumination.Lamps
{
    public class CsvLampRepository : ILampRepository
    {
        private readonly string _filePath = "lamps.csv";
        public CsvLampRepository()
        {
            var solutionRoot = LocalPathHelper.GetSolutionRoot();

            var dataFolder = Path.Combine(solutionRoot, "data");
            Directory.CreateDirectory(dataFolder);

            _filePath = Path.Combine(dataFolder, "lamps.csv");

            if (!File.Exists(_filePath))
            {
                Save(new List<Lamp>());
            }
        }

        public List<Lamp> GetAll()
        {
            return Load();
        }

        public Lamp GetById(Guid id)
        {
            return Load().FirstOrDefault(lamp => lamp.Id == id);
        }

        public void Add(Lamp lamp)
        {
            var lamps = Load();
            lamps.Add(lamp);
            Save(lamps);
        }

        public void Remove(Guid id)
        {
            var lamps = Load();
            var lamp = lamps.First(l => l.Id == id);
            lamps.Remove(lamp);
            Save(lamps);
        }

        public void Update(Lamp lamp)
        {
            var lamps = Load();
            var index = lamps.FindIndex(l => l.Id == lamp.Id);
            if (index == -1)
                throw new Exception("Lamp not found");
            lamps[index] = lamp;
            Save(lamps);
        }

        private void Save(List<Lamp> lamps)
        {
            var dtos = lamps;
            var lines = new List<string>
            {
                "Id,Name,IsOn,Brightness,ColorR,ColorG,ColorB,Type,OnTimeHour,OnTimeMInutes,OnTimeSeconds,OffTimeHour,OffTimeMInutes,OffTimeSeconds,CreatedTime,LastModifyTime"
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
                    dto.Type,
                    dto.OnTime.Hours.Value,
                    dto.OnTime.Minutes.Value,
                    dto.OnTime.Seconds.Value,
                    dto.OffTime.Hours.Value,
                    dto.OffTime.Minutes.Value,
                    dto.OffTime.Seconds.Value,
                    dto.Creation,
                    dto.LastModified
                ));
            }

            File.WriteAllLines(_filePath,lines);
        }

        private List<Lamp> Load()
        {
            if (!File.Exists(_filePath)) return new List<Lamp>();

            var lines = File.ReadAllLines(_filePath);
            if (lines.Length <= 1) return new List<Lamp>();

            var lamps = new List<Lamp>();
            foreach (var line in lines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var values = line.Split(',');
                if (values.Length < 16) continue;

                try
                {
                    var dto = new Lamp(
                        Guid.Parse(values[0]),
                        Name.From(values[1]),
                        bool.Parse(values[2]),
                        Brightness.From(byte.Parse(values[3])),
                        Color.From(byte.Parse(values[4]), byte.Parse(values[5]), byte.Parse(values[6])),
                        values[7],
                        new Time(Hour.From(int.Parse(values[8])), Minutes.From(int.Parse(values[9])), Seconds.From(int.Parse(values[10]))),
                        new Time(Hour.From(int.Parse(values[11])), Minutes.From(int.Parse(values[12])), Seconds.From(int.Parse(values[13]))),
                        DateTime.Parse(values[14]),
                        DateTime.Parse(values[15])
                    );
                    lamps.Add(dto);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Skip corrupted line: {line}. Error: {ex.Message}");
                }
            }
            return lamps;
        }
    }
}
