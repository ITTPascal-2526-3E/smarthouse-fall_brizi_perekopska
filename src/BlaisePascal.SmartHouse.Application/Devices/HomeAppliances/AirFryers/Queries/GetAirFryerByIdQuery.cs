using BlaisePascal.SmartHouse.Domain.HomeAppliances;
using BlaisePascal.SmartHouse.Domain.HomeAppliances.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HomeAppliances.AirFryers.Queries
{
    public class GetAirFryerByIdQuery
    {
        private readonly IAirFryerRepository _airFryerRepository;

        public GetAirFryerByIdQuery(IAirFryerRepository airFryerRepository)
        {
            _airFryerRepository = airFryerRepository;
        }

        public AirFryer Execute(Guid id)
        {
            return _airFryerRepository.GetById(id);
        }
    }
}
