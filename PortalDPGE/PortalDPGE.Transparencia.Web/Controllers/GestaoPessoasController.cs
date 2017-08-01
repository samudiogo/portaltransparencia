using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalDPGE.Transparencia.Web.Controllers
{
    [RoutePrefix("gestao-pessoas")]
    public class GestaoPessoasController : Controller
    {
        // GET: GestaoPessoas
        public ActionResult Index()
        {
            return View();
        }
        [Route("quadro-servidores-ativos")]
        public ActionResult ListaQuadroAtivos()
        {
            return View();
        }
    }
}