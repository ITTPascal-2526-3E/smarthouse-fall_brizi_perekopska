using BlaisePascal.SmartHouse.Domain.HomeAppliances;
using BlaisePascal.SmartHouse.Domain.HomeAppliances.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HomeAppliances.AirFryers.Commands
{
    public class SwitchAirFryerOnCommand
    {
        private IAirFryerRepository _airFryerRepository;

        public SwitchAirFryerOnCommand(IAirFryerRepository airFryerRepository)
        {
            _airFryerRepository = airFryerRepository;
        }

        public void Execute(Guid id)
        {
            var airFryer = _airFryerRepository.GetById(id);
            if (airFryer != null)
            {
                if (airFryer.IsOn == false)
                {
                    airFryer.TurnOnOrOff();
                    airFryer.LastModified = DateTime.Now;
                }
                _airFryerRepository.Update(airFryer);
            }
        }
    }
}
