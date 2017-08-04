using Newtonsoft.Json;
using PortalDPGE.Transparencia.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PortalDPGE.Dom.Regras.Transparencia;
using PortalDPGE.Dom.Servico.Transparencia;

namespace PortalDPGE.Transparencia.Web.Controllers
{
    [RoutePrefix("gestao-pessoas")]
    public class GestaoPessoasController : Controller
    {

        private readonly IServidorRegras _servico;

        public GestaoPessoasController() { }
        
        public GestaoPessoasController(IServidorRegras servico)
        {
            _servico = servico;
        }
        

        // GET: GestaoPessoas
        public ActionResult Index()
        {
            return View();
        }
        [Route("quadro-servidores-ativos")]
        public ActionResult ListaQuadroAtivos()
        {
            var lista = _servico.ListarServidor(s => s.Cargo.Equals("Ativo") && s.Nomeacao.ToString("M/yy") == DateTime.Today.ToString("M/yy"));


            List<ServidorModel> modelList;
            using (var sr = new StreamReader(Server.MapPath("~/Content/MOCK_DATA.json")))
            {
                modelList = JsonConvert.DeserializeObject<List<ServidorModel>>(sr.ReadToEnd());
            }

            return View(modelList);
        }

    }
}