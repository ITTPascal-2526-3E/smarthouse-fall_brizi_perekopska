using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Illumination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Security.CCTVs
{
    public class CsvCCTVRepository:ICCTVRepository
    {
        private readonly string _filePath="cctvs.csv";
        public CsvCCTVRepository() 
        {
            var solutionRoot = LocalPathHelper.GetSolutionRoot();

            var dataFolder = Path.Combine(solutionRoot, "data");
            Directory.CreateDirectory(dataFolder);

            _filePath = Path.Combine(dataFolder, "cctvs.csv");

            if (!File.Exists(_filePath))
            {
                Save(new List<CCTV>());
            }
        }
        public List<CCTV> GetAll()
        {
            return Load();
        }

        public CCTV GetById(Guid id)
        {
            return Load().FirstOrDefault(cctv => cctv.Id == id);
        }
        public void Add(CCTV cctv)
        {
            var cctvs = Load();
            cctvs.Add(cctv);
            Save(cctvs);
        }
        public void Remove(Guid id)
        {
            var cctvs = Load();
            var cctv = cctvs.First(c => c.Id == id);
            cctvs.Remove(cctv);
            Save(cctvs);
        }
        public void Update(CCTV cctv)
        {
            var cctvs = Load();
            var index = cctvs.FindIndex(c => c.Id == cctv.Id);
            if (index == -1)
                throw new Exception("Cctv not found");
            cctvs[index] = cctv;
            Save(cctvs);
        }
        private void Save(List<CCTV> leds)
        {
            var dtos = leds;
            var lines = new List<string>
            {
                "Id,Name,IsOn,IsRecording, HasNightVision,CreatedTime,LastModifyTime"
            };

            foreach (var dto in dtos)
            {
                lines.Add(string.Join(",",
                    dto.Id,
                    dto.Name?.Value ?? "Not named",
                    dto.IsOn,
                    dto.IsRecording,
                    dto.HasNightVision,
                    dto.Creation,
                    dto.LastModified
                ));
            }

            File.WriteAllLines(_filePath, lines);
        }
        private List<CCTV> Load()
        {
            if (!File.Exists(_filePath)) return new List<CCTV>();

            var lines = File.ReadAllLines(_filePath);
            if (lines.Length <= 1) return new List<CCTV>();

            var leds = new List<CCTV>();
            foreach (var line in lines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var values = line.Split(',');
                if (values.Length < 7) continue;

                try
                {
                    var dto = new CCTV(
                        Guid.Parse(values[0]),
                        Name.From(values[1]),
                        bool.Parse(values[2]),
                        bool.Parse(values[3]),
                        bool.Parse(values[4]),
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
