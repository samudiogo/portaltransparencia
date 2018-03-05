using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Global.Dom.Servico;
using Global.Dom.Util;
using System.Web.Optimization;

namespace Transparencia.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            /*
            * Adicionando customização de referenciador virtual de arquivos, e adicionando a referencia ao módulo adicionado.
            * TODOS os módulos que venham a ser compartilhar views deverão ser declarados aqui.
            */
            HostingEnvironment.RegisterVirtualPathProvider(new EmbeddedResourceViewPathProvider(
                                                           new Modulo[] { new PortalDPGE.App.Info.PortalDPGEApp() }));

            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
