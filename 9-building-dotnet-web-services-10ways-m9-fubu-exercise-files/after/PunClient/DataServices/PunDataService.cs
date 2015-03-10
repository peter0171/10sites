using System;
using System.Collections.Generic;
using PunClient.Transports;
using Spring.Http.Converters.Json;
using Spring.Rest.Client;

namespace PunClient.DataServices
{
    class PunDataService
    {
        private RestTemplate _restTemplate;
        public PunDataService()
        {
            _restTemplate = new RestTemplate("http://localhost:60776/");
            _restTemplate.MessageConverters.Add(new DataContractJsonHttpMessageConverter());
        }

        public Pun[] GetPuns()
        {
            var puns = _restTemplate.GetForObject<Pun[]>("/puns");
            return puns;
        }

        public Pun GetPunByID(int punID)
        {
            var arguments = new Dictionary<string, object>();
            arguments.Add("PunID", punID);
            var pun = _restTemplate.GetForObject<Pun>("/puns/{PunID}", arguments);
            return pun;
        }

        public void CreatePun(Pun pun)
        {
            _restTemplate.PostForMessage<Pun>("/puns", pun);
        }

        public void UpdatePun(Pun pun)
        {
            _restTemplate.Put("/puns/{PunID}", pun, pun.PunID);
        }

        public void DeletePun(int punID)
        {
            _restTemplate.Delete("/puns/{PunID}", punID);
        }
    }
}
