using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Data;

namespace PunService.AJAX
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class PunService
    {
        private PunDataService _service;

        public PunService()
        {
            _service = new PunDataService();
        }

        [WebGet]
        public Pun[] GetPuns()
        {
            return _service.GetPuns();
        }

        [WebGet]
        public Pun GetPunByID(int punID)
        {
            return _service.GetPunById(punID);
        }

        [WebInvoke]
        public void CreatePun(Pun pun)
        {
            _service.AddPun(pun);
        }

        [WebInvoke]
        public void UpdatePun(Pun pun)
        {
            _service.UpdatePun(pun);
        }

        [WebInvoke]
        public void DeletePun(int id)
        {
            _service.DeletePun(id);
        }
    }
}
