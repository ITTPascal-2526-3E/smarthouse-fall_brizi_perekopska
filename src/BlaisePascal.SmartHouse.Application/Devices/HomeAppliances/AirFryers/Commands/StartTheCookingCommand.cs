using BlaisePascal.SmartHouse.Domain.HomeAppliances;
using BlaisePascal.SmartHouse.Domain.HomeAppliances.Repositories;
using BlaisePascal.SmartHouse.Domain.Illumination;
using BlaisePascal.SmartHouse.Domain.Illumination.Repositories;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Temperature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlaisePascal.SmartHouse.Domain.HomeAppliances.AirFryer;

namespace BlaisePascal.SmartHouse.Application.Devices.HomeAppliances.AirFryers.Commands
{
    public class StartTheCookingCommand
    {
        private IAirFryerRepository _airFryerRepository;

        public StartTheCookingCommand(IAirFryerRepository airFryerRepository)
        {
            _airFryerRepository = airFryerRepository;
        }

        public async Task Execute(Guid id, CookingType type, byte cookingTemperature, byte timerH, byte timerM, byte timerS)
        {
            var airFryer=_airFryerRepository.GetById(id);
            if (airFryer != null && airFryer.IsOn == true) 
            {
                airFryer.StartTheCooking(type, cookingTemperature, timerH, timerM, timerS);
                airFryer.LastModified = DateTime.Now;
                _airFryerRepository.Update(airFryer);
            }

        }
    }
}
