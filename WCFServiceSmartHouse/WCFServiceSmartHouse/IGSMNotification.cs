using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceSmartHouse
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGSMNotification" in both code and config file together.
    [ServiceContract]
    public interface IGSMNotification
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        void SendMessageSMS(string _phoneNumber, string _textMessage);
    }

 
}
