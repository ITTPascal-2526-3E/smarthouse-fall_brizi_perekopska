using BlaisePascal.SmartHouse.Domain.UsefulClasses;
using BlaisePascal.SmartHouse.Domain.UsefulClasses.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.UsefullClasses.Times.Queries
{
    public class GetAllTimesQuery
    {
        private readonly ITimeRepository _timeRepository;

        public GetAllTimesQuery(ITimeRepository timeRepository)
        {
            _timeRepository = timeRepository;
        }

        public List<Time> Execute()
        {
            return _timeRepository.GetAll();
        }
    }
}
