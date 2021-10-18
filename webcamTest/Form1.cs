using OpenCvSharp;
using System;
using System.Windows.Forms;

namespace webcamTest
{
    public partial class Form1 : Form
    {
        VideoCapture panel_camera;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                panel_camera = new VideoCapture(0)
                {
                    AutoFocus = false,
                    Focus = 28 * 5,
                    BufferSize = 1,
                    FrameWidth = 640,
                    FrameHeight = 480
                };
            }
            catch
            {
                timer1.Enabled = false;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (panel_camera != null)
            {
                Mat frame = new Mat();
                panel_camera.Read(frame);
                //resize
                //Cv2.Resize(frame, frame, new OpenCvSharp.Size(320, 240));
                //flip xy
                //Cv2.Flip(frame, frame, FlipMode.XY);
                pictureBoxIpl1.ImageIpl = frame;
                frame.Dispose();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            panel_camera.Release();
            Cv2.DestroyAllWindows();
        }

        public void SetWebCam()
        {
            if (panel_camera != null)
            {
                panel_camera.Set(CaptureProperty.Settings, 1.0);
            }
        }
    }
}
