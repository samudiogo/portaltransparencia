using Global.Dom.Entidade.PortalDPGE;
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
    [RoutePrefix("relatorios-e-prestacoes-de-contas")]
    public class RelatoriosEPrestacoesDeContasController : Controller
    {
        [Route("relatorio-de-gestao")]
        public ActionResult RelatorioDeGestaoDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Relatório de Gestão");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }
        [Route("gestao-fiscal")]
        public ActionResult GestaoFiscalDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Gestão Fiscal");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }
        [Route("prestacao-de-contas")]
        public ActionResult PrestacaoDeContasDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Prestação de Contas");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }

        protected static TipoDocumento DocumentosPorTipo(string NomeTipo)
        {
            var regras = new TipoDocumentoRegras { Servico = new TipoDocumentoDados() };
            return regras.MontaHierarquiaTipoTransparencia(regras.ObterPorNomeIgualSemPai(NomeTipo)).FirstOrDefault();
        }
    }
}