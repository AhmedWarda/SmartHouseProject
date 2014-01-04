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
using WindowsApplicationSmartHouse.ScheduleRecurrenceService;

namespace WindowsApplicationSmartHouse
{
    public partial class Scheduling : Form
    {
        public Scheduling()
        {
            InitializeComponent();
        }

        private Dictionary<string, string> _dictionaryHouseAreaIDsAndNames = new Dictionary<string, string>();
        private Dictionary<string, string> _dictionaryDeviceIDsAndNames = new Dictionary<string, string>();
        private ArrayList _devicesObjectIdList = new ArrayList();

        public void LoadAreaControls()
        {
            //Fill Combobox of Area.
            HouseAreaService.HouseAreaClient _has = new HouseAreaClient();

            string[] _houseAreaIDs = _has.GetAllHouseAreasID();

            for (int i = 0; i < _houseAreaIDs.Length; i++)
            {
                string[] _houseAreaData = _has.GetHouseAreaData(_houseAreaIDs[i]);
                comboBoxAreaName.Items.Add(_houseAreaData[1]);
                _dictionaryHouseAreaIDsAndNames.Add(_houseAreaData[1], _houseAreaData[0]);
            }

        }

        public void LoadDevicesAssignedToArea()
        {
            DevicesService.DevicesClient _dc = new DevicesClient();
            _dictionaryDeviceIDsAndNames.Clear();
            comboBoxDeviceName.Items.Clear();

            string[] _deviceIDs = _dc.GetAllDevicesID();

            for (int i = 0; i < _deviceIDs.Length; i++)
            {
                string[] _deviceData = _dc.GetDeviceData(_deviceIDs[i]);

                if (_deviceData[2] == textBoxAreaID.Text.Trim())
                {

                    comboBoxDeviceName.Items.Add(_deviceData[1]);
                    _dictionaryDeviceIDsAndNames.Add(_deviceData[1], _deviceData[0]);
                }
                
            }

        }

        public void AddNewSchedule()
        {
            string[] _dataArray=new string[10];

            _dataArray[0] = "";//ObjectID
            _dataArray[1]= textBoxDeviceID.Text;//DeviceID
            _dataArray[2]= comboBoxDeviceName.SelectedItem.ToString();//DeviceName
            _dataArray[3]=dateTimePickerTime.Value.ToLongTimeString();//Time

            //Depend on the Once, Daily, Weekly, Monthly
            if (radioButtonDaily.Checked)
            {
                _dataArray[4] = ""; //DayName
                _dataArray[6] = "Recurrence";//ScheduleType
                _dataArray[7] = radioButtonDaily.Text;//RecurrenceType
            }

            else if (radioButtonWeekly.Checked)
            {
                _dataArray[4] = comboBoxWeekDay.SelectedItem.ToString(); //DayName
                _dataArray[6] = "Recurrence";//ScheduleType
                _dataArray[7] = radioButtonWeekly.Text;//RecurrenceType
            }


            else if (radioButtonMonthly.Checked)
            {
                _dataArray[4] = ""; //DayName
                _dataArray[6] = "Recurrence";//ScheduleType
                _dataArray[7] = radioButtonMonthly.Text;//RecurrenceType
            }

            else if (radioButtonOnce.Checked)
            {
                _dataArray[4] = ""; //DayName
                _dataArray[6] = "Once";//ScheduleType
                _dataArray[7] = radioButtonOnce.Text;//RecurrenceType
            }

            _dataArray[5] = dateTimePickerDate.Value.ToShortDateString();//Date
            _dataArray[8] = comboBoxScheduleCase.SelectedItem.ToString();
            _dataArray[9] = "False";

            dataGridViewScheduling.Rows.Add(_dataArray);
        }

        public void RefreshGridWithAssignedSchedule()
        {
            dataGridViewScheduling.Rows.Clear();
            ScheduleRecurrenceService.ScheduleRecurrenceClient _src=new ScheduleRecurrenceClient();

            string[] _scheduleDeviceObjectIDs = _src.GetAllDevicesObjectID();

            for (int i = 0; i < _scheduleDeviceObjectIDs.Length; i++)
            {
                string[] _scheduleData = _src.GetScheduleData(_scheduleDeviceObjectIDs[i]);

                if (_scheduleData[1] == textBoxDeviceID.Text)
                {

                    dataGridViewScheduling.Rows.Add(_scheduleData);
                }

            }
        }

        private void Scheduling_Load(object sender, EventArgs e)
        {
            LoadAreaControls();
        }

