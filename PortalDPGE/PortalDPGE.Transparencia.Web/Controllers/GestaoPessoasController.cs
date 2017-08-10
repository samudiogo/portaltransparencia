using Newtonsoft.Json;
using PortalDPGE.Transparencia.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using PortalDPGE.Transparencia.Web.Services;

namespace PortalDPGE.Transparencia.Web.Controllers
{
    [RoutePrefix("gestao-pessoas")]
    public class GestaoPessoasController : Controller
    {


        private readonly IGestaoPessoaApiService _service;
        private readonly string _periodoAtual = DateTime.Today.ToString("MM/yy");

        public GestaoPessoasController()
        {
            _service = new GestaoPessoaApiService();
        }

        public GestaoPessoasController(IGestaoPessoaApiService servico)
        {
            _service = servico;
        }


        // GET: GestaoPessoas
        public ActionResult Index()
        {
            return View();
        }
        [Route("quadro-servidores-ativos")]
        public async Task<ActionResult> ListaQuadroAtivos()
        {


            ViewBag.ListaPeriodo = await _service.ObterPeriodoQuadroServidorAsync("ativo");
            
            //var modelList = new List<ServidorModel>
            //{
            //    new ServidorModel
            //    {
            //        Nome = "Samuel",
            //        Periodo = DateTime.Today
            //    }
            //};
            var modelList = await _service.ObterListaServidorPorSituaoPeriodoAsync("ativo","01-08-2017");
            ViewBag.Periodo = modelList.First().Periodo.ToString("MMMM 'de' yyyy");
            return View(modelList);
        }

    }
}