using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsApplicationSmartHouse.DeviceEventLogService;
using WindowsApplicationSmartHouse.DevicesService;

namespace WindowsApplicationSmartHouse
{
    public partial class ViewDeviceStatus : Form
    {
        public ViewDeviceStatus()
        {
            InitializeComponent();
        }

        public void ShowAllDevices()
        {
            dataGridViewDevices.Rows.Clear();

            DevicesService.DevicesClient _dc = new DevicesService.DevicesClient();
            DeviceEventLogService.DeviceEventLogClient _delc=new DeviceEventLogClient();

            string[] _devicesID = _dc.GetAllDevicesID();
            

            for (int i = 0; i < _devicesID.Length; i++)
            {
                string[] _deviceData = _dc.GetDeviceData(_devicesID[i]);

                string[] _deviceEventLogData = _delc.GetOneDeviceEventLog(_devicesID[i]);

                dataGridViewDevices.Rows.Add();

                dataGridViewDevices[_colDeviceID.Name, i].Value = _deviceData[0];
                dataGridViewDevices[_colDeviceName.Name, i].Value = _deviceData[1];
                dataGridViewDevices[_colDeviceValue.Name, i].Value = _deviceEventLogData[7];
                dataGridViewDevices[_colDeviceAssignedToRoomID.Name, i].Value = _deviceData[2];
                dataGridViewDevices[_colDeviceStatus.Name, i].Value = _deviceData[3];

            }
        }

        public void UpdateDevices()
        {
            DevicesService.DevicesClient _dc = new DevicesClient();
            string[] _deviceData=new string[4];

            for (int i = 0; i < dataGridViewDevices.Rows.Count; i++)
            {
                _deviceData[0] = dataGridViewDevices[_colDeviceID.Name, i].Value.ToString().Trim();
                _deviceData[1] = "null";
                _deviceData[2] = "null";
                _deviceData[3] = dataGridViewDevices[_colDeviceStatus.Name, i].Value.ToString().Trim();
                _dc.UpdateDevice(_deviceData);

            }
        }


        private void ViewDeviceStatus_Load(object sender, EventArgs e)
        {
            //ShowAllDevices();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowAllDevices();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateDevices();
        }
    }
}
