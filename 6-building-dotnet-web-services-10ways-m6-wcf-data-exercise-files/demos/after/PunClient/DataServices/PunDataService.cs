using System;
using System.Collections.Generic;
using System.Linq;
using PunClient.PunService;

namespace PunClient.DataServices
{
    class PunDataService
    {
        private PunContext _service;
            
        public PunDataService()
        {
            _service = new PunContext(new Uri("http://localhost:54580/PunService.svc/"));
        }

        public Pun[] GetPuns()
        {
            return _service.Puns.ToArray();
        }

        public Pun GetPunByID(int punID)
        {
            return _service.Puns.Where(p => p.PunID == punID).First();
        }

        public void CreatePun(Pun pun)
        {
            _service.AddToPuns(pun);
            _service.SaveChanges();
        }

        public void UpdatePun(Pun pun)
        {
            var oldPun = _service.Puns.Where(p => p.PunID == pun.PunID).First();
            oldPun.Title = pun.Title;
            oldPun.Joke = pun.Joke;
            _service.SaveChanges();
        }

        public void DeletePun(int punID)
        {
            var pun = _service.Puns.Where(p => p.PunID == punID).First();
            _service.DeleteObject(pun);
            _service.SaveChanges();
        }
    }
}
