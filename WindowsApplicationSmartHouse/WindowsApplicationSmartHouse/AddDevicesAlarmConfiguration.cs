using System;
using System.Collections;
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
    public partial class AddDevicesAlarmConfiguration : Form
    {
        public AddDevicesAlarmConfiguration()
        {
            InitializeComponent();
            ShowAllDevices();
        }

        private string AddEditFlag;
        Dictionary<string, string> _GDictionaryDevicesIDName = new Dictionary<string, string>();

        public string PropDeviceName
        {
            get { return ComboxDeviceName.Items[ComboxDeviceName.SelectedIndex].ToString(); }
            set { ComboxDeviceName.SelectedItem = value; }
        }

        public string PropAlarmValue
        {
            get { return txtBoxAlarmValue.Text; }
            set { txtBoxAlarmValue.Text = value; }
        }

        public string PropCondition
        {
            get { return ComboBoxCondition.Items[ComboBoxCondition.SelectedIndex].ToString(); }
            set { ComboBoxCondition.SelectedItem = value; }
        }

        public string PropAddEditFlag
        {
            get { return AddEditFlag; }
            set { AddEditFlag = value; }
        }

        public void ShowAllDevices()
        {

            DevicesService.DevicesClient _dc = new DevicesService.DevicesClient();


            string[] _devicesID = _dc.GetAllDevicesID();


            for (int i = 0; i < _devicesID.Length; i++)
            {
                string[] _deviceData = _dc.GetDeviceData(_devicesID[i]);
                _GDictionaryDevicesIDName.Add(_deviceData[1], _devicesID[i]);

                ComboxDeviceName.Items.Add(_deviceData[1]);

            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            DevicesAlarmConfigurationService.DevicesAlarmConfigurationClient _dac=new DevicesAlarmConfigurationClient();

            string[] _devicesAlarmConfigData=new string[3];

            _devicesAlarmConfigData[0] = txtBoxDeviceID.Text.Trim();
            _devicesAlarmConfigData[1] = txtBoxAlarmValue.Text.Trim();
            _devicesAlarmConfigData[2] = ComboBoxCondition.Items[ComboBoxCondition.SelectedIndex].ToString();

            if (AddEditFlag == "New")
            {
                _dac.AddDeviceAlarmConfiguration(_devicesAlarmConfigData);
            }
            else if (AddEditFlag == "Edit")
            {
                _dac.UpdateDeviceAlarmConfiguration(_devicesAlarmConfigData);
            }

            MessageBox.Show("Save is successed");
        }

        private void AddDevicesAlarmConfiguration_Load(object sender, EventArgs e)
        {
            //ShowAllDevices();
        }

        private void ComboxDeviceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBoxDeviceID.Text = _GDictionaryDevicesIDName[ComboxDeviceName.Items[ComboxDeviceName.SelectedIndex].ToString()];
        }
    }
}
