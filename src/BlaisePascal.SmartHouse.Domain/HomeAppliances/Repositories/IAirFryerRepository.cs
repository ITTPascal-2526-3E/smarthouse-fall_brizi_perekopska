using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.HomeAppliances.Repositories
{
    public interface IAirFryerRepository
    {
        void Add(AirFryer airFryer);
        void Update(AirFryer airFryer);
        void Remove(Guid id);
        AirFryer GetById(Guid id);
        List<AirFryer> GetAll();
    }
}
}
