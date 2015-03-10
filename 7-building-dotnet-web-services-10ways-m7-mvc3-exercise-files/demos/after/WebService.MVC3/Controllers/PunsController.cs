using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using WebService.MVC3.Filters;
using WebService.MVC3.Results;

namespace WebService.MVC3.Controllers
{
    public class PunsController : Controller
    {
        private PunDataService _service;

        public PunsController()
        {
            _service = new PunDataService();
        }
        //
        // GET: /Puns/

        [NegotiateContentFilter]
        public ActionResult Index()
        {
            var puns = _service.GetPuns();
            return Json(puns, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPun(int id)
        {
            var pun = _service.GetPunById(id);
            return new NegotiatedResult() {Data = pun};
        }

        [HttpPost]
        public ActionResult Create(Pun pun)
        {
            _service.AddPun(pun);
            return Json(pun);
        }

        [HttpPut]
        public ActionResult Update(Pun pun)
        {
            _service.UpdatePun(pun);
            return Json(pun);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _service.DeletePun(id);
            return Json(null);
        }
    }
}
