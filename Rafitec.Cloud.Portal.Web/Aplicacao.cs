using Rafitec.Cloud.Portal.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rafitec.Cloud.Portal.Web.Areas.Admin.Controllers;

namespace Rafitec.Cloud.Portal.Web
{
    public static class Aplicacao
    {
        public static Usuario UsuarioLogado
        {
           get
            {
                return UsuarioController.GetUsuarioLogado();
            }
        }
    }
}