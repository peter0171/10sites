using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using WebService.Fubu.Models;

namespace WebService.Fubu
{
    public class PunEndpoints
    {
        //GET /Puns
        public Pun[] Get_Puns()
        {
            var service = new PunDataService();
            return service.GetPuns();
        }

        //GET /Puns/{PunID}
        public Pun Get_Puns_PunID(PunIDRequest request)
        {
            var service = new PunDataService();
            return service.GetPunById(request.PunID);
        }

        public Pun Post_Puns(Pun pun)
        {
            var service = new PunDataService();
            service.AddPun(pun);
            return pun;
        }

        public Pun Put_Puns_PunID(Pun pun)
        {
            var service = new PunDataService();
            service.UpdatePun(pun);
            return pun;
        }

        public void Delete_Puns_PunID(PunIDRequest request)
        {
            var service = new PunDataService();
            service.DeletePun(request.PunID);
        }
    }
}