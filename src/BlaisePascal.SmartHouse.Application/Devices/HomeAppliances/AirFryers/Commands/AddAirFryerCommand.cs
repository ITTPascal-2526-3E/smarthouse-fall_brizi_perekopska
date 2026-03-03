using BlaisePascal.SmartHouse.Domain.HomeAppliances;
using BlaisePascal.SmartHouse.Domain.HomeAppliances.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HomeAppliances.AirFryers.Commands
{
    public class AddAirFryerCommand
    {
        private IAirFryerRepository _airFryerRepository;

        public AddAirFryerCommand(IAirFryerRepository airFryerRepository)
        {
            _airFryerRepository = airFryerRepository;
        }

        public void Execute(Name name)
        {
            var airFryer = new AirFryer(name);
            _airFryerRepository.Add(airFryer);

        }
    }
}
