using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace WebService.MVC3.Filters
{
    public class NegotiateContentFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var acceptContent = filterContext.RequestContext.HttpContext.Request.Headers["Accept"];
            if (acceptContent == "text/xml")
            {
                var contentResult = new ContentResult();
                contentResult.ContentType = "text/xml";
                var data = ((JsonResult) filterContext.Result).Data;
                var serializer = new XmlSerializer(data.GetType());
                var stringWriter = new StringWriter();
                var xmlWriter = XmlWriter.Create(stringWriter);
                serializer.Serialize(xmlWriter, data);

                contentResult.Content = stringWriter.ToString();
                filterContext.Result = contentResult;
            }
        }
    }
}