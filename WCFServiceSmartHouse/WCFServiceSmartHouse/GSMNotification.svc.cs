using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceSmartHouse
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GSMNotification" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GSMNotification.svc or GSMNotification.svc.cs at the Solution Explorer and start debugging.
    public class GSMNotification : IGSMNotification
    {
        public void DoWork()
        {
        }

        public void SendMessageSMS(string _phoneNumber,string _textMessage)
        {
            SerialPort _port = new SerialPort();
            
            _port.PortName = "COM6";
            _port.BaudRate = 9600;
            _port.Parity = System.IO.Ports.Parity.None;
            _port.DataBits = 8;
            _port.StopBits = System.IO.Ports.StopBits.One;
            _port.Handshake = System.IO.Ports.Handshake.None;
            _port.RtsEnable = true;

            if(_port.IsOpen)
            {
                
            }

            else
            {
                _port.Open(); 
            }
            

            string PhoneNo = _phoneNumber;

            string _command = "AT+CMGF=1";
            _port.Write(_command + "\r");

            System.Threading.Thread.Sleep(10000);

            _command = "AT+CMGS=\"" + PhoneNo + "\"";
            _port.Write(_command + "\r");

            System.Threading.Thread.Sleep(10000);

            string _messageText = _textMessage;

            _command = _messageText + char.ConvertFromUtf32(26) + "\r";
            _port.Write(_command + "\r");

            System.Threading.Thread.Sleep(10000);

            _port.Close();
        }
    }
}
