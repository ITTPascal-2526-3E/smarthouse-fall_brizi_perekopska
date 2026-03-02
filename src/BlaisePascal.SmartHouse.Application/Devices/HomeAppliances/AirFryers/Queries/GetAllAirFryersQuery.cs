using BlaisePascal.SmartHouse.Domain.HomeAppliances;
using BlaisePascal.SmartHouse.Domain.HomeAppliances.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HomeAppliances.AirFryers.Queries
{
    public class GetAllAirFryersQuery
    {
        private readonly IAirFryerRepository _airFryerRepository;

        public GetAllAirFryersQuery(IAirFryerRepository airFryerRepository)
        {
            _airFryerRepository = airFryerRepository;
        }

        public List<AirFryer> Execute()
        {
            return _airFryerRepository.GetAll();
        }
    }
}
