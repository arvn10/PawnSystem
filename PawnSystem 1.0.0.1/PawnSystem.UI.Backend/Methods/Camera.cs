using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

using AForge.Video;
using AForge.Video.DirectShow;

namespace PawnSystem.UI.Backend.Methods
{
    public class Camera
    {
        public PictureBox pictureBox { get; set; }

        private VideoCaptureDevice videoSource;
        private FilterInfoCollection videoDevice;
        private Bitmap image;

        public void NewFrame(object sender, NewFrameEventArgs eventargs)
        {
            image = (Bitmap)eventargs.Frame.Clone();

            pictureBox.Image = image;
        }

        public bool CheckCamera()
        {
            videoDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevice.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool StartCamera()
        {
            try
            {
                if (this.CheckCamera())
                {
                    videoDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                    videoSource = new VideoCaptureDevice(videoDevice[0].MonikerString);
                    videoSource.NewFrame += new NewFrameEventHandler(NewFrame);
                    videoSource.Start();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }

        public void ExitCamera()
        {
            videoSource.SignalToStop();
            // FinalVideo.WaitForStop();  << marking out that one solved it
            videoSource.NewFrame -= new NewFrameEventHandler(NewFrame); // as sugested
            videoSource = null;
        }

    }
}
