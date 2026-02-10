using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Interface;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;
using BlaisePascal.SmartHouse.Domain.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Security
{
    public sealed class CCTV : Device, ISwitchable
    {
        //Attributes
        public bool IsRecording;
        const uint ResolutionPixels=3840*2160;//4K
        private bool HasNightVision;
        private CCTVStartUp Starting=new CCTVStartUp();

        //Constructor
        public CCTV(Name name, bool isOn, bool isRecording, bool hasNightVision) : base(name, isOn)
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
                return;
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
                    return;
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
                return;
            }
        }

        //Save and show the screen
        public void Save() 
        { 
            Starting.SaveScreen();
        }
    }
}
