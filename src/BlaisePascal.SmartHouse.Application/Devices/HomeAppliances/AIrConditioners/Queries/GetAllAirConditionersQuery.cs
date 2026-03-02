using BlaisePascal.SmartHouse.Domain.HomeAppliances;
using BlaisePascal.SmartHouse.Domain.HomeAppliances.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HomeAppliances.AIrConditioners.Queries
{
    public class GetAllAirConditionersQuery
    {
        private readonly IAirConditionerRepository _airConditionerRepository;

        public GetAllAirConditionersQuery(IAirConditionerRepository airConditionerRepository)
        {
            _airConditionerRepository = airConditionerRepository;
        }

        public List<AirConditioner> Execute()
        {
            return _airConditionerRepository.GetAll();
        }
    }
}
