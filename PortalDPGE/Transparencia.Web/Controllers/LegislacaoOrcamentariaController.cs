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
    [RoutePrefix("legislacoes-orcamentarias")]
    public class LegislacaoOrcamentariaController : Controller
    {
        [Route("ppa")]
        public ActionResult DemonstrativoReceitasDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("PPA");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }
        [Route("ldo")]
        public ActionResult ExecucaoOrcamentariaDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("LDO");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }
        [Route("loa")]
        public ActionResult DiariasDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("LOA");
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