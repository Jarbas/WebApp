using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rafitec.Cloud.Portal.Web.Controllers
{
    public class PermissaoController : Controller
    {
        
        public ActionResult SemAcesso()
        {
            return View();
        }
    }
}