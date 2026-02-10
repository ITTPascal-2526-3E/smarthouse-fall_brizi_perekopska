using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Illumination.Repositories
{
    public interface ILedRepository
    {
        void Add(Led led);
        void Update(Led led);
        void Remove(Guid id);
        Led GetById(Guid id);
        List<Led> GetAll();
    }
}
