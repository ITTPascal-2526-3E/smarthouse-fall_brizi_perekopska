using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Security
{
    public class CCTV
    {
        //Attributes
        private bool IsOn;
        public bool IsRecording;
        const uint ResolutionPixels=3840*2160;//4K
        private bool HasNightVision;

        //Constructor
        public CCTV(bool isOn, bool isRecording, bool hasNightVision) 
        { 
            IsOn = isOn;
            if (IsOn == true)
                IsRecording = true;
            Console.WriteLine("CCTV cannot start recording if is off🎥🚫");
            HasNightVision = hasNightVision;
        }

        // Turn on the CCTV
        public bool TurnOnOrOff() 
        {
            if (IsOn == true)
            {
                IsOn = false;
            }
            else
            {
                IsOn = true;
            }
            return IsOn;
        }
        //Start or stop the recording
        public void StartOrStopRecording() 
        {
            if (IsRecording == true)
            {
                IsRecording = false;
            }
            else
            {
                if (IsOn == true) 
                    IsRecording = true;
                Console.WriteLine("CCTV cannot start recording if is off🎥🚫");
            }
        }

    }
}
