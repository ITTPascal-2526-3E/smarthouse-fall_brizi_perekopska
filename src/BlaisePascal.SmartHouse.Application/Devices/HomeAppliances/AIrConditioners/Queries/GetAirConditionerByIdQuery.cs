using BlaisePascal.SmartHouse.Domain.HomeAppliances;
using BlaisePascal.SmartHouse.Domain.HomeAppliances.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HomeAppliances.AIrConditioners.Queries
{
    public class GetAirConditionerByIdQuery
    {
        private readonly IAirConditionerRepository _airConditionerRepository;

        public GetAirConditionerByIdQuery(IAirConditionerRepository airConditionerRepository)
        {
            _airConditionerRepository = airConditionerRepository;
        }

        public AirConditioner Execute(Guid id)
        {
            return _airConditionerRepository.Remove(id);
        }
    }
}
