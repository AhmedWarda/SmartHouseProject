using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsApplicationSmartHouse.BusinessWorkFlowService;

namespace WindowsApplicationSmartHouse
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            _port = new SerialPort();
            _port.PortName = "COM5";
            _port.BaudRate = 9600;
            _port.Parity = System.IO.Ports.Parity.None;
            _port.DataBits = 8;
            _port.StopBits = System.IO.Ports.StopBits.One;
            _port.Handshake = System.IO.Ports.Handshake.None;
            _port.RtsEnable = true;

            //_port.Open();
            _port.DataReceived += _port_DataReceived;
        }

        void _port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Line:
            string data = _port.ReadExisting();

            if (data != "")
            {
                _lastData += data;
                System.Threading.Thread.Sleep(60);
                goto Line;
            }

            //listBox1.Items.Add(_lastData);

            //Send Data to be saved in the database and business checks.

            string[] _lastDataSplit = _lastData.Split('_');

            BusinessWorkFlowService.BusinessWorkFlowsClient _businessWorkFlowObj = new BusinessWorkFlowsClient();
            
            //_businessWorkFlowObj.SaveDeviceEventLog(_lastDataSplit);

            string _resultOfSavingEvent=_businessWorkFlowObj.SaveDeviceEventLogWithAlarmChecks(_lastDataSplit);

            //END Send Data to be saved in the database and business checks.

            _lastData = null;
        }


        private SerialPort _port;
        private string _lastData = "";

        private void Main_Load(object sender, EventArgs e)
        {
            //LoginForm _login=new LoginForm();

            //_login.ShowDialog();

            //if (_login.IsValid)
            //{
            //    Check role

            //    if (_login.UserRole=="Admin")
            //    {
                    
            //    }

            //    else if (_login.UserRole=="User")
            //    {
            //        MenuDefinition.Visible = false;
            //        configurationToolStripMenuItem.Visible = false;
            //    }

                this.WindowState = FormWindowState.Maximized;
                Form1 f1=new Form1();
            f1.Show();
            f1.WindowState = FormWindowState.Minimized;
            //}

            //else
            //{
            //    this.Close();
            //}
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void devicesViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDeviceStatus newMDIChild = new ViewDeviceStatus();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            //newMDIChild.WindowState = FormWindowState.Maximized;

            newMDIChild.Show();

            
        }

        private void homeAreasViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void devicesStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DevicesAlarmConfiguration newMDIChild = new DevicesAlarmConfiguration();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            //newMDIChild.WindowState = FormWindowState.Maximized;

            newMDIChild.Show();
        }

        private void Devices_Click(object sender, EventArgs e)
        {
            DevicesDefinition newMDIChild = new DevicesDefinition();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            //newMDIChild.WindowState = FormWindowState.Maximized;

            newMDIChild.Show();
        }

        private void homeAreasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HouseAreaDefinition newMDIChild = new HouseAreaDefinition();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            //newMDIChild.WindowState = FormWindowState.Maximized;

            newMDIChild.Show();
        }

        private void schedulingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scheduling newMDIChild = new Scheduling();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            //newMDIChild.WindowState = FormWindowState.Maximized;

            newMDIChild.Show();
        }

        private void videoCamerasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VideoMotionDetection newMDIChild = new VideoMotionDetection();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            //newMDIChild.WindowState = FormWindowState.Maximized;

            newMDIChild.Show();

        }
    }
}
