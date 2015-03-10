using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace WebServices.SS
{
    [Route("/puns", Verbs="GET")]
    public class GetPunsRequest : IReturn<Pun[]>
    {
    }

    [Route("/puns/{PunID}", Verbs = "GET, DELETE")]
    public class PunIDRequest
    {
        public int PunID { get; set; }
    }

    [Route("/puns", Verbs = "POST")]
    [Route("/puns/{PunID}", Verbs = "PUT")]
    public class PunRequest: IReturn<Pun>
    {
        public int PunID { get; set; }
        public string Title { get; set; }
        public string Joke { get; set; }
    }

    public class PunService : Service
    {
        public object Get(GetPunsRequest request)
        {
            var service = new PunDataService();
            return service.GetPuns();
        }

        public object Get(PunIDRequest request)
        {
            var service = new PunDataService();
            return service.GetPunById(request.PunID);
        }

        public object Post(PunRequest request)
        {
            var service = new PunDataService();
            var dataPun = new Data.Pun
                {
                    PunID = 0,
                    Title = request.Title,
                    Joke = request.Joke
                };
            service.AddPun(dataPun);
            return dataPun;
        }

        public object Put(PunRequest request)
        {
            var service = new PunDataService();
            var dataPun = new Data.Pun
            {
                PunID = request.PunID,
                Title = request.Title,
                Joke = request.Joke
            };
            service.UpdatePun(dataPun);
            return dataPun;
        }

        public void Delete(PunIDRequest request)
        {
            var service = new PunDataService();
            service.DeletePun(request.PunID);
        }
    }
}