using BlaisePascal.SmartHouse.Domain.HomeAppliances.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlaisePascal.SmartHouse.Domain.HomeAppliances.AirFryer;

namespace BlaisePascal.SmartHouse.Application.Devices.HomeAppliances.AirFryers.Commands
{
    public class StopTheCookingCommand
    {
        private IAirFryerRepository _airFryerRepository;

        public StopTheCookingCommand(IAirFryerRepository airFryerRepository)
        {
            _airFryerRepository = airFryerRepository;
        }

        public void Execute(Guid id)
        {
            var airFryer = _airFryerRepository.GetById(id);
            if (airFryer != null && airFryer.IsOn == true )
            {
                airFryer.StopTheCooking();
                airFryer.LastModified = DateTime.Now;
                _airFryerRepository.Update(airFryer);
            }

        }
    }
}
