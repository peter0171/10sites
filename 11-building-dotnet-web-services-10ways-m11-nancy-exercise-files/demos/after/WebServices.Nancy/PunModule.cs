using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Nancy;
using Nancy.ModelBinding;

namespace WebServices.Nancy
{
    public class PunModule : NancyModule
    {
        public PunModule() : base("/puns")
        {
            Get["/"] = arguments => GetPuns();
            Get["/{PunID}"] = arguments => GetPunById(arguments.PunID);
            Post["/"] = arguments => CreatePun();
            Put["/{PunID}"] = arguments => UpdatePun(arguments.PunID);
            Delete["/{PunID}"] = arguments => DeletePun(arguments.PunID);
        }

        private Pun[] GetPuns()
        {
            var service = new PunDataService();
            return service.GetPuns();
        }

        private Pun GetPunById(int punID)
        {
            var service = new PunDataService();
            return service.GetPunById(punID);
        }

        private Pun CreatePun()
        {
            var pun = this.Bind<Pun>();
            var service = new PunDataService();
            service.AddPun(pun);
            return pun;
        }

        private Pun UpdatePun(int punID)
        {
            var pun = this.Bind<Pun>();
            var service = new PunDataService();
            service.UpdatePun(pun);
            return pun;
        }

        private HttpStatusCode DeletePun(int punID)
        {
            var service = new PunDataService();
            service.DeletePun(punID);
            return HttpStatusCode.NoContent;
        }
    }
}