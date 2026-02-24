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
        private ICCTVRepository _ledRepository;

        public StartCCTVRecordingCommand(ICCTVRepository cctvRepository)
        {
            _ledRepository = cctvRepository;
        }

        public void Execute(Guid id)
        {
            var cctv = _ledRepository.GetById(id);
            if (cctv != null)
            {
                cctv.StartRecording();
                _ledRepository.Update(cctv);
            }
        }
    }
}
