using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsApplicationSmartHouse.DevicesAlarmConfigurationService;

namespace WindowsApplicationSmartHouse
{
    public partial class DevicesAlarmConfiguration : Form
    {
        public DevicesAlarmConfiguration()
        {
            InitializeComponent();
        }

        public void ShowAllDevicesAlarmConfig()
        {
            dataGridViewDevicesAlarmConfig.Rows.Clear();

            DevicesService.DevicesClient _dc = new DevicesService.DevicesClient();
            DevicesAlarmConfigurationService.DevicesAlarmConfigurationClient _dac=new DevicesAlarmConfigurationClient();

            string[] _devicesAlarmConfigID = _dac.GetAllDevicesAlarmConfigID();


            string[] _devicesID = _dc.GetAllDevicesID();


            for (int i = 0; i < _devicesAlarmConfigID.Length; i++)
            {
                string[] _deviceAlarmConfigData = _dac.GetDeviceAlarmConfigData(_devicesAlarmConfigID[i]);

                string[] _deviceData = _dc.GetDeviceData(_deviceAlarmConfigData[0]);

                //string[] _deviceEventLogData = _delc.GetOneDeviceEventLog(_devicesAlarmConfigID[i]);

                dataGridViewDevicesAlarmConfig.Rows.Add();

                dataGridViewDevicesAlarmConfig[_colDeviceID.Name, i].Value = _deviceAlarmConfigData[0];
                dataGridViewDevicesAlarmConfig[_ColDeviceName.Name, i].Value = _deviceData[1];
                dataGridViewDevicesAlarmConfig[_colAlarmValue.Name, i].Value = _deviceAlarmConfigData[1];
                dataGridViewDevicesAlarmConfig[_colConfigType.Name, i].Value = _deviceAlarmConfigData[2];

            }
        }



        private void DevicesAlarmConfiguration_Load(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowAllDevicesAlarmConfig();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DevicesAlarmConfigurationService.DevicesAlarmConfigurationClient _dac = new DevicesAlarmConfigurationClient();

            int _rowIndex = dataGridViewDevicesAlarmConfig.CurrentRow.Index;

            _dac.DeleteDeviceAlarmConfiguraion(
                dataGridViewDevicesAlarmConfig.Rows[_rowIndex].Cells[_colDeviceID.Name].Value.ToString().Trim());

            ShowAllDevicesAlarmConfig();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AddDevicesAlarmConfiguration _adac=new AddDevicesAlarmConfiguration();
            _adac.PropAddEditFlag = "New";
            _adac.ShowDialog();
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddDevicesAlarmConfiguration _adac = new AddDevicesAlarmConfiguration();

            _adac.PropAddEditFlag = "Edit";

            int _rowIndex = dataGridViewDevicesAlarmConfig.CurrentRow.Index;

            _adac.PropDeviceName =
                dataGridViewDevicesAlarmConfig.Rows[_rowIndex].Cells[_ColDeviceName.Name].Value.ToString();

            _adac.PropAlarmValue =
                dataGridViewDevicesAlarmConfig.Rows[_rowIndex].Cells[_colAlarmValue.Name].Value.ToString().Trim();

            _adac.PropCondition =
                dataGridViewDevicesAlarmConfig.Rows[_rowIndex].Cells[_colConfigType.Name].Value.ToString().Trim();

            _adac.ShowDialog();
        }
    }
}
