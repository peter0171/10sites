using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using PunClient.Transports;
using RestSharp;

namespace PunClient.DataServices
{
    class PunDataService
    {
        private RestClient client;
        public PunDataService()
        {
            client = new RestClient("http://localhost:60783/");
        }

        public Pun[] GetPuns()
        {
            var request = new RestRequest("/puns", Method.GET);
            var response = client.Execute<List<Pun>>(request);
            return response.Data.ToArray();
        }

        public Pun GetPunByID(int punID)
        {
            var request = new RestRequest("/puns/{PunID}", Method.GET);
            request.AddUrlSegment("PunID", punID.ToString());
            var response = client.Execute<Pun>(request);
            return response.Data;
        }

        public void CreatePun(Pun pun)
        {
            var request = new RestRequest("/puns", Method.POST);
            request.AddObject(pun);
            var response = client.Execute<Pun>(request);
            Console.WriteLine("New PunID: " + response.Data.PunID);
        }

        public void UpdatePun(Pun pun)
        {
            var request = new RestRequest("/puns/{PunID}", Method.PUT);
            request.AddUrlSegment("PunID", pun.PunID.ToString());
            request.AddObject(pun);
            var response = client.Execute(request);
        }

        public void DeletePun(int punID)
        {
            var request = new RestRequest("/puns/{PunID}", Method.DELETE);
            request.AddUrlSegment("PunID", punID.ToString());
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.NoContent)
                Console.WriteLine("Successfully deleted pun");
        }
    }
}
