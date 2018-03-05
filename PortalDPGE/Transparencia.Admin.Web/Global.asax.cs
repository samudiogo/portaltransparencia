using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using Global.App.Util;
using Global.Dados.Persistencia.Log;
using Global.Dom.Servico;
using Global.Dom.Util;

namespace Transparencia.Admin.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            /*
            * Adicionando customização de referenciador virtual de arquivos, e adicionando a referencia ao módulo adicionado.
            * TODOS os módulos que venham a ser compartilhar views deverão ser declarados aqui.
            */
            HostingEnvironment.RegisterVirtualPathProvider(new EmbeddedResourceViewPathProvider(
                new Modulo[] { new Global.App.Info.GlobalApp() }));

        }

        // Chamado quando o ASP.NET pega o Session state da requisição
        protected void Application_AcquireRequestState()
        {
            SistemaLog.Instance.InitInstance(new LogAcessoDados(), new LogOperacaoDados(), new TipoLogOperacaoDados());

            // necessário para transformar o HttpContext em HttpContextBase
            var contextBase = new HttpContextWrapper(HttpContext.Current);

            Sistema.RemontaSessao(contextBase);

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            SistemaLog.Instance.InitInstance(new LogAcessoDados(), new LogOperacaoDados(), new TipoLogOperacaoDados());
        }

    }
}
