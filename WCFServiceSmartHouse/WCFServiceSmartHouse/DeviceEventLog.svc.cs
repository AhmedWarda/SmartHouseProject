using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Parse;

namespace WCFServiceSmartHouse
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DeviceEventLog" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DeviceEventLog.svc or DeviceEventLog.svc.cs at the Solution Explorer and start debugging.
    public class DeviceEventLog : IDeviceEventLog
    {
        public void DoWork()
        {
            
        }

        public DeviceEventLog()
        {
            ParseClient.Initialize("3JiHrWw6NXQleET7bSyh5syRYCfB2bsNTR8NbNWS", "uh7QyInYQIXv4fCMqddJd9S9BwMFmy0VqHhAcgzz");
        }

        /// <summary>
        /// Pass EventType, EventName, EventDeviceID, EventAreaID, EventValue
        /// </summary>
        /// <param name="_deviceEventLogData"></param>
        /// <returns></returns>
        public string AddDeviceEventLog(string[] _deviceEventLogData)
        {
            Task<int> _resultFlag;

            try
            {
                _resultFlag = InternalAddDeviceEventLog(_deviceEventLogData);
            }

            catch (Exception)
            {

                throw;
            }

            return _resultFlag.Result.ToString();
        }

        public async Task<int> InternalAddDeviceEventLog(string[] _deviceEventLogData)
        {
            int _resultFlag = 0;

            try
            {
                ParseObject DevicesEventLogTable = new ParseObject("DevicesEventLog");

                DevicesEventLogTable.Add("EventType", _deviceEventLogData[0].ToString().Trim());
                DevicesEventLogTable.Add("EventName", _deviceEventLogData[1].ToString().Trim());
                DevicesEventLogTable.Add("EventDeviceID", _deviceEventLogData[2].ToString().Trim());
                DevicesEventLogTable.Add("EventAreaID", _deviceEventLogData[3].ToString().Trim());
                DevicesEventLogTable.Add("EventValue", _deviceEventLogData[4].ToString().Trim());

                await DevicesEventLogTable.SaveAsync();
                _resultFlag = 1;
            }
            catch (Exception)
            {
                _resultFlag = 0;

            }

            return _resultFlag;
        }

        public string[] GetOneDeviceEventLog(string _eventDeviceID)
        {
            IEnumerable<ParseObject> _queryResult = InternalGetOneDeviceEventLog(_eventDeviceID).Result;

            string[] _resultFlag = new string[8];

            try
            {
                foreach (ParseObject i in _queryResult)
                {
                    _resultFlag[0] = i.ObjectId.Trim();
                    _resultFlag[1] = i.Get<string>("EventType");
                    _resultFlag[2] = i.CreatedAt.ToString();
                    _resultFlag[3] = i.UpdatedAt.ToString();
                    _resultFlag[4] = i.Get<string>("EventName");
                    _resultFlag[5] = i.Get<string>("EventDeviceID");
                    _resultFlag[6] = i.Get<string>("EventAreaID");
                    _resultFlag[7] = i.Get<string>("EventValue");

                }
            }
            catch (Exception)
            {
                
                throw;
            }

            return _resultFlag;
        }

        public async Task<IEnumerable<ParseObject>> InternalGetOneDeviceEventLog(string _eventDeviceID)
        {

            var _query = from temp in ParseObject.GetQuery("DevicesEventLog")
                         where temp.Get<string>("EventDeviceID") == _eventDeviceID
                         select temp;

            IEnumerable<ParseObject> _queryResults = await _query.FindAsync();



            return _queryResults;
        }


    }
}
