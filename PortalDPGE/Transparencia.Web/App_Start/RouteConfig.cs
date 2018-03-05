using PortalDPGE.Web;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Transparencia.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();
            //routes.MapRoute(
            //    name: "ApiRota",
            //    url: "api/{controller}/{action}/{id}",
            //    defaults: new { controller = "Portal", action = "Index", id = UrlParameter.Optional },
            //    namespaces: new[] { "Transparencia.Web.Controllers" }
            //);
            routes.Add("noticias", new SeoFriendlyRoute("noticia/detalhes/{id}",
           new RouteValueDictionary(new { controller = "Noticia", action = "Detalhar" }),
           new MvcRouteHandler()));

            routes.Add("legislacoes", new SeoFriendlyRoute("legislacao/detalhes/{id}",
                        new RouteValueDictionary(new { controller = "Legislacao", action = "Detalhar" }),
                        new MvcRouteHandler()));

            routes.Add("programasEservicos", new SeoFriendlyRoute("Cidadao/Programas-e-Servicos/detalhes/{id}",
                        new RouteValueDictionary(new { controller = "Cidadao", action = "ProgramasServicosDetalhar" }),
                        new MvcRouteHandler()));

            routes.MapRoute(name: "busca-geral-portal", url: "busca/{palavrachave}/{page}",
                defaults: new { controller = "Portal", action = "BuscaGeral", palavrachave = UrlParameter.Optional, page = UrlParameter.Optional },
                namespaces: new[] { "Transparencia.Web.Controllers" });

            routes.MapRoute(
                name: "padrao-exibe-conteudo",
                url: "Exibir/{areaOuSecao}/{alias}",
                defaults: new { controller = "Conteudo", action = "Detalhar", areaOuSecao = UrlParameter.Optional, alias = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "homepage",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Portal", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Transparencia.Web.Controllers" }
            );
        }
    }
    /// <summary>
    /// fonte:http://www.jerriepelser.com/blog/generate-seo-friendly-urls-aspnet-mvc
    /// </summary>
    public class SeoFriendlyRoute : Route
    {
        public SeoFriendlyRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler)
            : base(url, defaults, routeHandler)
        {
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var routeData = base.GetRouteData(httpContext);

            if (routeData != null)
            {
                if (routeData.Values.ContainsKey("id"))
                    routeData.Values["id"] = GetIdValue(routeData.Values["id"]);
            }

            return routeData;
        }

        private object GetIdValue(object id)
        {
            if (id == null) return null;

            var idValue = id.ToString();

            var regex = new Regex(@"^(?<id>\d+).*$");

            var match = regex.Match(idValue);

            return match.Success ? match.Groups["id"].Value : id;
        }
    }
}
