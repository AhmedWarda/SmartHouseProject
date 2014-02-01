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

        private void videoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        {
            lock (this)
            {
                if (detector != null)
                {
                    float motionLevel = detector.ProcessFrame(image);

                    if (motionLevel > motionAlarmLevel)
                    {
                        // flash for 2 seconds
                        flash = (int)(2 * (1000 / alarmTimer.Interval));
                        //Save Photo
                        string fileName = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +
                                          DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                        //Check if there is an Alarm
                        _deviceData[0] = "0000012345";
                        _deviceData[1] = "Video";
                        _deviceData[2] = "1";
                        if (_bwfc.IsThereAlarm(_deviceData)=="Warning")
                        {
                            image.Save("D:\\Caelum 2012\\Warda Daily Work\\" + fileName + ".jpg", 
                                System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        

                    }

                    // check objects' count
                    if (detector.MotionProcessingAlgorithm is BlobCountingObjectsProcessing)
                    {
                        BlobCountingObjectsProcessing countingDetector = (BlobCountingObjectsProcessing)detector.MotionProcessingAlgorithm;
                        detectedObjectsCount = countingDetector.ObjectsCount;
                    }
                    else
                    {
                        detectedObjectsCount = -1;
                    }

                    // accumulate history
                    motionHistory.Add(motionLevel);
                    if (motionHistory.Count > 300)
                    {
                        motionHistory.RemoveAt(0);
                    }

                    //if (showMotionHistoryToolStripMenuItem.Checked)
                    //    DrawMotionHistory(image);
                }
            }
        }

        private void SetMotionDetectionAlgorithm(IMotionDetector detectionAlgorithm)
        {
            lock (this)
            {
                detector.MotionDetectionAlgorithm = detectionAlgorithm;
                motionHistory.Clear();

                if (detectionAlgorithm is TwoFramesDifferenceDetector)
                {
                    if (
                        (detector.MotionProcessingAlgorithm is MotionBorderHighlighting) ||
                        (detector.MotionProcessingAlgorithm is BlobCountingObjectsProcessing))
                    {
                        motionProcessingType = 1;
                        SetMotionProcessingAlgorithm(new MotionAreaHighlighting());
                    }
                }
            }
        }

        private void SetMotionProcessingAlgorithm(IMotionProcessing processingAlgorithm)
        {
            lock (this)
            {
                detector.MotionProcessingAlgorithm = processingAlgorithm;
            }
        }



        private void btnShowVideo_Click(object sender, EventArgs e)
        {
            string[] _cameras = GetCameras();
            VideoCaptureDevice videoSource = new VideoCaptureDevice(_cameras[0]);
            OpenVideoSource(videoSource);
        }

        private void btnApplyDetection_Click(object sender, EventArgs e)
        {
            motionDetectionType = 1;
            SetMotionDetectionAlgorithm(new TwoFramesDifferenceDetector());
            motionProcessingType = 1;
            //motionProcessingType = 0;
            SetMotionProcessingAlgorithm(new MotionAreaHighlighting());
            //SetMotionProcessingAlgorithm(null);
        }

        private void btnDetermineZone_Click(object sender, EventArgs e)
        {
            Rectangle r = new Rectangle(271, 104, 195, 153);
            Rectangle[] recarray = new Rectangle[1];
            recarray[0] = r;
            detector.MotionZones = recarray;
        }

        private void VideoMotionDetection_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseVideoSource();
        }

        private void alarmTimer_Tick(object sender, EventArgs e)
        {
            if (flash != 0)
            {
                videoSourcePlayer.BorderColor = (flash % 2 == 1) ? Color.Black : Color.Red;
                flash--;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            IVideoSource videoSource = videoSourcePlayer.VideoSource;

            if (videoSource != null)
            {
                // get number of frames for the last second
                statCount[statIndex] = videoSource.FramesReceived;

                // increment indexes
                if (++statIndex >= statLength)
                    statIndex = 0;
                if (statReady < statLength)
                    statReady++;

                float fps = 0;

                // calculate average value
                for (int i = 0; i < statReady; i++)
                {
                    fps += statCount[i];
                }
                fps /= statReady;

                statCount[statIndex] = 0;

                //fpsLabel.Text = fps.ToString("F2") + " fps";
            }
        }
    }
}
