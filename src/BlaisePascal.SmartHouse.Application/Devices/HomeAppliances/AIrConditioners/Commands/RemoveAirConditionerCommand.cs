using BlaisePascal.SmartHouse.Domain.HomeAppliances.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HomeAppliances.AIrConditioners.Commands
{
    public class RemoveAirConditionerCommand
    {
        private IAirConditionerRepository _airConditionerRepository;

        public RemoveAirConditionerCommand(IAirConditionerRepository airConditionerRepository)
        {
            _airConditionerRepository = airConditionerRepository;
        }

        public void Execute(Guid id)
        {
            _airConditionerRepository.Remove(id);

        }
    }
}
