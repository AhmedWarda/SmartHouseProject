using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceSmartHouse
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDevices" in both code and config file together.
    [ServiceContract]
    public interface IDevices
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        string AddDevice(string[] _deviceData);

        [OperationContract]
        string DeleteDevice(string _deviceID);

        [OperationContract]
        string UpdateDevice(string[] _deviceData);

        [OperationContract]
        string[] GetDeviceData(string _deviceID);

        [OperationContract]
        string[] GetAllDevicesID();
    }
}
