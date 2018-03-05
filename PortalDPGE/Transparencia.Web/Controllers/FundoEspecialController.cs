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
    [RoutePrefix("fundo-especial")]
    public class FundoEspecialController : Controller
    {
        [Route("conselho-de-controle-e-gestao")]
        public ActionResult Conselho()
        {
            return View();
        }

        [Route("atas-das-reunioes")]
        public ActionResult AtasDasReunioesDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Atas das Reuniões");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }
        [Route("prestacao-de-contas")]
        public ActionResult PrestacaoDeContasDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Prestação de Contas - Fundo");
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