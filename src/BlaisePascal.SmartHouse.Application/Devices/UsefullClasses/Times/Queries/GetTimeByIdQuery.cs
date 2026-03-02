using BlaisePascal.SmartHouse.Domain.UsefulClasses;
using BlaisePascal.SmartHouse.Domain.UsefulClasses.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.UsefullClasses.Times.Queries
{
    public class GetTimeByIdQuery
    {
        private readonly ITimeRepository _timeRepository;

        public GetTimeByIdQuery(ITimeRepository timeRepository)
        {
            _timeRepository = timeRepository;
        }

        public Time Execute(Guid id)
        {
            return _timeRepository.GetById(id);
        }
    }
}
