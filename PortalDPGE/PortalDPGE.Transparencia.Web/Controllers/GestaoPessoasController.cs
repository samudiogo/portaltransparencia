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
        public async Task<ActionResult> QuadroCargoAtivos()
        {

            var dicionarioGrafico = await _service.ObterTotaisDeServidoresAtivos();

            ViewBag.dicionarioGraficoPeriodo = DateTime.Today.ToString("MMMM/yyyy");
            ViewBag.Periodo = DateTime.Today.ToString("MMMM/yyyy");
            ViewBag.dicionarioGrafico = dicionarioGrafico;

            ViewBag.dicionarioGraficoTotal = dicionarioGrafico?.Values.Sum();
            ViewBag.Situacao = "Ativos";
            ViewBag.ListaPeriodo = await _service.ObterPeriodoQuadroServidorAsync("ativo");
            

            return View("QuadroCargoAtivo");
        }
        
    }
}