using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace WebService.MVC3.Results
{
    public class NegotiatedResult : ActionResult
    {
        public object Data { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context.HttpContext.Request.Headers["Accept"] == "text/xml")
            {
                var serializer = new XmlSerializer(Data.GetType());
                var stringWriter = new StringWriter();
                var xmlWriter = XmlWriter.Create(stringWriter);
                serializer.Serialize(xmlWriter, Data);

                context.HttpContext.Response.ContentType = "text/xml";
                context.HttpContext.Response.Write(stringWriter.ToString());
            }
            else
            {
                var jsonResult = new JsonResult();
                jsonResult.Data = Data;
                if(context.HttpContext.Request.HttpMethod == "GET")
                    jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                jsonResult.ExecuteResult(context);
            }
        }
    }
}