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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Devices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Devices.svc or Devices.svc.cs at the Solution Explorer and start debugging.
    public class Devices : IDevices
    {
        public void DoWork()
        {
        }

        public Devices()
        {
            ParseClient.Initialize("3JiHrWw6NXQleET7bSyh5syRYCfB2bsNTR8NbNWS", "uh7QyInYQIXv4fCMqddJd9S9BwMFmy0VqHhAcgzz");
        }

        public string AddDevice(string[] _deviceData)
        {
            Task<int> _resultFlag;

            try
            {
                _resultFlag = InternalAddDevice(_deviceData);
            }

            catch (Exception)
            {
                
                throw;
            }

            return _resultFlag.Result.ToString();
        }

        public async Task<int> InternalAddDevice(string[] _deviceData)
       {
           int _resultFlag = 0;

           try
           {
               ParseObject DevicesTable = new ParseObject("Devices");

               DevicesTable.Add("DeviceID", _deviceData[0].ToString().Trim());
               DevicesTable.Add("DeviceName", _deviceData[1].ToString().Trim());
               DevicesTable.Add("DeviceAssignedTo", _deviceData[2].ToString().Trim());
               DevicesTable.Add("DeviceStatus", Convert.ToBoolean(_deviceData[3].ToString().Trim()));

               await DevicesTable.SaveAsync();
               _resultFlag = 1;
           }
           catch (Exception)
           {
               _resultFlag = 0;

           }

           return _resultFlag;
       }

        public string DeleteDevice(string _deviceID)
       {
           Task<int> _resultFlag;

           try
           {
               _resultFlag = InternalDeleteDevice(_deviceID);
           }

           catch (Exception)
           {

               throw;
           }

           return _resultFlag.Result.ToString();
       } 

        public async Task<int> InternalDeleteDevice(string _deviceID)
        {
            //ParseClient.Initialize("3JiHrWw6NXQleET7bSyh5syRYCfB2bsNTR8NbNWS", "uh7QyInYQIXv4fCMqddJd9S9BwMFmy0VqHhAcgzz");
            int _resultFlag = 0;
            try
            {
                var _query = from temp in ParseObject.GetQuery("Devices")
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

        public string UpdateDevice(string[] _deviceData)
        {
            Task<int> _resultFlag;

            try
            {
                _resultFlag = InternalUpdateDevice(_deviceData);
            }

            catch (Exception)
            {

                throw;
            }

            return _resultFlag.Result.ToString();
        }

        public async Task<int> InternalUpdateDevice(string[] _deviceData)
        {
            int _resultFlag = 0;
            try
            {
                var _query = from temp in ParseObject.GetQuery("Devices")
                             where temp.Get<string>("DeviceID") == _deviceData[0].Trim()
                             select temp;

                IEnumerable<ParseObject> _queryResults = await _query.FindAsync();

                foreach (ParseObject i in _queryResults)
                {
                    if(_deviceData[1]!="null")
                    {
                        i["DeviceName"] = _deviceData[1].Trim();
                    }
                    if (_deviceData[2]!= "null")
                    {
                        i["DeviceAssignedTo"] = _deviceData[2].Trim();
                    }
                    if (_deviceData[3] != "null")
                    {
                        i["DeviceStatus"] = Convert.ToBoolean(_deviceData[3].Trim());
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

        public string[] GetDeviceData(string _deviceID)
        {
            IEnumerable<ParseObject> _queryResult = InternalGetDeviceData(_deviceID).Result;

            string[] _resultData = new string[4];


            foreach (ParseObject i in _queryResult)
            {
                _resultData[0] = _deviceID;
                _resultData[1] = i.Get<string>("DeviceName").Trim();
                _resultData[2] = i.Get<string>("DeviceAssignedTo").Trim();
                _resultData[3] = i.Get<bool>("DeviceStatus").ToString().Trim();

            }

            return _resultData;
        }

        public async Task<IEnumerable<ParseObject>> InternalGetDeviceData(string _deviceID)
        {
            IEnumerable<ParseObject> _queryResults = null;
            try
            {
                var _query = from temp in ParseObject.GetQuery("Devices")
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

        public string[] GetAllDevicesID()
        {
            IEnumerable<ParseObject> _queryResult = InternalGetAllDevicesID().Result;

            string[] _resultData = new string[_queryResult.Count()];

            for (int i = 0; i < _resultData.Length; i++)
            {
                _resultData[i] = _queryResult.ElementAt(i).Get<string>("DeviceID").Trim();
            }

            

            return _resultData;
        }

        public async Task<IEnumerable<ParseObject>> InternalGetAllDevicesID()
        {
            IEnumerable<ParseObject> _queryResults = null;
            try
            {
                var _query = from temp in ParseObject.GetQuery("Devices")
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
    }
}
