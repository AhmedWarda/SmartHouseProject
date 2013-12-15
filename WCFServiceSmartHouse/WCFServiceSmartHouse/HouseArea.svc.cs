using System.Threading.Tasks;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Timers;

namespace WCFServiceSmartHouse
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HouseArea" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HouseArea.svc or HouseArea.svc.cs at the Solution Explorer and start debugging.
    public class HouseArea : IHouseArea
    {
        public void DoWork()
        {
             
        }

        public HouseArea()
        {
            ParseClient.Initialize("3JiHrWw6NXQleET7bSyh5syRYCfB2bsNTR8NbNWS", "uh7QyInYQIXv4fCMqddJd9S9BwMFmy0VqHhAcgzz");

        }

        public string AddHouseArea(string[] _houseAreaData)
        {
            Task<int> _resultFlag;

            try
            {
                _resultFlag = InternalAddHouseArea(_houseAreaData);
            }

            catch (Exception)
            {

                throw;
            }

            return _resultFlag.Result.ToString();
        }

        public async Task<int> InternalAddHouseArea(string[] _houseAreaData)
        {
            int _resultFlag = 0;

            try
            {
                ParseObject _houseAreaTable = new ParseObject("HouseArea");

                _houseAreaTable.Add("AreaID", _houseAreaData[0].ToString().Trim());
                _houseAreaTable.Add("AreaName", _houseAreaData[1].ToString().Trim());
                _houseAreaTable.Add("AreaStatus", Convert.ToBoolean(_houseAreaData[2].ToString().Trim()));

                await _houseAreaTable.SaveAsync();
                _resultFlag = 1;
            }
            catch (Exception)
            {
                _resultFlag = 0;

            }

            return _resultFlag;
        }

        public string DeleteHouseArea(string _houseAreaID)
        {
            Task<int> _resultFlag;

            try
            {
                _resultFlag = InternalDeleteHouseArea(_houseAreaID);
            }

            catch (Exception)
            {

                throw;
            }

            return _resultFlag.Result.ToString();
        }

        public async Task<int> InternalDeleteHouseArea(string _houseAreaID)
        {
            int _resultFlag = 0;
            try
            {
                var _query = from temp in ParseObject.GetQuery("HouseArea")
                             where temp.Get<string>("AreaID") == _houseAreaID
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

        public string UpdateHouseArea(string[] _houseAreaData)
        {
            Task<int> _resultFlag;

            try
            {
                _resultFlag = InternalUpdateHouseArea(_houseAreaData);
            }

            catch (Exception)
            {

                throw;
            }

            return _resultFlag.Result.ToString();
        }

        public async Task<int> InternalUpdateHouseArea(string[] _houseAreaData)
        {
            int _resultFlag = 0;
            try
            {
                var _query = from temp in ParseObject.GetQuery("HouseArea")
                             where temp.Get<string>("AreaID") == _houseAreaData[0].Trim()
                             select temp;

                IEnumerable<ParseObject> _queryResults = await _query.FindAsync();

                foreach (ParseObject i in _queryResults)
                {
                    if (_houseAreaData[1] != "null")
                    {
                        i["AreaName"] = _houseAreaData[1].Trim();
                    }

                    if (_houseAreaData[2] != "null")
                    {
                        i["AreaStatus"] = Convert.ToBoolean(_houseAreaData[2].Trim());
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

        public string[] GetHouseAreaData(string _houseAreaID)
        {
            IEnumerable<ParseObject> _queryResult = InternalGetHouseAreaData(_houseAreaID).Result;

            string[] _resultData = new string[3];


            foreach (ParseObject i in _queryResult)
            {
                _resultData[0] = _houseAreaID;
                _resultData[1] = i.Get<string>("AreaName").Trim();
                _resultData[2] = i.Get<bool>("AreaStatus").ToString().Trim();

            }

            return _resultData;
        }

        public async Task<IEnumerable<ParseObject>> InternalGetHouseAreaData(string _houseAreaID)
        {
            IEnumerable<ParseObject> _queryResults = null;
            try
            {
                var _query = from temp in ParseObject.GetQuery("HouseArea")
                             where temp.Get<string>("AreaID") == _houseAreaID.Trim()
                             select temp;

                _queryResults = await _query.FindAsync();

            }
            catch (Exception)
            {

                throw;
            }

            return _queryResults;
        }

        public string[] GetAllHouseAreasID()
        {
            IEnumerable<ParseObject> _queryResult = InternalGetAllHouseAreasID().Result;

            string[] _resultData = new string[_queryResult.Count()];

            for (int i = 0; i < _resultData.Length; i++)
            {
                _resultData[i] = _queryResult.ElementAt(i).Get<string>("AreaID").Trim();
            }

            return _resultData;
        }

        public async Task<IEnumerable<ParseObject>> InternalGetAllHouseAreasID()
        {
            IEnumerable<ParseObject> _queryResults = null;
            try
            {
                var _query = from temp in ParseObject.GetQuery("HouseArea")
                             where temp.Get<string>("AreaID") != " "
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
