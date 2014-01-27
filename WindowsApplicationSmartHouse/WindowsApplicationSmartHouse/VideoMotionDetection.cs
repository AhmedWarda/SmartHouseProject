using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Vision.Motion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsApplicationSmartHouse.BusinessWorkFlowService;

namespace WindowsApplicationSmartHouse
{
    public partial class VideoMotionDetection : Form
    {
        public VideoMotionDetection()
        {
            InitializeComponent();
        }


        private IVideoSource videoSource = null;

        // motion detection and processing algorithm
        private int motionDetectionType = 1;
        private int motionProcessingType = 1;

        // statistics length
        private const int statLength = 15;
        // current statistics index
        private int statIndex = 0;
        // ready statistics values
        private int statReady = 0;
        // statistics array
        private int[] statCount = new int[statLength];

        // counter used for flashing
        private int flash = 0;
        private float motionAlarmLevel = 0.015f;

        // motion detector
        MotionDetector detector = new MotionDetector(
            new TwoFramesDifferenceDetector(),
            new MotionAreaHighlighting());

        private List<float> motionHistory = new List<float>();
        private int detectedObjectsCount = -1;

        BusinessWorkFlowService.BusinessWorkFlowsClient _bwfc=new BusinessWorkFlowsClient();
        string[] _deviceData=new string[3];

        public string[] GetCameras()
        {
            FilterInfoCollection videoDevices;
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            string[] _camerasArray = new string[videoDevices.Count];
            ;

            for (int i = 0; i < videoDevices.Count; i++)
            {
                _camerasArray[i] = videoDevices[i].MonikerString;

            }
            return _camerasArray;
        }

        private void OpenVideoSource(IVideoSource source)
        {
            // set busy cursor
            this.Cursor = Cursors.WaitCursor;

            // close previous video source
            CloseVideoSource();

            // start new video source
            videoSourcePlayer.VideoSource = new AsyncVideoSource(source);
            videoSourcePlayer.Start();

            // reset statistics
            statIndex = statReady = 0;

            // start timers
            timer.Start();
            alarmTimer.Start();

            videoSource = source;

            this.Cursor = Cursors.Default;
        }

        private void CloseVideoSource()
        {
            // set busy cursor
            this.Cursor = Cursors.WaitCursor;

            // stop current video source
            videoSourcePlayer.SignalToStop();

            // wait 2 seconds until camera stops
            for (int i = 0; (i < 50) && (videoSourcePlayer.IsRunning); i++)
            {
                Thread.Sleep(100);
            }
            if (videoSourcePlayer.IsRunning)
                videoSourcePlayer.Stop();

            // stop timers
            timer.Stop();
            alarmTimer.Stop();

            //motionHistory.Clear();

            //// reset motion detector
            //if (detector != null)
            //    detector.Reset();

            videoSourcePlayer.BorderColor = Color.Black;
            this.Cursor = Cursors.Default;
        }

        
    }
}
