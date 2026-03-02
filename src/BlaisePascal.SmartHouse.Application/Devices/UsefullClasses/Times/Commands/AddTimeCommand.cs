using BlaisePascal.SmartHouse.Domain.UsefulClasses;
using BlaisePascal.SmartHouse.Domain.UsefulClasses.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.UsefullClasses.Times.Commands
{
    public class AddTimeCommand
    {
        private ITimeRepository _timeRepository;

        public AddTimeCommand(ITimeRepository timeRepository)
        {
            _timeRepository = timeRepository;
        }

        public void Execute(Guid id)
        {
            var time = new Time(id);
            _timeRepository.Add(time);

        }
    }
}
