using System;
using System.Collections.Generic;
using System.Linq;
using EasyHttp.Http;
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
            var client = new HttpClient();
            var response = client.Get("http://localhost:57737/api/puns");
            var puns = response.StaticBody<Pun[]>();
            return puns;
        }

        public Pun GetPunByID(int punID)
        {
            var client = new HttpClient();
            var response = client.Get("http://localhost:57737/api/puns/" + punID);
            var pun = response.StaticBody<Pun>();
            return pun;
        }

        public void CreatePun(Pun pun)
        {
            var client = new HttpClient();
            client.Post("http://localhost:57737/api/puns", pun, "application/json");
        }

        public void UpdatePun(Pun pun)
        {
            var client = new HttpClient();
            client.Put("http://localhost:57737/api/puns/" + pun.PunID, pun, "application/json");
        }

        public void DeletePun(int punID)
        {
            var client = new HttpClient();
            client.Delete("http://localhost:57737/api/puns/" + punID);
        }
    }
}
