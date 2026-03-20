using BlaisePascal.SmartHouse.Domain.HomeAppliances.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HomeAppliances.AIrConditioners.Commands
{
    public class SwitchAirConditionerOffCommand
    {
        private IAirConditionerRepository _airConditionerRepository;

        public SwitchAirConditionerOffCommand(IAirConditionerRepository airConditionerRepository)
        {
            _airConditionerRepository = airConditionerRepository;
        }

        public void Execute(Guid id)
        {
            var airConditioner = _airConditionerRepository.GetById(id);
            if (airConditioner != null)
            {
                if (airConditioner.IsOn == true)
                {
                    airConditioner.TurnOnOrOff();
                    airConditioner.LastModified = DateTime.Now;
                }
                _airConditionerRepository.Update(airConditioner);
            }
        }
    }
}
