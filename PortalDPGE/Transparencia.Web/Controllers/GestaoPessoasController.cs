using Global.Dom.Entidade.PortalDPGE.Views;
using NHibernate.Util;
using PortalDPGE.Dados.Persistencia;
using PortalDPGE.Dom.Regras;
using PortalDPGE.Dom.Util;
using PortalDPGE.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Transparencia.Web.Services;

namespace Transparencia.Web.Controllers
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
        [Route("servidores-ativos")]
        public ActionResult QuadroCargoAtivos()
        {
            return View("QuadroCargoAtivo");
        }
        [Route("servidores-inativos")]
        public ActionResult QuadroCargoInativos()
        {
            //ViewBag.ListaPeriodoInativos = await _service.ObterPeriodoQuadroServidorAsync("inativo");
            return View("QuadroCargoInativos");
        }
        [Route("quadro-cargos-vagos-e-ocupados")]
        public ActionResult QuadroCargosVagosEOcupados()
        {

            return View("QuadroCargosVagosEOcupados");
        }

        [Route("estagiarios")]
        public ActionResult Estagiarios()
        {
            return View("Estagiarios");
        }

        [Route("residentes-juridicos")]
        public ActionResult ResidentesJuridicos()
        {
            return View("ResidentesJuridicos");
        }

        [Route("antiguidade-servidores")]
        public ActionResult ResultadoAntiguidadeServidores()
        {
            return View("ResultadoAntiguidadeServidor");
        }

        [Route("antiguidade-defensores-publicos")]
        public ActionResult ResultadoAntiguidadeDefensor()
        {
            return View("ResultadoAntiguidadeDefensor");
        }

        [Route("pagina/estrutura-remuneratoria-dos-cargos-efetivos")]
        public ActionResult EstruturaRemuneratoria()
        {
            return View("EstruturaRemuneratoria");
        }

        #region movimentação
        [Route("movimentacao-defensores-publicos")]
        public async Task<ActionResult> MovimentacaoDefensores()
        {


            var regra = new DocumentoRegras { Servico = new DocumentoDados() }
               .ListarPorPortal((int)PortalRegras.Portais.SiteId);

            var modelGroup = (from d in regra
                              where d.TipoDocumento.Nome.Contains("Movimentação - Defensores")
                              group d by d.DataPublicacao.Value.Year
                              ).ToList();


            var model = new List<DocumentoMovimentacaoViewModel>();

            foreach (var colecao in modelGroup)
            {

                var docs = colecao.GroupBy(x => x.DataPublicacao.Value.Month).ToList();

                foreach (var item in docs)
                {
                    var doc = new DocumentoMovimentacaoViewModel
                    {
                        Mes = new DateTime(colecao.Key, item.Key, 1),
                        Id = string.Format("{0}_{1,2:00}", colecao.Key, item.Key)
                    };
                    var listaDocumentoItems = new List<DocumentoItemViewModel>();

                    item.ForEach(x => listaDocumentoItems.Add(new DocumentoItemViewModel
                    {
                        Titulo = x.Nome,
                        Link = DicionarioPortalDPGE.uploadsArquivos + x.Arquivo.NomeServidor
                    }));
                    doc.ListaDocumentoItems = listaDocumentoItems;
                    model.Add(doc);
                }
            }

            return View(model.OrderByDescending(i => i.Id));

            //var listaMovimentacao = (await _service.ObterListaMovimentacaoDefensoresAsync()).ToList();

            //var ultimoAno = listaMovimentacao.OrderByDescending(lm => lm.DataPublicacao.Year).First().DataPublicacao.Year;


            //var model = MapeaListaMovimentacao(listaMovimentacao.Where(lm => lm.DataPublicacao.Year == ultimoAno));
            //ViewBag.historico = false;
            //return View(model.OrderByDescending(i => i.Id));
        }

        [Route("movimentacao-defensores-publicos-historico")]
        public async Task<ActionResult> MovimentacaoDefensoresComHistorico()
        {

            var regra = new DocumentoRegras { Servico = new DocumentoDados() }
   .ListarPorPortal((int)PortalRegras.Portais.SiteId);

            var modelGroup = (from d in regra
                              where d.TipoDocumento.Nome.Contains("Movimentação - Defensores")
                              group d by d.DataPublicacao.Value.Year
                              ).ToList();


            var model = new List<DocumentoMovimentacaoViewModel>();

            foreach (var colecao in modelGroup)
            {

                var docs = colecao.GroupBy(x => x.DataPublicacao.Value.Month).ToList();

                foreach (var item in docs)
                {
                    var doc = new DocumentoMovimentacaoViewModel
                    {
                        Mes = new DateTime(colecao.Key, item.Key, 1),
                        Id = string.Format("{0}_{1,2:00}", colecao.Key, item.Key)
                    };
                    var listaDocumentoItems = new List<DocumentoItemViewModel>();

                    item.ForEach(x => listaDocumentoItems.Add(new DocumentoItemViewModel
                    {
                        Titulo = x.Nome,
                        Link = DicionarioPortalDPGE.uploadsArquivos + x.Arquivo.NomeServidor
                    }));
                    doc.ListaDocumentoItems = listaDocumentoItems;
                    model.Add(doc);
                }
            }

            return View("MovimentacaoDefensores", model.OrderByDescending(i => i.Id));



            var _model = MapeaListaMovimentacao((await _service.ObterListaMovimentacaoDefensoresAsync()).ToList());

            return View("MovimentacaoDefensores", _model.OrderByDescending(i => i.Id));
        }

        private static IEnumerable<DocumentoMovimentacaoViewModel> MapeaListaMovimentacao(IEnumerable<MovimentacaoDefensor> listaMovimentacao)
        {
            var modelGroup = listaMovimentacao.GroupBy(g => g.DataPublicacao.Year).ToList();
            var model = new List<DocumentoMovimentacaoViewModel>();

            foreach (var colecao in modelGroup)
            {
                //crio coleção de docs por mês
                var docs = colecao.GroupBy(x => x.DataPublicacao.Month).ToList();

                model.AddRange(docs.Select(item => new DocumentoMovimentacaoViewModel
                {
                    Mes = new DateTime(colecao.Key, item.Key, 1),
                    Id = $"{colecao.Key}_{item.Key,2:00}",
                    ListaDocumentoItems = item.Select(docItem => new DocumentoItemViewModel
                    {
                        Titulo = docItem.Titulo,
                        Link = DicionarioPortalDPGE.uploadsArquivos + docItem.Link
                    })
                        .ToList()
                }));
            }

            return model;
        }
        #endregion

    }
}