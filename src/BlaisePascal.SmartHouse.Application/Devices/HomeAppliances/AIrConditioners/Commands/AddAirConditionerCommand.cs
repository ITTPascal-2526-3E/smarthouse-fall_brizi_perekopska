using BlaisePascal.SmartHouse.Domain.HomeAppliances;
using BlaisePascal.SmartHouse.Domain.HomeAppliances.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HomeAppliances.AIrConditioners.Commands
{
    public class AddAirConditionerCommand
    {
        private IAirConditionerRepository _airConditionerRepository;

        public AddAirConditionerCommand(IAirConditionerRepository airConditionerRepository)
        {
            _airConditionerRepository = airConditionerRepository;
        }

        public void Execute(Name name)
        {
            var airConditioner = new AirConditioner(name);
            _airConditionerRepository.Add(airConditioner);

        }
    }
}
