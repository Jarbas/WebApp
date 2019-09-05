using Rafitec.Cloud.Portal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rafitec.Cloud.Portal.Web.HtmlHelpers;

namespace Rafitec.Cloud.Portal.Web.Controllers
{
    [Authorize]
    public class ResponseController : Controller
    {
        [AllowAnonymous]
        public JsonResult Get(ResponseModelView responseModelView)
        {
            var response = new Response();
            response.Status = responseModelView.Status;
            response.View = ViewHelper.RenderViewToString(this.ControllerContext, "~/View/Response/_ModalResponseMensagem.cshtml", responseModelView);
            
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        
    }
}