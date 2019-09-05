using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rafitec.Cloud.Portal.Web.Controllers
{
    public class QuestaoController : Controller
    {
        // GET: Questao
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Cadastro()
        {
            var model = new Models.Questao();
            return View(model);
        }

        [HttpPost]
        public ActionResult Cadastro(Models.Questao param)
        {

            foreach(var prop in param.Alternativas)
            {
                prop.Id = 100;
            }

            return null;
        }
    }
}