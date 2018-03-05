
using Global.Dados.Persistencia;
using Global.Dom.Entidade.PortalDPGE;
using Global.Dom.Regras;
using Global.Dom.Util;
using PortalDPGE.Dados.Persistencia;
using PortalDPGE.Dom.Regras;
using PortalDPGE.Dom.Util;
using PortalDPGE.Restrito.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Transparencia.Web.Controllers
{
    [RoutePrefix("licitacoes-contratos-convenios")]
    public class LicitacaoController : Controller
    {
        [Route("index")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("licitacoes")]
        public ActionResult Licitacoes(bool completa = false)
        {
            ViewBag.ResultadoIsCompleta = completa;
            var lRegras = new LicitacaoRegras { Servico = new LicitacaoDados() };
            var listModel = lRegras.Listar(completa).Select(licitacao => new Models.LicitacaoViewModel
            {
                Id = licitacao.Id,
                CodigoLicitacao = licitacao.CodigoLicitacao,
                Modalidade = licitacao.ModalidadeLicitacao.Descricao,
                Descricao = licitacao.Descricao,
                DataAbertura = licitacao.DataAbertura
            }).ToList();

            return View(listModel);
        }

        [Route("licitacoes/detalhes")]
        public ActionResult Detalhes(int? id)
        {
            var urlId = id ?? 0;
            var lRegras = new LicitacaoRegras { Servico = new LicitacaoDados() };
            
            if (urlId <= 0) return RedirectToAction("Index");

            var dbModel = lRegras.ObterPorId(urlId, true);
            
            if (dbModel == null) return Index();
            var model = new Models.LicitacaoViewModel().CopiarEstado(dbModel) as Models.LicitacaoViewModel;
            if (model == null) return Index();

            model.Tipo = dbModel.TipoLicitacao.Descricao;
            model.Modalidade = dbModel.ModalidadeLicitacao.Descricao;
            model.Situacao = dbModel.SituacaoLicitacao.Descricao;

            model.ListaDocumentos = dbModel.Documentos.Select(documento => new Models.LicitacaoDocumento
            {
                Id = documento.Id,
                Nome = documento.Nome,
                Descricao = documento.Descricao,
                Url = DicionarioPortalDPGE.uploadsLicitacao + documento.Arquivo.NomeServidor,
                NomeUsuario = documento.Arquivo.Usuario.RegistroFuncional == null ? "usuario: " + documento.Arquivo.Usuario.Login : documento.Arquivo.Usuario.RegistroFuncional.Pessoa.Nome,
                DataInclusao = documento.Arquivo.DataInclusao
            }).ToList();

            return View(model);
        }


        [Route("contratos")]
        public ActionResult ContratosDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Contratos");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }
        [Route("contratos-de-alugueis")]
        public ActionResult ContratosDeAlugueisDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Contratos de Aluguéis");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }
        [Route("ata-de-registro-de-preco")]
        public ActionResult AtaDeRegistroDePrecoDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Ata de Registro de Preços");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }
        [Route("convenios-e-instrumentos-congeneres")]
        public ActionResult ConveniosEInstrumentosCongeneresDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Convênios e Instrumentos Congêneres");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }
        protected static TipoDocumento DocumentosPorTipo(string NomeTipo)
        {
            var regras = new TipoDocumentoRegras { Servico = new TipoDocumentoDados() };
            return regras.MontaHierarquiaTipoTransparencia(regras.ObterPorNomeIgualSemPai(NomeTipo)).FirstOrDefault();
        }

        //FILTRAR
        [Route("licitacoes/filtrado")]
        public ActionResult FiltraLicitacoes(Models.FiltroLicitacaoViewModel model)
        {
            if (model.IdFiltro == 0)
                return RedirectToAction("Index");
            var lRegras = new LicitacaoRegras { Servico = new LicitacaoDados() };
            var listModel = lRegras.ListarFiltrado(model.IdFiltro).Select(licitacao => new Models.LicitacaoViewModel
            {
                Id = licitacao.Id,
                CodigoLicitacao = licitacao.CodigoLicitacao,
                Modalidade = licitacao.ModalidadeLicitacao.Descricao,
                Descricao = licitacao.Descricao,
                DataAbertura = licitacao.DataAbertura
            }).ToList();

            return View(listModel);
        }
    }
}