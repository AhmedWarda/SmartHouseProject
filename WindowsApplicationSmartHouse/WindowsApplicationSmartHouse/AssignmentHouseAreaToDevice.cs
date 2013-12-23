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
using WindowsApplicationSmartHouse.DevicesService;
using WindowsApplicationSmartHouse.HouseAreaService;

namespace WindowsApplicationSmartHouse
{
    public partial class AssignmentHouseAreaToDevice : Form
    {
        public AssignmentHouseAreaToDevice()
        {
            InitializeComponent();
        }

        private Dictionary<string, string> _dictionaryHouseAreaIDsAndNames = new Dictionary<string, string>();
        private Dictionary<string, string> _dictionaryDeviceIDsAndNames = new Dictionary<string, string>();
        private ArrayList _devicesIdList = new ArrayList();

        public void LoadAreaAndDeviceControls()
        {
            //Fill Combobox of Area.
            HouseAreaService.HouseAreaClient _has = new HouseAreaClient();
            DevicesService.DevicesClient _dc = new DevicesClient();

            string[] _houseAreaIDs = _has.GetAllHouseAreasID();

            for (int i = 0; i < _houseAreaIDs.Length; i++)
            {
                string[] _houseAreaData = _has.GetHouseAreaData(_houseAreaIDs[i]);
                comboBoxAreaName.Items.Add(_houseAreaData[1]);
                _dictionaryHouseAreaIDsAndNames.Add(_houseAreaData[1], _houseAreaData[0]);
            }

            //Fill Combo Box of Device.
            string[] _deviceIDs = _dc.GetAllDevicesID();

            for (int i = 0; i < _deviceIDs.Length; i++)
            {
                string[] _deviceData = _dc.GetDeviceData(_deviceIDs[i]);
                comboBoxDeviceName.Items.Add(_deviceData[1]);
                _dictionaryDeviceIDsAndNames.Add(_deviceData[1], _deviceData[0]);
            }

        }

        public void AddNewRowGridDevicesAndArea()
        {
            string[] _data = new string[5];
            _data[0] = "";
            _data[1] = textBoxAreaID.Text.Trim();
            _data[2] = comboBoxAreaName.SelectedItem.ToString().Trim();
            _data[3] = textBoxDeviceID.Text.Trim();
            _data[4] = comboBoxDeviceName.SelectedItem.ToString().Trim();


            dataGridViewAreaDevicesAssign.Rows.Add(_data);
        }

        public void ShowDevicesAssignedToAreaSeleted()
        {
            dataGridViewAreaDevicesAssign.Rows.Clear();
            DevicesService.DevicesClient _dc=new DevicesClient();
            string[] _deviceIDs = _dc.GetAllDevicesID();

            for (int i = 0; i < _deviceIDs.Length; i++)
            {
                string[] _deviceData = _dc.GetDeviceData(_deviceIDs[i]);

                //Fill The Grid
                if (_deviceData[2]==textBoxAreaID.Text.Trim())
                {
                    dataGridViewAreaDevicesAssign.Rows.Add("1", _deviceData[2], comboBoxAreaName.SelectedItem.ToString(),
                                                           _deviceData[0], _deviceData[1]);
                }
            }
        }

        private void AssignmentHouseAreaToDevice_Load(object sender, EventArgs e)
        {
            LoadAreaAndDeviceControls();
        }

        private void comboBoxAreaName_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxAreaID.Text = _dictionaryHouseAreaIDsAndNames[comboBoxAreaName.SelectedItem.ToString()];

            //Show Grid with what is assigned to chosen area.
            ShowDevicesAssignedToAreaSeleted();

        }

        private void comboBoxDeviceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxDeviceID.Text = _dictionaryDeviceIDsAndNames[comboBoxDeviceName.SelectedItem.ToString()];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRowGridDevicesAndArea();
        }

       
        private void btnSave_Click(object sender, EventArgs e)
        {
            DevicesService.DevicesClient _dc=new DevicesClient();

            string[] _deviceData=new string[4];
            
            _deviceData[1] = "null";
            _deviceData[3] = "null";

            //Update what is in the Grid
            for (int i = 0; i < dataGridViewAreaDevicesAssign.Rows.Count; i++)
            {
                _deviceData[0] = dataGridViewAreaDevicesAssign.Rows[i].Cells[_colDeviceID.Name].Value.ToString().Trim();
                _deviceData[2] = dataGridViewAreaDevicesAssign.Rows[i].Cells[_colAreaID.Name].Value.ToString().Trim();

                _dc.UpdateDevice(_deviceData);
            }
            
            //Update what is supposed to be deleted.
            for (int i = 0; i < _devicesIdList.Count; i++)
            {
                _deviceData[0] = _devicesIdList[i].ToString();
                _deviceData[2] = " ";
                _dc.UpdateDevice(_deviceData);

            }

            MessageBox.Show("Data is saved successfully");

        }
    }
}
