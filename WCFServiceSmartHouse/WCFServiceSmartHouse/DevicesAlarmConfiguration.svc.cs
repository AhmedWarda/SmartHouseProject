using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Parse;
using System.Threading.Tasks;

namespace WCFServiceSmartHouse
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DevicesAlarmConfiguration" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DevicesAlarmConfiguration.svc or DevicesAlarmConfiguration.svc.cs at the Solution Explorer and start debugging.
    public class DevicesAlarmConfiguration : IDevicesAlarmConfiguration
    {
        public void DoWork()
        {
        }

        public DevicesAlarmConfiguration()
        {
            ParseClient.Initialize("3JiHrWw6NXQleET7bSyh5syRYCfB2bsNTR8NbNWS", "uh7QyInYQIXv4fCMqddJd9S9BwMFmy0VqHhAcgzz");
        }

        public string AddDeviceAlarmConfiguration(string[] _deviceAlarmConfigData)
        {
            Task<int> _resultFlag;

            try
            {
                _resultFlag = InternalAddDeviceAlarmConfiguration(_deviceAlarmConfigData);
            }

            catch (Exception)
            {

                throw;
            }

            return _resultFlag.Result.ToString();
        }

        public async Task<int> InternalAddDeviceAlarmConfiguration(string[] _deviceAlarmConfigData)
        {
            int _resultFlag = 0;

            try
            {
                ParseObject DevicesAlarmConfigTable = new ParseObject("DevicesAlarmConfiguration");

                DevicesAlarmConfigTable.Add("DeviceID",_deviceAlarmConfigData[0].Trim());
                DevicesAlarmConfigTable.Add("AlarmValue", _deviceAlarmConfigData[1].Trim());
                DevicesAlarmConfigTable.Add("ConfigType", _deviceAlarmConfigData[2].Trim());

                await DevicesAlarmConfigTable.SaveAsync();
                _resultFlag = 1;
            }
            catch (Exception)
            {
                _resultFlag = 0;

            }

            return _resultFlag;
        } 

        public string DeleteDeviceAlarmConfiguraion(string _deviceID)
        {
            Task<int> _resultFlag;

            try
            {
                _resultFlag = InternalDeleteDeviceAlarmConfiguraion(_deviceID);
            }

            catch (Exception)
            {

                throw;
            }

            return _resultFlag.Result.ToString();
        }

        public async Task<int> InternalDeleteDeviceAlarmConfiguraion(string _deviceID)
        {
            int _resultFlag = 0;
            try
            {
                var _query = from temp in ParseObject.GetQuery("DevicesAlarmConfiguration")
                             where temp.Get<string>("DeviceID") == _deviceID
                             select temp;

                IEnumerable<ParseObject> _queryResults = await _query.FindAsync();

                foreach (ParseObject i in _queryResults)
                {
                    await i.DeleteAsync();

                }

                _resultFlag = 1;
            }
            catch (Exception)
            {

                throw;
            }

            return _resultFlag;

        }

        public string UpdateDeviceAlarmConfiguration(string[] _deviceAlarmConfigData)
        {
            Task<int> _resultFlag;

            try
            {
                _resultFlag = InternalUpdateDeviceAlarmConfiguration(_deviceAlarmConfigData);
            }

            catch (Exception)
            {

                throw;
            }

            return _resultFlag.Result.ToString();
        }

        public async Task<int> InternalUpdateDeviceAlarmConfiguration(string[] _deviceAlarmConfigData)
        {
            int _resultFlag = 0;
            try
            {
                var _query = from temp in ParseObject.GetQuery("DevicesAlarmConfiguration")
                             where temp.Get<string>("DeviceID") == _deviceAlarmConfigData[0].Trim()
                             select temp;

                IEnumerable<ParseObject> _queryResults = await _query.FindAsync();

                foreach (ParseObject i in _queryResults)
                {
                    if (_deviceAlarmConfigData[1] != "null")
                    {
                        i["AlarmValue"] = _deviceAlarmConfigData[1].Trim();
                    }
                    if (_deviceAlarmConfigData[2] != "null")
                    {
                        i["ConfigType"] = _deviceAlarmConfigData[2].Trim();
                    }

                    await i.SaveAsync();

                }

                _resultFlag = 1;
            }
            catch (Exception)
            {

                throw;
            }

            return _resultFlag;
        }

        public string[] GetAllDevicesAlarmConfigID()
        {
            IEnumerable<ParseObject> _queryResult = InternalGetAllDevicesAlarmConfigID().Result;

            string[] _resultData = new string[_queryResult.Count()];

            for (int i = 0; i < _resultData.Length; i++)
            {
                _resultData[i] = _queryResult.ElementAt(i).Get<string>("DeviceID").Trim();
            }

            return _resultData;
        }

        public async Task<IEnumerable<ParseObject>> InternalGetAllDevicesAlarmConfigID()
        {
            IEnumerable<ParseObject> _queryResults = null;
            try
            {
                var _query = from temp in ParseObject.GetQuery("DevicesAlarmConfiguration")
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

        public string[] GetDeviceAlarmConfigData(string _deviceID)
        {
            IEnumerable<ParseObject> _queryResult = InternalGetDeviceAlarmConfigData(_deviceID).Result;

            string[] _resultData = new string[3];


            foreach (ParseObject i in _queryResult)
            {
                _resultData[0] = _deviceID;
                _resultData[1] = i.Get<string>("AlarmValue").Trim();
                _resultData[2] = i.Get<string>("ConfigType").Trim();

            }

            return _resultData;
        }

        public async Task<IEnumerable<ParseObject>> InternalGetDeviceAlarmConfigData(string _deviceID)
        {
            IEnumerable<ParseObject> _queryResults = null;
            try
            {
                var _query = from temp in ParseObject.GetQuery("DevicesAlarmConfiguration")
                             where temp.Get<string>("DeviceID") == _deviceID.Trim()
                             select temp;

                _queryResults = await _query.FindAsync();

            }
            catch (Exception)
            {

                throw;
            }

            return _queryResults;
        }

    }
}
