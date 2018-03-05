using System.Linq;
using System.Web.Mvc;
using PortalDPGE.Dados.Persistencia;
using PortalDPGE.Dom.Regras;

namespace Transparencia.Web.Controllers
{
    [RoutePrefix("concursos")]
    public class ConcursosController : Controller
    {
        // GET: Concursos
        public ActionResult Index()
        {
            return View();
        }

        #region Concursos

        [Route("Concurso-Servidor")]
        public ActionResult ConcursoServidor()
        {
            ViewBag.Title = "Concurso para Servidor";
            var model = new DocumentoRegras { Servico = new DocumentoDados() }
                .BuscarDocumentos((int)PortalRegras.Portais.SiteId, "Concurso - Servidor", string.Empty).OrderByDescending(doc => doc.DataPublicacao);

            return View("Concursos", model);
        }

        [Route("Concurso-Defensor")]
        public ActionResult ConcursoDefensor()
        {
            ViewBag.Title = "Concurso para Defensor Público";
            var model = new DocumentoRegras { Servico = new DocumentoDados() }
                .BuscarDocumentos((int)PortalRegras.Portais.SiteId, "Concurso - Defensor Público", string.Empty).OrderByDescending(doc => doc.DataPublicacao);

            return View("Concursos", model);
        }
        [Route("Concurso-Estagio-Forense")]
        public ActionResult ConcursoEstagio()
        {
            ViewBag.Title = "Concurso para Estágio";
            var model = new DocumentoRegras { Servico = new DocumentoDados() }
                .BuscarDocumentos((int)PortalRegras.Portais.SiteId, "Concurso - Estágio Forense", string.Empty).OrderByDescending(doc => doc.DataPublicacao);

            return View("Concursos", model);
        }
        [Route("Concurso-Residente-Juridico")]
        public ActionResult ConcursoResidente()
        {
            ViewBag.Title = "Concurso para Residente Jurídico";
            var model = new DocumentoRegras { Servico = new DocumentoDados() }
                .BuscarDocumentos((int)PortalRegras.Portais.SiteId, "Concurso - Residente Jurídico", string.Empty).OrderByDescending(doc => doc.DataPublicacao);
            return View("Concursos", model);
        }

        #endregion
    }
}