using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceSmartHouse
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsers" in both code and config file together.
    [ServiceContract]
    public interface IUsers
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        string AddUser(string[] _userData);

        [OperationContract]
        string DeleteUser(string _UserObjectID);

        [OperationContract]
        string UpdateUser(string[] _userData);

        [OperationContract]
        string[] GetAllUsersObjectID();

        [OperationContract]
        string[] GetUserData(string _userObjectID);

        [OperationContract]
        string[] GetUserDataByName(string _userName);
    }
}
