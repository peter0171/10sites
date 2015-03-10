using System;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using Data;

namespace WebServices.WCFData
{
    public class PunService : DataService<PunContext>
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("Puns", EntitySetRights.All);
            config.UseVerboseErrors = true;
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
        }
    }

    public class PunContext : IUpdatable
    {
        private PunDataService _service;

        public PunContext()
        {
            _service = new PunDataService();
        }

        public IQueryable<Pun> Puns {
            get { 
                return _service.GetPuns().AsQueryable();
            }
        }

        public object CreateResource(string containerName, string fullTypeName)
        {
            var pun = new Pun();
            _service.AddPun(pun);
            return pun.PunID;
        }

        public object GetResource(IQueryable query, string fullTypeName)
        {
            var enumerator = query.GetEnumerator();
            enumerator.MoveNext();
            return ((Pun) enumerator.Current).PunID;
        }

        public object ResetResource(object resource)
        {
            var pun = _service.GetPunById((int) resource);
            pun.Title = null;
            pun.Joke = null;
            return pun.PunID;
        }

        public void SetValue(object targetResource, string propertyName, object propertyValue)
        {
            var pun = _service.GetPunById((int) targetResource);
            if (propertyName == "Joke")
                pun.Joke = (string) propertyValue;
            else if (propertyName == "Title")
                pun.Title = (string) propertyValue;
        }

        public object GetValue(object targetResource, string propertyName)
        {
            throw new NotImplementedException();
        }

        public void SetReference(object targetResource, string propertyName, object propertyValue)
        {
            throw new NotImplementedException();
        }

        public void AddReferenceToCollection(object targetResource, string propertyName, object resourceToBeAdded)
        {
            throw new NotImplementedException();
        }

        public void RemoveReferenceFromCollection(object targetResource, string propertyName, object resourceToBeRemoved)
        {
            throw new NotImplementedException();
        }

        public void DeleteResource(object targetResource)
        {
            _service.DeletePun((int) targetResource);
        }

        public void SaveChanges()
        {
            _service.Save();
        }

        public object ResolveResource(object resource)
        {
            var pun = _service.GetPunById((int) resource);
            return pun;
        }

        public void ClearChanges()
        {
            throw new NotImplementedException();
        }
    }
}
