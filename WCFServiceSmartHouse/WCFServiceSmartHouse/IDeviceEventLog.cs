﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceSmartHouse
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDeviceEventLog" in both code and config file together.
    [ServiceContract]
    public interface IDeviceEventLog
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        string AddDeviceEventLog(string[] _deviceEventLogData);

        [OperationContract]
        string[] GetOneDeviceEventLog(string _eventDeviceID);
    }
}
