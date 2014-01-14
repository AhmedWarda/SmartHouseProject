using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFServiceSmartHouse
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Users" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Users.svc or Users.svc.cs at the Solution Explorer and start debugging.
    public class Users : IUsers
    {
        public void DoWork()
        {
        }

        public Users()
        {
            ParseClient.Initialize("3JiHrWw6NXQleET7bSyh5syRYCfB2bsNTR8NbNWS", "uh7QyInYQIXv4fCMqddJd9S9BwMFmy0VqHhAcgzz");
        }

        public string AddUser(string[] _userData)
        {
            Task<int> _resultFlag;

            try
            {
                _resultFlag = InternalAddUser(_userData);
            }

            catch (Exception)
            {

                throw;
            }

            return _resultFlag.Result.ToString();
        }

        public async Task<int> InternalAddUser(string[] _userData)
        {
            int _resultFlag = 0;

            try
            {
                ParseObject UsersTable = new ParseObject("Users");

                UsersTable.Add("UserName", _userData[0].ToString().Trim());
                UsersTable.Add("Password", _userData[1].ToString().Trim());
                UsersTable.Add("Role", _userData[2].ToString().Trim());


                await UsersTable.SaveAsync();
                _resultFlag = 1;
            }
            catch (Exception)
            {
                _resultFlag = 0;

            }

            return _resultFlag;
        }

        public string DeleteUser(string _UserObjectID)
        {
            Task<int> _resultFlag;

            try
            {
                _resultFlag = InternalDeleteUser(_UserObjectID);


            }

            catch (Exception)
            {

                throw;
            }

            return _resultFlag.Result.ToString();
        }

        public async Task<int> InternalDeleteUser(string _userObjectID)
        {
            int _resultFlag = 0;
            try
            {
                ParseQuery<ParseObject> query = ParseObject.GetQuery("Users");
                ParseObject _parseObject = await query.GetAsync(_userObjectID);

                await _parseObject.DeleteAsync();

                _resultFlag = 1;
            }
            catch (Exception)
            {

                throw;
            }

            return _resultFlag;

        }

        public string UpdateUser(string[] _userData)
        {
            Task<int> _resultFlag;

            try
            {
                _resultFlag = InternalUpdateUser(_userData);
            }

            catch (Exception)
            {

                throw;
            }

            return _resultFlag.Result.ToString();
        }

        public async Task<int> InternalUpdateUser(string[] _userData)
        {
            int _resultFlag = 0;
            try
            {

                ParseQuery<ParseObject> query = ParseObject.GetQuery("Users");
                ParseObject _parseObject = await query.GetAsync(_userData[0]);

                if (_userData[1]!="null")
                {
                    _parseObject["UserName"] = _userData[1];
                }

                if (_userData[2] != "null")
                {
                    _parseObject["Password"] = _userData[2];
                }

                if (_userData[3] != "null")
                {
                    _parseObject["Role"] = _userData[3];
                }

                await _parseObject.SaveAsync();



                _resultFlag = 1;
            }
            catch (Exception)
            {

                throw;
            }

            return _resultFlag;
        }

        public string[] GetAllUsersObjectID()
        {
            IEnumerable<ParseObject> _queryResult = InternalGetAllUsersObjectID().Result;

            string[] _resultData = new string[_queryResult.Count()];

            for (int i = 0; i < _resultData.Length; i++)
            {
                _resultData[i] = _queryResult.ElementAt(i).ObjectId;
            }



            return _resultData;
        }

        public async Task<IEnumerable<ParseObject>> InternalGetAllUsersObjectID()
        {
            IEnumerable<ParseObject> _queryResults = null;
            try
            {
                var _query = from temp in ParseObject.GetQuery("Users")
                             where temp.ObjectId != " "
                             select temp;

                _queryResults = await _query.FindAsync();

            }
            catch (Exception)
            {

                throw;
            }

            return _queryResults;
        }

        public string[] GetUserData(string _userObjectID)
        {
            IEnumerable<ParseObject> _queryResult = InternalGetUserData(_userObjectID).Result;

            string[] _resultData = new string[4];


            foreach (ParseObject i in _queryResult)
            {
                _resultData[0] = _userObjectID;
                _resultData[1] = i.Get<string>("UserName").Trim();
                _resultData[2] = i.Get<string>("Password").Trim();
                _resultData[3] = i.Get<string>("Role").Trim();

            }

            return _resultData;
        }

        public async Task<IEnumerable<ParseObject>> InternalGetUserData(string _userObjectID)
        {
            IEnumerable<ParseObject> _queryResults = null;
            try
            {
                var _query = from temp in ParseObject.GetQuery("Users")
                             where temp.ObjectId == _userObjectID.Trim()
                             select temp;

                _queryResults = await _query.FindAsync();

            }
            catch (Exception)
            {

                throw;
            }

            return _queryResults;
        }

        public string[] GetUserDataByName(string _userName)
        {
            IEnumerable<ParseObject> _queryResult = InternalGetUserDataByName(_userName).Result;

            string[] _resultData = new string[4];


            foreach (ParseObject i in _queryResult)
            {
                _resultData[0] = i.ObjectId;
                _resultData[1] = i.Get<string>("UserName").Trim();
                _resultData[2] = i.Get<string>("Password").Trim();
                _resultData[3] = i.Get<string>("Role").Trim();

            }

            return _resultData;
        }

        public async Task<IEnumerable<ParseObject>> InternalGetUserDataByName(string _userName)
        {
            IEnumerable<ParseObject> _queryResults = null;
            try
            {
                var _query = from temp in ParseObject.GetQuery("Users")
                             where temp.Get<string>("UserName") == _userName.Trim()
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
