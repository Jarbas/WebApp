using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Claims;
using Rafitec.Cloud.Api_Rafitec.Areas.Admin.Controllers;

namespace Rafitec.Cloud.Api_Rafitec.App_Start
{
    public class ConfiguracaoAcessoToken : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
              context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var usuario = new UsuarioController();
            if (! usuario.ValidarUsuarioSenha(context.UserName, context.Password))
            {
                context.SetError("false");
                return;
            }

            var identidadeUsder = new ClaimsIdentity(context.Options.AuthenticationType);
            context.Validated(identidadeUsder);
        }
    }
}