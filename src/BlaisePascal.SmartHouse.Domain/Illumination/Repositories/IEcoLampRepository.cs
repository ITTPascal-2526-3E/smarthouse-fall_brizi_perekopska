using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Illumination.Repositories
{
    public interface IEcoLampRepository
    {
        void Add(EcoLamp ecoLamp);
        void Update(EcoLamp ecoLamp);
        void Remove(Guid id);
        EcoLamp GetById(Guid id);
        List<EcoLamp> GetAll();
    }
}
