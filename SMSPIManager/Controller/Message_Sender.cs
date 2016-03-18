using OfflineSMSender.controller.json;
using RestSharp;
using SMSPIManager.Controller.json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSPIManager.Controller
{
    class Message_Sender
    {
        public bool SendMessage(string number, string message, String _ip, String _port)
        {
            var client = new RestClient("http://" + _ip + ":" + _port + "/");
            var request = new RestRequest(API.SENDMESSAGEAPI, Method.POST);
            request.AddParameter("TO", number);
            request.AddParameter("Message", message);
            request.AddParameter("DeliveryReport", 0);
            var time = DateTime.Now.ToString();
            try
            {
                var queryResponse = client.Execute<SendMessageResponse>(request).Data;
                return queryResponse.isSuccessful;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
