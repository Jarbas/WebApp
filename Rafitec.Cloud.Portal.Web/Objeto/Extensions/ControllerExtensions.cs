using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rafitec.Cloud.Portal.Web.Objeto.Extensions
{
    public static class ControllerExtensions
    {
        public static string RenderPartialViewToString(this Controller controller, string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = controller.ControllerContext.RouteData.GetRequiredString("action");

            var viewData = new ViewDataDictionary(model);

            var sw = new StringWriter();
            var viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
            var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, viewData, new TempDataDictionary(), sw);
            viewResult.View.Render(viewContext, sw);

            return sw.GetStringBuilder().ToString();

        }
    }
}