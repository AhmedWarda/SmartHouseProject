using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceSmartHouse
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHouseArea" in both code and config file together.
    [ServiceContract]
    public interface IHouseArea
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        string AddHouseArea(string[] _houseAreaData);

        [OperationContract]
        string DeleteHouseArea(string _houseAreaID);

        [OperationContract]
        string UpdateHouseArea(string[] _houseAreaData);

        [OperationContract]
        string[] GetHouseAreaData(string _houseAreaID);

        [OperationContract]
        string[] GetAllHouseAreasID();
    }
}
