using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data;

namespace WebServices.MVC4.Controllers
{
    public class PunsController : ApiController
    {
        public IEnumerable<Pun> Get()
        {
            var service = new PunDataService();
            return service.GetPuns();
        }

        public Pun Get(int id)
        {
            var service = new PunDataService();
            return service.GetPunById(id);
        }

        /// <summary>
        /// Create a new pun in the database
        /// </summary>
        /// <param name="pun">The pun to store in the database</param>
        /// <returns>The saved pun with an updated PunID</returns>
        public Pun Post(Pun pun)
        {
            var service = new PunDataService();
            service.AddPun(pun);
            return pun;
        }

        public Pun Put(int id, Pun pun)
        {
            var service = new PunDataService();
            service.UpdatePun(pun);
            return pun;
        }

        public void Delete(int id)
        {
            var service = new PunDataService();
            service.DeletePun(id);
        }
    }
}
