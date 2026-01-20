using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;


namespace BlaisePascal.SmartHouse.Domain.Security
{
    internal sealed class CCTVStartUp
    {
        //Attributes
        static public bool Save=false;
        static public bool Stop=false;
        //Create the cam which start filming
        static public void StartRealRecording()
        {
            Thread cam1Thread = new Thread(() => StartCam(0, "WebCam 1"));
            Thread cam2Thread = new Thread(() => StartCam(1, "Webcam 2"));
            //Thread cam3Thread = new Thread(() => StartCam(2, "WebCam 3"));
            //Thread cam4Thread = new Thread(() => StartCam(3, "Webcam 4"));

            cam1Thread.Start();
            cam2Thread.Start();
            //cam3Thread.Start();
            //cam4Thread.Start();

            cam1Thread.Join();
            cam2Thread.Join();
            //cam3Thread.Join();
            //cam4Thread.Join();
        }
        //Start the real filming
        static void StartCam(int id, string name)
        {
            using var capture = new VideoCapture(id);
            if (!capture.IsOpened())
            {
                Console.WriteLine("Errore: webcam non aperta.");
                Console.ReadKey();
                return;
            }
            using var frame = new Mat();
            int image = 0;
            while (true)
            {
                if (!capture.Read(frame))
                    continue;

                if (frame.Empty())
                    continue;

                Cv2.ImShow(name, frame);
                if (Stop==true || Cv2.WaitKey(1)==27)
                {
                    Stop = false;
                    break;
                }
                if (Save==true || Cv2.WaitKey(1)=='@') 
                {
                    image++;
                    Save = false;
                    string file = $"foto{image}_.jpg";
                    Cv2.ImWrite(file, frame);
                    Cv2.ImShow(file, frame);
                }
            }
            Cv2.DestroyAllWindows();
        }

        public void SaveScreen() 
        {
            Save = true;
        }

        public void StopFilming()
        {
            Stop = true;
        }
    }
}
