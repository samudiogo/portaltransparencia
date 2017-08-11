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

            var dicionarioGrafico = new Dictionary<string, int>
            {
                {"Defensores",830 },
                {"Servidores",1300 },
                {"Extraquadro",250 },
                {"Cedidos",50 }
            };
            ViewBag.dicionarioGraficoPeriodo = DateTime.Today.ToString("MMMM/yyyy");
            ViewBag.dicionarioGrafico = dicionarioGrafico;

            ViewBag.dicionarioGraficoTotal = dicionarioGrafico.Values.Sum();
            ViewBag.Situacao = "Ativos";
            ViewBag.ListaPeriodo = await _service.ObterPeriodoQuadroServidorAsync("ativo");



            return View("QuadroCargoAtivo");
        }

        [Route("partial-ListaQuadroCargosAtivos")]
        public PartialViewResult ListaQuadroCargosAtivos(DateTime? periodo)
        {
            var periodoFiltro = periodo ?? DateTime.Today;

            var modelList = Task.Run(async () => await _service.ObterListaServidorAtivoPorPeriodoAsync(periodoFiltro)).Result.ToList();

            if (!modelList.Any()) return PartialView("_ListaQuadroAtivo", modelList);
            ViewBag.Periodo = modelList.First().Periodo.ToString("MMMM 'de' yyyy");

            return PartialView("_ListaQuadroAtivo", modelList);
        }

    }
}