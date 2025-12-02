using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;

namespace BlaisePascal.SmartHouse.Domain.Security
{
    public class CCTV : Device
    {
        //Attributes
        public bool IsRecording;
        const uint ResolutionPixels=3840*2160;//4K
        private bool HasNightVision;
        private CCTVStartUp Starting=new CCTVStartUp();

        //Constructor
        public CCTV(string name, bool isOn, bool isRecording, bool hasNightVision) : base(name, isOn)
        { 
            IsOn = isOn;
            try
            {
                if (IsOn == true)
                {
                    IsRecording = true;
                }
                else
                {
                    throw new Exception();
                }
            }catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("CCTV cannot start recording if it's off");
            }
            HasNightVision = hasNightVision;
        }

        // Turn on the CCTV
        public bool TurnOnOrOff() 
        {
            if (IsOn == true)
                IsOn = false;
            else
                IsOn = true;
            return IsOn;
        }

        //Start the recording
        public void StopRecording() 
        {
            if (IsRecording == true)
            {
                IsRecording = false;
                Starting.StopFilming();
            }
            else
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("CCTV cannot stop recording if it's already off");
                }
            }
        }
        //Stop the recording
        public void StartRecording() 
        {
            try
            {
                if (IsOn == true )
                {
                    IsRecording = true;
                    var starting = new Thread(()=>CCTVStartUp.StartRealRecording());
                    starting.Start();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("CCTV cannot start recording if it's off");
            }
        }

        //Save and show the screen
        public void Save() 
        { 
            Starting.SaveScreen();
        }
    }
}
