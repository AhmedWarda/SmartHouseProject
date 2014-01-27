using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceSmartHouse
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBusinessWorkFlows" in both code and config file together.
    [ServiceContract]
    public interface IBusinessWorkFlows
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        void SaveDeviceEventLog(string[] _deviceIDTypeValue);
        [OperationContract]
        void AutoScheduleChecksAndActions();

        [OperationContract]
        string SaveDeviceEventLogWithAlarmChecks(string[] _deviceIDTypeValue);

        [OperationContract]
        string[] VerifyUserNameAndPassword(string _userName, string _password);

        [OperationContract]
        string IsThereAlarm(string[] _deviceIDTypeValue);
    }
}
