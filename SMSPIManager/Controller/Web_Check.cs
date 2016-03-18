using SMSPIManager.Controller.json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Windows.Forms;
using RestSharp.Deserializers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace SMSPIManager.Controller
{
    class Web_Check
    {
        public List<ApiResponse> getMessages()
        {
            var client = new RestClient(API.WEBLINK);
            var request = new RestRequest(API.GETFROMWEB, Method.GET);
            var response = client.Execute < List<ApiResponse>>(request);
            if(response == null)
            {
                return null;
            }
            var responseContent = response.Content;
            if (responseContent.Equals("") || !validJson(responseContent))
                return null;
            var responseDeserializer = new JsonDeserializer();
            var responseData = responseDeserializer.Deserialize<List<ApiResponse>>(response); 
            return responseData;
        }

        public void updateMessageStatus(String id)
        {
            var client = new RestClient(API.WEBLINK);
            var request = new RestRequest(API.RESPONSETOWEB, Method.POST);
            request.AddParameter("id", id);
            var queryResponse = client.Execute(request);
        }

        private bool validJson(String jsonString)
        {
            try
            {
                var obj = JToken.Parse(jsonString);
                return true;
            }
            catch (JsonReaderException jex)
            {
                //Exception in parsing json
                return false;
            }
            catch (Exception ex) //some other exception
            {
                return false;
            }
        }
    }
}
