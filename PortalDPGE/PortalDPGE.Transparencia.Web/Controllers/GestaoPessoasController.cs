using Newtonsoft.Json;
using PortalDPGE.Transparencia.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            var modelList = new List<ServidorModel>();
            using (var sr = new StreamReader(Server.MapPath("~/Content/MOCK_DATA.json")))
            {
                modelList = JsonConvert.DeserializeObject<List<ServidorModel>>(sr.ReadToEnd());
            }

            return View(modelList);
        }
    }
}