using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Funq;
using ServiceStack.WebHost.Endpoints;

namespace WebServices.SS
{
    public class AppHost : AppHostHttpListenerBase
    {
        public AppHost() : base("PunService", typeof(AppHost).Assembly)
        {
            
        }

        public override void Configure(Container container)
        {
            
        }
    }
}