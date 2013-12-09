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


namespace WindowsApplicationSmartHouse
{
    public partial class DevicesDefinition : Form
    {
        public DevicesDefinition()
        {
            InitializeComponent();
        }

        public void ShowAllDevices()
        {
            dataGridViewDevices.Rows.Clear();

            DevicesService.DevicesClient _dc = new DevicesService.DevicesClient();

            string[] _devicesID = _dc.GetAllDevicesID();


            for (int i = 0; i < _devicesID.Length; i++)
            {
                string[] _deviceData = _dc.GetDeviceData(_devicesID[i]);

                dataGridViewDevices.Rows.Add();
                dataGridViewDevices[_colDeviceAlreadyinDB.Name, i].Value = "1"; //Device in database already.
                dataGridViewDevices[_colDeviceID.Name, i].Value = _deviceData[0];
                dataGridViewDevices[_colDeviceName.Name, i].Value = _deviceData[1];
                dataGridViewDevices[_colDeviceAreaAssign.Name, i].Value = _deviceData[2];
                dataGridViewDevices[_colDeviceStatus.Name, i].Value = _deviceData[3];

            }
        }

        ArrayList _deviceList=new ArrayList();  

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowAllDevices();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            dataGridViewDevices.Rows.Add();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (dataGridViewDevices.Rows[dataGridViewDevices.CurrentRow.Index].Cells[_colDeviceID.Name].Value!=null)
            {

                _deviceList.Add(
                    dataGridViewDevices.Rows[dataGridViewDevices.CurrentRow.Index].Cells[_colDeviceID.Name].Value.
                        ToString()
                        .Trim());
            }

            dataGridViewDevices.Rows.RemoveAt(dataGridViewDevices.CurrentRow.Index);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            //Add New and Update Current

            DevicesService.DevicesClient _dc=new DevicesClient();

            for (int i = 0; i < dataGridViewDevices.Rows.Count; i++)
            {
                if(dataGridViewDevices.Rows[i].Cells[_colDeviceAlreadyinDB.Name].Value!=null)
                {
                   //Update
                    string[] _deviceData = new string[4];
                    _deviceData[0] = dataGridViewDevices.Rows[i].Cells[_colDeviceID.Name].Value.ToString().Trim();
                    _deviceData[1] = dataGridViewDevices.Rows[i].Cells[_colDeviceName.Name].Value.ToString().Trim();
                    _deviceData[2] = dataGridViewDevices.Rows[i].Cells[_colDeviceAreaAssign.Name].Value.ToString().Trim();
                    _deviceData[3] = dataGridViewDevices.Rows[i].Cells[_colDeviceStatus.Name].Value.ToString().Trim();

                    _dc.UpdateDevice(_deviceData);

                }

                else 
                {
                    //Add New
                    string[] _deviceData = new string[4];
                    _deviceData[0] = dataGridViewDevices.Rows[i].Cells[_colDeviceID.Name].Value.ToString().Trim();
                    _deviceData[1] = dataGridViewDevices.Rows[i].Cells[_colDeviceName.Name].Value.ToString().Trim();
                    _deviceData[2] = " ";
                    _deviceData[3] = dataGridViewDevices.Rows[i].Cells[_colDeviceStatus.Name].Value.ToString().Trim();

                    _dc.AddDevice(_deviceData);

                }
            }

            //Delete

            for (int i = 0; i < _deviceList.Count; i++)
            {
                _dc.DeleteDevice(_deviceList[i].ToString().Trim());
            }
        }
    }
}