        private void comboBoxAreaName_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxAreaID.Text = _dictionaryHouseAreaIDsAndNames[comboBoxAreaName.SelectedItem.ToString()];

            //Show Devices assigned to chosen area.
            LoadDevicesAssignedToArea();
            textBoxDeviceID.Text = null;
            dataGridViewScheduling.Rows.Clear();

        }


        private void comboBoxDeviceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxDeviceID.Text = _dictionaryDeviceIDsAndNames[comboBoxDeviceName.SelectedItem.ToString()];
            dataGridViewScheduling.Rows.Clear();
            RefreshGridWithAssignedSchedule();
            radioButtonOnce.Checked = true;
            radioButtonOnce_MouseClick(null,null);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewSchedule();
        }

        private void radioButtonOnce_MouseClick(object sender, MouseEventArgs e)
        {
            comboBoxWeekDay.Enabled = false;
            dateTimePickerDate.Enabled = true;
            dateTimePickerTime.Enabled = true;
        }

        private void radioButtonDaily_MouseClick(object sender, MouseEventArgs e)
        {
            comboBoxWeekDay.Enabled = false;
            dateTimePickerDate.Enabled = false;
            dateTimePickerTime.Enabled = true;
        }

        private void radioButtonWeekly_MouseClick(object sender, MouseEventArgs e)
        {
            comboBoxWeekDay.Enabled = true;
            dateTimePickerDate.Enabled = false;
            dateTimePickerTime.Enabled = true;
        }

        private void radioButtonMonthly_MouseClick(object sender, MouseEventArgs e)
        {
            comboBoxWeekDay.Enabled = false;
            dateTimePickerDate.Enabled = true;
            dateTimePickerTime.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewScheduling.Rows[dataGridViewScheduling.CurrentRow.Index].Cells[_colObjectID.Name].Value != "")
            {

                _devicesObjectIdList.Add(
                    dataGridViewScheduling.Rows[dataGridViewScheduling.CurrentRow.Index].Cells[_colObjectID.Name].Value.
                        ToString()
                        .Trim());
            }

            dataGridViewScheduling.Rows.RemoveAt(dataGridViewScheduling.CurrentRow.Index);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ScheduleRecurrenceService.ScheduleRecurrenceClient _src=new ScheduleRecurrenceClient();

            for (int i = 0; i < dataGridViewScheduling.Rows.Count; i++)
            {
                //Add New Schedule

                if (dataGridViewScheduling.Rows[i].Cells[_colObjectID.Name].Value != "")
                {

                }

                else
                {
                    string[] _scheduleData = new string[9];
                    _scheduleData[0] = dataGridViewScheduling.Rows[i].Cells[_colDeviceID.Name].Value.ToString().Trim();
                        //DeviceID
                    _scheduleData[1] = dataGridViewScheduling.Rows[i].Cells[_colDeviceName.Name].Value.ToString().Trim();
                        //DeviceName
                    _scheduleData[2] =
                        dataGridViewScheduling.Rows[i].Cells[_colRecurrenceType.Name].Value.ToString().Trim();
                        //RecurrenceType
                    _scheduleData[3] =
                        dataGridViewScheduling.Rows[i].Cells[_colRecurrenceHourMinSec.Name].Value.ToString().Trim();
                        //RecurrenceHourMinSec
                    _scheduleData[4] = dataGridViewScheduling.Rows[i].Cells[_colDayDate.Name].Value.ToString().Trim();
                        //RecurrenceDayDate
                    _scheduleData[5] = dataGridViewScheduling.Rows[i].Cells[_colDayWeek.Name].Value.ToString().Trim();
                        //RecurrenceDayWeek
                    _scheduleData[6] =
                        dataGridViewScheduling.Rows[i].Cells[_colScheduleCase.Name].Value.ToString().Trim();
                        //ScheduleCase
                    _scheduleData[7] =
                        dataGridViewScheduling.Rows[i].Cells[_colScheduleType.Name].Value.ToString().Trim();
                        //ScheduleType
                    _scheduleData[8] =
                        dataGridViewScheduling.Rows[i].Cells[_colScheduleDone.Name].Value.ToString().Trim();
                        //ScheduleDone

                    _src.AddSchedule(_scheduleData);
                }
            }

            //Delete

            for (int i = 0; i < _devicesObjectIdList.Count; i++)
            {
                _src.DeleteSchedule(_devicesObjectIdList[i].ToString().Trim());
            }

            _devicesObjectIdList.Clear();
            //refresh
            RefreshGridWithAssignedSchedule();

            MessageBox.Show("Data is saved successfully");
        }
    }
}
