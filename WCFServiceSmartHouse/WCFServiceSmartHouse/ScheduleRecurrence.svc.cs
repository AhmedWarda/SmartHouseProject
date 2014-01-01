using System.Threading.Tasks;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceSmartHouse
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ScheduleRecurrence" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ScheduleRecurrence.svc or ScheduleRecurrence.svc.cs at the Solution Explorer and start debugging.
    public class ScheduleRecurrence : IScheduleRecurrence
    {
        public void DoWork()
        {
        }

        public ScheduleRecurrence()
        {
            //RecurrenceType: Daily, Weekly, Monthly
            //RecurrenceHourMinSec: HH:MM:SS AM or PM
            //RecurrenceDayDate: Date of day in month
            //RecurrenceDayWeek: Saturday, Sunday.... Friday
            //ScheduleCase: On/Off/Alarm
            //ScheduleType: Recurrence, Once
            //ScheduleDone: True (The system did it), False (The system did not proceed it)

            ParseClient.Initialize("3JiHrWw6NXQleET7bSyh5syRYCfB2bsNTR8NbNWS", "uh7QyInYQIXv4fCMqddJd9S9BwMFmy0VqHhAcgzz");
        }

        public string AddSchedule(string[] _scheduleData)
        {
            Task<int> _resultFlag;

            try
            {
                _resultFlag = InternalAddSchedule(_scheduleData);
            }

            catch (Exception)
            {

                throw;
            }

            return _resultFlag.Result.ToString();
        }

        public async Task<int> InternalAddSchedule(string[] _scheduleData)
        {
            int _resultFlag = 0;

            try
            {
                ParseObject ScheduleTable = new ParseObject("ScheduleRecurrence");

                ScheduleTable.Add("DeviceID", _scheduleData[0].ToString().Trim());
                ScheduleTable.Add("DeviceName", _scheduleData[1].ToString().Trim());
                ScheduleTable.Add("RecurrenceType", _scheduleData[2].ToString().Trim());
                ScheduleTable.Add("RecurrenceHourMinSec", _scheduleData[3].ToString().Trim());
                ScheduleTable.Add("RecurrenceDayDate", _scheduleData[4].ToString().Trim());
                ScheduleTable.Add("RecurrenceDayWeek", _scheduleData[5].ToString().Trim());
                ScheduleTable.Add("ScheduleCase", _scheduleData[6].ToString().Trim());
                ScheduleTable.Add("ScheduleType", _scheduleData[7].ToString().Trim());
                ScheduleTable.Add("ScheduleDone", Convert.ToBoolean(_scheduleData[8].ToString().Trim()));

                await ScheduleTable.SaveAsync();
                _resultFlag = 1;
            }
            catch (Exception)
            {
                _resultFlag = 0;

            }

            return _resultFlag;
        }

        public string DeleteSchedule(string _deviceObjectID)
        {
            Task<int> _resultFlag;

            try
            {
                _resultFlag = InternalDeleteSchedule(_deviceObjectID);
                

            }

            catch (Exception)
            {

                throw;
            }

            return _resultFlag.Result.ToString();
        }

        public async Task<int> InternalDeleteSchedule(string _deviceObjectID)
        {
            int _resultFlag = 0;
            try
            {
                ParseQuery<ParseObject> query = ParseObject.GetQuery("ScheduleRecurrence");
                ParseObject _parseObject = await query.GetAsync(_deviceObjectID);

                 await _parseObject.DeleteAsync();

                _resultFlag = 1;
            }
            catch (Exception)
            {

                throw;
            }

            return _resultFlag;

        }

        public string[] GetAllDevicesObjectID()
        {
            IEnumerable<ParseObject> _queryResult = InternalGetAllDevicesObjectID().Result;

            string[] _resultData = new string[_queryResult.Count()];

            for (int i = 0; i < _resultData.Length; i++)
            {
                _resultData[i] = _queryResult.ElementAt(i).ObjectId;
            }



            return _resultData;
        }

        public async Task<IEnumerable<ParseObject>> InternalGetAllDevicesObjectID()
        {
            IEnumerable<ParseObject> _queryResults = null;
            try
            {
                var _query = from temp in ParseObject.GetQuery("ScheduleRecurrence")
                             where temp.Get<string>("DeviceID") != " "
                             select temp;

                _queryResults = await _query.FindAsync();

            }
            catch (Exception)
            {

                throw;
            }

            return _queryResults;
        }

        public string[] GetScheduleData(string _deviceObjectID)
        {
            IEnumerable<ParseObject> _queryResult = InternalGetScheduleData(_deviceObjectID).Result;

            string[] _resultData = new string[10];


            foreach (ParseObject i in _queryResult)
            {
                _resultData[0] = _deviceObjectID;
                _resultData[1] = i.Get<string>("DeviceID").Trim();
                _resultData[2] = i.Get<string>("DeviceName").Trim();
                _resultData[3] = i.Get<string>("RecurrenceHourMinSec").Trim();
                _resultData[4] = i.Get<string>("RecurrenceDayWeek").Trim();
                _resultData[5] = i.Get<string>("RecurrenceDayDate").Trim();
                _resultData[6] = i.Get<string>("ScheduleType").Trim();
                _resultData[7] = i.Get<string>("RecurrenceType").Trim();
                _resultData[8] = i.Get<string>("ScheduleCase").Trim();
                _resultData[9] = i.Get<bool>("ScheduleDone").ToString().Trim();

            }

            return _resultData;
        }

        public async Task<IEnumerable<ParseObject>> InternalGetScheduleData(string _deviceObjectID)
        {
            IEnumerable<ParseObject> _queryResults = null;
            try
            {
                var _query = from temp in ParseObject.GetQuery("ScheduleRecurrence")
                             where temp.ObjectId == _deviceObjectID.Trim()
                             select temp;

                _queryResults = await _query.FindAsync();

            }
            catch (Exception)
            {

                throw;
            }

            return _queryResults;
        }

        public string UpdateScheduleDone(string[] _deviceObjectID)
        {
            Task<int> _resultFlag;

            try
            {
                _resultFlag = InternalUpdateScheduleDone(_deviceObjectID);
            }

            catch (Exception)
            {

                throw;
            }

            return _resultFlag.Result.ToString();
        }

        public async Task<int> InternalUpdateScheduleDone(string[] _deviceObjectID)
        {
            int _resultFlag = 0;
            try
            {

                ParseQuery<ParseObject> query = ParseObject.GetQuery("ScheduleRecurrence");
                ParseObject _parseObject = await query.GetAsync(_deviceObjectID[0]);

                _parseObject["ScheduleDone"] = Convert.ToBoolean(_deviceObjectID[1]);

                await _parseObject.SaveAsync();



                _resultFlag = 1;
            }
            catch (Exception)
            {

                throw;
            }

            return _resultFlag;
        }

    }
}
