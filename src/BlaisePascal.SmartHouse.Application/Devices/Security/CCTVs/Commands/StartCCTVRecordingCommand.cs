using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Security.CCTVs.Commands
{
    public class StartCCTVRecordingCommand
    {
        private ICCTVRepository _repository;

        public StartCCTVRecordingCommand(ICCTVRepository cctvRepository)
        {
            _repository = cctvRepository;
        }

        public void Execute(Guid id)
        {
            var cctv = _repository.GetById(id);
            if (cctv != null)
            {
                cctv.StartRecording();
                _repository.Update(cctv);
            }
        }
    }
}
