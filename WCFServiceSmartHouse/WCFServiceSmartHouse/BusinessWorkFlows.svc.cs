using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceSmartHouse
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BusinessWorkFlows" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BusinessWorkFlows.svc or BusinessWorkFlows.svc.cs at the Solution Explorer and start debugging.
    public class BusinessWorkFlows : IBusinessWorkFlows
    {
        public void DoWork()
        {
        }

        /// <summary>
        /// Pass Device ID, Event Type, Event Value
        /// </summary>
        /// <param name="_deviceIDTypeValue"></param>
        public void SaveDeviceEventLog(string[] _deviceIDTypeValue)
        {
            Devices _deviceObj=new Devices();
            string[] _deviceEventLogData=new string[5];

            string[] _deviceData = _deviceObj.GetDeviceData(_deviceIDTypeValue[0]);
            if (Convert.ToBoolean(_deviceData[3]) == true)
            {

                DeviceEventLog _deviceEventLogobj=new DeviceEventLog();

                //TO DO LATER TO CHECK THE CONFIGURATION TO ADD THE EVENT TYPE IF WARNING

                _deviceEventLogData[0] = "Normal";

                //END TO DO LATER TO CHECK THE CONFIGURATION TO ADD THE EVENT TYPE IF WARNING

                _deviceEventLogData[1] = _deviceIDTypeValue[1];
                _deviceEventLogData[2] = _deviceData[0];
                _deviceEventLogData[3] = _deviceData[2];
                _deviceEventLogData[4] = _deviceIDTypeValue[2];

                _deviceEventLogobj.AddDeviceEventLog(_deviceEventLogData);

            }
            else
            {
                
            }
        }

        public void AutoScheduleChecksAndActions()
        {
            ScheduleRecurrence _src=new ScheduleRecurrence();
            Devices _deviceObj=new Devices();

            string[] _scheduleDeviceObjectID = _src.GetAllDevicesObjectID();
            string[] _deviceData=new string[4];
            _deviceData[1] = "null";
            _deviceData[2] = "null";

            for (int i = 0; i < _scheduleDeviceObjectID.Length; i++)
            {
                DateTime _currentDateTime = DateTime.Now;
                

                string[] _scheduleData = _src.GetScheduleData(_scheduleDeviceObjectID[i]);
                _deviceData[0] = _scheduleData[1];
                

                if(_scheduleData[7]=="Once" && _scheduleData[9]=="False")
                {
                    //check the whole Month Date + time
                    DateTime _systemDateTime = DateTime.Parse(_scheduleData[5].Trim() + ", " + _scheduleData[3]);
                    if(_currentDateTime>_systemDateTime)
                    {
                        //check ScheduleCase
                        if(_scheduleData[8]=="On")
                        {
                            _deviceData[3] = "True";
                            _deviceObj.UpdateDevice(_deviceData);
                        }

                        else if (_scheduleData[8] == "Off")
                        {
                            _deviceData[3] = "False";
                            _deviceObj.UpdateDevice(_deviceData);
                        }

                        else if (_scheduleData[8]=="Alarm")
                        {
                            
                        }

                        //Update scheduleDone to True.
                        string[] _scheduleDoneUpdate=new string[2];

                        _scheduleDoneUpdate[0] = _scheduleData[0];
                        _scheduleDoneUpdate[1] = "True";

                        _src.UpdateScheduleDone(_scheduleDoneUpdate);
                    }

                    else
                    {
                        
                    }

                }

                else if (_scheduleData[7] == "Daily" && _scheduleData[9] == "False")
                {
                    //Don't care about the date itself. Only care about the time.
                    DateTime _systemDateTime = DateTime.Parse(_scheduleData[5].Trim() + ", " + _scheduleData[3]);
                    

                    if (_currentDateTime.TimeOfDay > _systemDateTime.TimeOfDay)
                    {
                        //check ScheduleCase
                        if (_scheduleData[8] == "On")
                        {
                            _deviceData[3] = "True";
                            _deviceObj.UpdateDevice(_deviceData);
                        }

                        else if (_scheduleData[8] == "Off")
                        {
                            _deviceData[3] = "False";
                            _deviceObj.UpdateDevice(_deviceData);
                        }

                        else if (_scheduleData[8] == "Alarm")
                        {

                        }

                        //Update scheduleDone to True.
                        //No Update Required since it is recurrence.
                    }

                    else
                    {

                    }
                }

                else if (_scheduleData[7] == "Weekly" && _scheduleData[9] == "False")
                {

                    DateTime _systemDateTime = DateTime.Parse(_scheduleData[5].Trim() + ", " + _scheduleData[3]);


                    if (_currentDateTime.DayOfWeek.ToString().Trim()==_scheduleData[4] 
                        && _currentDateTime.TimeOfDay > _systemDateTime.TimeOfDay)
                    {
                        //check ScheduleCase
                        if (_scheduleData[8] == "On")
                        {
                            _deviceData[3] = "True";
                            _deviceObj.UpdateDevice(_deviceData);
                        }

                        else if (_scheduleData[8] == "Off")
                        {
                            _deviceData[3] = "False";
                            _deviceObj.UpdateDevice(_deviceData);
                        }

                        else if (_scheduleData[8] == "Alarm")
                        {

                        }

                        //Update scheduleDone to True.
                        //No Update Required since it is recurrence.
                    }

                    else
                    {

                    }
                }

                else if (_scheduleData[7] == "Monthly" && _scheduleData[9] == "False")
                {
                    //check the whole Month Date + time
                    DateTime _systemDateTime = DateTime.Parse(_scheduleData[5].Trim() + ", " + _scheduleData[3]);
                    if (_currentDateTime > _systemDateTime)
                    {
                        //check ScheduleCase
                        if (_scheduleData[8] == "On")
                        {
                            _deviceData[3] = "True";
                            _deviceObj.UpdateDevice(_deviceData);
                        }

                        else if (_scheduleData[8] == "Off")
                        {
                            _deviceData[3] = "False";
                            _deviceObj.UpdateDevice(_deviceData);
                        }

                        else if (_scheduleData[8] == "Alarm")
                        {

                        }

                        //Update scheduleDone to True.
                        //No Update Required since it is recurrence.
                    }

                    else
                    {

                    }
                }
            }
        }

        public void SaveDeviceEventLogWithAlarmChecks(string[] _deviceIDTypeValue)
        {
            Devices _deviceObj = new Devices();
            string[] _deviceEventLogData = new string[5];

            string[] _deviceData = _deviceObj.GetDeviceData(_deviceIDTypeValue[0]);
            if (Convert.ToBoolean(_deviceData[3]) == true)
            {

                DeviceEventLog _deviceEventLogobj = new DeviceEventLog();

                //TO DO LATER TO CHECK THE CONFIGURATION TO ADD THE EVENT TYPE IF WARNING

                ScheduleRecurrence _src = new ScheduleRecurrence();

                string[] _scheduleDeviceObjectID = _src.GetAllDevicesObjectID();
                string _eventType = "Normal";

                for (int i = 0; i < _scheduleDeviceObjectID.Length; i++)
                {
                    DateTime _currentDateTime = DateTime.Now;


                    string[] _scheduleData = _src.GetScheduleData(_scheduleDeviceObjectID[i]);

                    if (_scheduleData[1] == _deviceIDTypeValue[0])
                    {

                        if (_scheduleData[7] == "Once" && _scheduleData[9] == "False")
                        {
                            //check the whole Month Date + time
                            DateTime _systemDateTime = DateTime.Parse(_scheduleData[5].Trim() + ", " + _scheduleData[3]);
                            if (_currentDateTime > _systemDateTime)
                            {
                                //check ScheduleCase
                                if (_scheduleData[8] == "On")
                                {

                                }

                                else if (_scheduleData[8] == "Off")
                                {

                                }

                                else if (_scheduleData[8] == "Alarm")
                                {
                                    _eventType = "Alarm";
                                }
                            }

                            else
                            {

                            }

                        }

                        else if (_scheduleData[7] == "Daily" && _scheduleData[9] == "False")
                        {
                            //Don't care about the date itself. Only care about the time.
                            DateTime _systemDateTime = DateTime.Parse(_scheduleData[5].Trim() + ", " + _scheduleData[3]);


                            if (_currentDateTime.TimeOfDay > _systemDateTime.TimeOfDay)
                            {
                                //check ScheduleCase
                                if (_scheduleData[8] == "On")
                                {

                                }

                                else if (_scheduleData[8] == "Off")
                                {

                                }

                                else if (_scheduleData[8] == "Alarm")
                                {
                                    _eventType = "Alarm";
                                }

                            }

                            else
                            {

                            }
                        }

                        else if (_scheduleData[7] == "Weekly" && _scheduleData[9] == "False")
                        {

                            DateTime _systemDateTime = DateTime.Parse(_scheduleData[5].Trim() + ", " + _scheduleData[3]);


                            if (_currentDateTime.DayOfWeek.ToString().Trim() == _scheduleData[4]
                                && _currentDateTime.TimeOfDay > _systemDateTime.TimeOfDay)
                            {
                                //check ScheduleCase
                                if (_scheduleData[8] == "On")
                                {

                                }

                                else if (_scheduleData[8] == "Off")
                                {

                                }

                                else if (_scheduleData[8] == "Alarm")
                                {
                                    _eventType = "Alarm";
                                }
                            }

                            else
                            {

                            }
                        }

                        else if (_scheduleData[7] == "Monthly" && _scheduleData[9] == "False")
                        {
                            //check the whole Month Date + time
                            DateTime _systemDateTime = DateTime.Parse(_scheduleData[5].Trim() + ", " + _scheduleData[3]);
                            if (_currentDateTime > _systemDateTime)
                            {
                                //check ScheduleCase
                                if (_scheduleData[8] == "On")
                                {

                                }

                                else if (_scheduleData[8] == "Off")
                                {

                                }

                                else if (_scheduleData[8] == "Alarm")
                                {
                                    _eventType = "Alarm";
                                }
                            }

                            else
                            {

                            }
                        }

                        if(_eventType=="Alarm")
                        {
                            //Check Config Alarm Value

                            DevicesAlarmConfiguration _dac=new DevicesAlarmConfiguration();

                            string[] _deviceAlarmConfigData= _dac.GetDeviceAlarmConfigData(_deviceIDTypeValue[0]);

                            if(_deviceAlarmConfigData[2]=="Over")
                            {
                                if (Convert.ToDouble(_deviceIDTypeValue[2]) > Convert.ToDouble(_deviceAlarmConfigData[1]))
                                {
                                    _eventType = "Warning";
                                }
                                else
                                {
                                    _eventType = "Normal";
                                }
                            }

                            else if(_deviceAlarmConfigData[2]=="Less")
                            {
                                if (Convert.ToDouble(_deviceIDTypeValue[2]) < Convert.ToDouble(_deviceAlarmConfigData[1]))
                                {
                                    _eventType = "Warning";
                                }
                                else
                                {
                                    _eventType = "Normal";
                                }
                            }
                             
                            else if(_deviceAlarmConfigData[2]=="Equal")
                            {
                                if (Convert.ToDouble(_deviceIDTypeValue[2]) == Convert.ToDouble(_deviceAlarmConfigData[1]))
                                {
                                    _eventType = "Warning";
                                }
                                else
                                {
                                    _eventType = "Normal";
                                }
                            }
                         
                        }

                        _deviceEventLogData[0] = _eventType;

                        //END TO DO LATER TO CHECK THE CONFIGURATION TO ADD THE EVENT TYPE IF WARNING

                        _deviceEventLogData[1] = _deviceIDTypeValue[1];
                        _deviceEventLogData[2] = _deviceData[0];
                        _deviceEventLogData[3] = _deviceData[2];
                        _deviceEventLogData[4] = _deviceIDTypeValue[2];

                        _deviceEventLogobj.AddDeviceEventLog(_deviceEventLogData);
                    }

                }
            }
            else
            {

            }
        }

        public string[] VerifyUserNameAndPassword(string _userName, string _password)
        {
            Users _usr=new Users();

            string[] _userObjectIDAndRoleData = new string[2];

            string[] _userData=_usr.GetUserDataByName(_userName);

            if(_userData[1]==_userName && _userData[2]==_password)
            {
                _userObjectIDAndRoleData[0] = _userData[0];
                _userObjectIDAndRoleData[1] = _userData[3];
            }
            else
            {
                _userObjectIDAndRoleData[0] = "0";
                _userObjectIDAndRoleData[1] = "0";
            }

            //Return UserObjectID in case of success matching and 0 in case of not matching

            return _userObjectIDAndRoleData;
        }

    }
}
