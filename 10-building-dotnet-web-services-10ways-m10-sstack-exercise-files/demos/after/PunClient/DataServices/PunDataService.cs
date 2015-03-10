using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Data;
using ServiceStack.ServiceClient.Web;
using WebServices.SS;

namespace PunClient.DataServices
{
    class PunDataService
    {
        private JsonServiceClient client;
        public PunDataService()
        {
            client = new JsonServiceClient("http://localhost:58758");
        }

        public Pun[] GetPuns()
        {
            var response = client.Get(new GetPunsRequest());
            return response;
        }

        public Pun GetPunByID(int punID)
        {
            var pun = client.Get<Pun>("/puns/" + punID);
            return pun;
        }

        public void CreatePun(Pun pun)
        {
            var request = new PunRequest
                {
                    PunID = 0,
                    Title = pun.Title,
                    Joke = pun.Joke
                };
            var response = client.Post(request);
        }

        public void UpdatePun(Pun pun)
        {
            var request = new PunRequest
            {
                PunID = pun.PunID,
                Title = pun.Title,
                Joke = pun.Joke
            };
            var response = client.Put<string>("/puns/" + pun.PunID, request);
            Console.WriteLine(response);
        }

        public void DeletePun(int punID)
        {
            var response = client.Delete<HttpWebResponse>("/puns/" + punID);
            if (response.StatusCode == HttpStatusCode.NoContent)
                Console.WriteLine("Successfully deleted pun");
        }
    }
}
