using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceSmartHouse
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IScheduleRecurrence" in both code and config file together.
    [ServiceContract]
    public interface IScheduleRecurrence
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        string AddSchedule(string[] _scheduleData);

        [OperationContract]
        string DeleteSchedule(string _deviceObjectID);

        [OperationContract]
        string[] GetAllDevicesObjectID();

        [OperationContract]
        string[] GetScheduleData(string _deviceObjectID);

        [OperationContract]
        string UpdateScheduleDone(string[] _deviceObjectID);
    }
}
