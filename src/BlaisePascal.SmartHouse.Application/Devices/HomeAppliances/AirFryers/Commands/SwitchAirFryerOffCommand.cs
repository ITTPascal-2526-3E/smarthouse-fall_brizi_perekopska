using BlaisePascal.SmartHouse.Domain.HomeAppliances;
using BlaisePascal.SmartHouse.Domain.HomeAppliances.Repositories;
using BlaisePascal.SmartHouse.Domain.Temperature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HomeAppliances.AirFryers.Commands
{
    public class SwitchAirFryerOffCommand
    {
        private IAirFryerRepository _airFryerRepository;

        public SwitchAirFryerOffCommand(IAirFryerRepository airFryerRepository)
        {
            _airFryerRepository = airFryerRepository;
        }

        public void Execute(Guid id)
        {
            var airFryer = _airFryerRepository.GetById(id);
            if (airFryer != null)
            {
                if (airFryer.IsOn == true)
                {
                    airFryer.TurnOnOrOff();
                    airFryer.LastModified = DateTime.Now;
                }
                _airFryerRepository.Update(airFryer);
            }
        }
    }
}
