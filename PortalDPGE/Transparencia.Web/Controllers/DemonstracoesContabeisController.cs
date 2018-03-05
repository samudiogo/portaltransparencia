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
    [RoutePrefix("demonstracoes-contabeis")]
    public class DemonstracoesContabeisController : Controller
    {
        [Route("balanco-patrimonial")]
        public ActionResult BalancoPatrimonialDocumentos()
        {
            var model = new DocumentoModelLista();

            var tipos = new[] { "Defensoria Pública - BP", "FUNDPERJ - BP" };

            foreach (var item in tipos)
            {
                var doc = new DocumentoModel();
                doc.Documentos = DocumentosPorTipo(item);
                doc.Link = DicionarioPortalDPGE.uploadsArquivos;
                model.TiposDocumentos.Add(doc);
            }

            return View( model);
        }

        [Route("balanco-orcamentario")]
        public ActionResult BalancoOrcamentarioDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Balanço Orçamentário");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }
        [Route("balanco-financeiro")]
        public ActionResult BalancoFinanceiroDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Balanço Financeiro");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }
        [Route("demonstracao-das-variacoes-patrimoniais")]
        public ActionResult DemontracaoDasVariacoesPatrimoniaisDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Demonstração das Variações Patrimoniais");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }
        [Route("demonstracao-dos-fluxos-de-caixa")]
        public ActionResult DemonstracaoDosFluxosDeCaixaDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Demonstração dos Fluxos de Caixa");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }
        [Route("demonstracoes-das-mutacoes-do-patrimonio-liquido")]
        public ActionResult DemonstracoesDasMutacoesDoPatrimonioLiquidoDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Demonstrações das Mutações do Patrimônio Líquido");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }

        [Route("balanco")]
        public ActionResult Balanco()
        {
            var model = new DocumentoModelLista();

            var tipos = new[] { "Defensoria Pública", "FUNDPERJ" };

            foreach (var item in tipos)
            {
                var doc = new DocumentoModel();
                doc.Documentos = DocumentosPorTipo(item);
                doc.Link = DicionarioPortalDPGE.uploadsArquivos;
                model.TiposDocumentos.Add(doc);
            }

            return View("PastaListaDocumentos", model);
        }

        protected static TipoDocumento DocumentosPorTipo(string NomeTipo)
        {
            var regras = new TipoDocumentoRegras { Servico = new TipoDocumentoDados() };
            return regras.MontaHierarquiaTipoTransparencia(regras.ObterPorNomeIgualSemPai(NomeTipo)).FirstOrDefault();
        }
    }
}