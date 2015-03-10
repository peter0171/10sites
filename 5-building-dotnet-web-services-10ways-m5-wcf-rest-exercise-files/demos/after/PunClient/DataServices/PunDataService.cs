using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Serialization;
using PunClient.Transports;

namespace PunClient.DataServices
{
    class PunDataService
    {
        public PunDataService()
        {
        }

        public Pun[] GetPuns()
        {
            var client = new WebClient();
            client.Headers.Add("Accept", "application/json");
            var result = client.DownloadString("http://localhost:63588/PunService.svc/Puns");
            var serializer = new DataContractJsonSerializer(typeof (Pun[]));
            Pun[] resultObject;
            using (var stream = new MemoryStream(Encoding.ASCII.GetBytes(result)))
            {
                resultObject = (Pun[])serializer.ReadObject(stream);
            }
            return resultObject;
        }

        public Pun GetPunByID(int punID)
        {
            var client = new WebClient();
            var result = client.DownloadString("http://localhost:63588/PunService.svc/Pun/1");
            var serializer = new XmlSerializer(typeof (Pun));
            Pun resultObject;
            using (var stream = new MemoryStream(Encoding.ASCII.GetBytes(result)))
            {
                resultObject = (Pun)serializer.Deserialize(stream);
            }
            return resultObject;
        }

        public Pun CreatePun(Pun pun)
        {
            return SendDataToServer("http://localhost:63588/PunService.svc/Puns", "POST", pun);
        }

        private T SendDataToServer<T>(string endpoint, string method, T pun)
        {
            var request = (HttpWebRequest)HttpWebRequest.Create(endpoint);
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.Method = method;
            var serializer = new DataContractJsonSerializer(typeof(T));
            var requestStream = request.GetRequestStream();
            serializer.WriteObject(requestStream, pun);
            requestStream.Close();
            var response = request.GetResponse();
            if (response.ContentLength == 0)
            {
                response.Close();
                return default(T);
            }
            var responseStream = response.GetResponseStream();
            var responseObject = (T)serializer.ReadObject(responseStream);
            responseStream.Close();
            return responseObject;
        }

        public Pun UpdatePun(Pun pun)
        {
            return SendDataToServer("http://localhost:63588/PunService.svc/Pun/" + pun.PunID, "PUT", pun);
        }

        public void DeletePun(int punID)
        {
            SendDataToServer("http://localhost:63588/PunService.svc/Pun/" + punID, "DELETE",
                             new DeletePun {PunID = punID});
        }
    }
}
