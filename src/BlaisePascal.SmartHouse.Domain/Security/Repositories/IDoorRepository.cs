using BlaisePascal.SmartHouse.Domain.Illumination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Security.Repositories
{
    public interface IDoorRepositiory
    {
        void Add(Door door);
        void Update(Door door);
        void Remove(Guid id);
        Door GetById(Guid id);
        List<Door> GetAll();
    }
}
