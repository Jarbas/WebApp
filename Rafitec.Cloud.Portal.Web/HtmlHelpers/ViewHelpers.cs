﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rafitec.Cloud.Portal.Web.HtmlHelpers
{
    public static class ViewHelper
    {
        public static string RenderViewToString(this ControllerContext context, string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = context.RouteData.GetRequiredString("action");

            var viewData = new ViewDataDictionary(model);

            var sw = new StringWriter();
            var viewResult = ViewEngines.Engines.FindPartialView(context, viewName);
            var viewContext = new ViewContext(context, viewResult.View, viewData, new TempDataDictionary(), sw);
            viewResult.View.Render(viewContext, sw);

            return sw.GetStringBuilder().ToString();
            
        }
        
    }
}