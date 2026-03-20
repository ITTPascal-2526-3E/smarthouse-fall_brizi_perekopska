using BlaisePascal.SmartHouse.Domain.HomeAppliances.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using BlaisePascal.SmartHouse.Domain.ValueObjects.Temperature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlaisePascal.SmartHouse.Domain.HomeAppliances.AirConditioner;
using static BlaisePascal.SmartHouse.Domain.HomeAppliances.AirFryer;

namespace BlaisePascal.SmartHouse.Application.Devices.HomeAppliances.AIrConditioners.Commands
{
    public class StartAirConditionerCommand
    {
        private IAirConditionerRepository _airConditionerRepository;

        public StartAirConditionerCommand(IAirConditionerRepository airConditionerRepository)
        {
            _airConditionerRepository = airConditionerRepository;
        }

        public async Task Execute(Guid id, AirTypeList type, float temp, byte speed)
        {
            var airFryer = _airConditionerRepository.GetById(id);
            if (airFryer != null && airFryer.IsOn == true)
            {
                airFryer.StartAirConditioner(type,ACTemperature.From(temp),Speed.From(speed) );
                airFryer.LastModified = DateTime.Now;
                _airConditionerRepository.Update(airFryer);
            }

        }
    }
}
