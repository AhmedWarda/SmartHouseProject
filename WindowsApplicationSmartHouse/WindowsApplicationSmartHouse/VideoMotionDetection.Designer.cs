namespace WindowsApplicationSmartHouse
{
    partial class VideoMotionDetection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
            this.btnShowVideo = new System.Windows.Forms.Button();
            this.btnApplyDetection = new System.Windows.Forms.Button();
            this.btnDetermineZone = new System.Windows.Forms.Button();
            this.alarmTimer = new System.Windows.Forms.Timer(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.videoSourcePlayer.ForeColor = System.Drawing.Color.White;
            this.videoSourcePlayer.Location = new System.Drawing.Point(223, 23);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Size = new System.Drawing.Size(459, 308);
            this.videoSourcePlayer.TabIndex = 3;
            this.videoSourcePlayer.VideoSource = null;
            this.videoSourcePlayer.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer_NewFrame);
            // 
            // btnShowVideo
            // 
            this.btnShowVideo.Location = new System.Drawing.Point(25, 23);
            this.btnShowVideo.Name = "btnShowVideo";
            this.btnShowVideo.Size = new System.Drawing.Size(138, 23);
            this.btnShowVideo.TabIndex = 4;
            this.btnShowVideo.Text = "Show Video";
            this.btnShowVideo.UseVisualStyleBackColor = true;
            this.btnShowVideo.Click += new System.EventHandler(this.btnShowVideo_Click);
            // 
            // btnApplyDetection
            // 
            this.btnApplyDetection.Location = new System.Drawing.Point(25, 64);
            this.btnApplyDetection.Name = "btnApplyDetection";
            this.btnApplyDetection.Size = new System.Drawing.Size(138, 23);
            this.btnApplyDetection.TabIndex = 5;
            this.btnApplyDetection.Text = "Apply Detection";
            this.btnApplyDetection.UseVisualStyleBackColor = true;
            this.btnApplyDetection.Click += new System.EventHandler(this.btnApplyDetection_Click);
            // 
            // btnDetermineZone
            // 
            this.btnDetermineZone.Location = new System.Drawing.Point(25, 110);
            this.btnDetermineZone.Name = "btnDetermineZone";
            this.btnDetermineZone.Size = new System.Drawing.Size(138, 23);
            this.btnDetermineZone.TabIndex = 7;
            this.btnDetermineZone.Text = "Determine Zone";
            this.btnDetermineZone.UseVisualStyleBackColor = true;
            this.btnDetermineZone.Click += new System.EventHandler(this.btnDetermineZone_Click);
            // 
            // alarmTimer
            // 
            this.alarmTimer.Tick += new System.EventHandler(this.alarmTimer_Tick);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // VideoMotionDetection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 419);
            this.Controls.Add(this.btnDetermineZone);
            this.Controls.Add(this.btnApplyDetection);
            this.Controls.Add(this.btnShowVideo);
            this.Controls.Add(this.videoSourcePlayer);
            this.Name = "VideoMotionDetection";
            this.Text = "VideoMotionDetection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VideoMotionDetection_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
        private System.Windows.Forms.Button btnShowVideo;
        private System.Windows.Forms.Button btnApplyDetection;
        private System.Windows.Forms.Button btnDetermineZone;
        private System.Windows.Forms.Timer alarmTimer;
        private System.Windows.Forms.Timer timer;
    }
}