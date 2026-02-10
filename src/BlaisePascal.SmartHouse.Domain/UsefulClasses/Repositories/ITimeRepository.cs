using BlaisePascal.SmartHouse.Domain.Temperature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UsefulClasses.Repositories
{
    public interface TimeRepository
    {
        void Add(Time time);
        void Update(Time time);
        void Remove(Guid id);
        Time GetById(Guid id);
        List<Time> GetAll();
    }
}
