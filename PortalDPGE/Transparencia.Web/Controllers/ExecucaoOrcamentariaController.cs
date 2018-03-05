using Global.Dom.Entidade.PortalDPGE;
using PortalDPGE.Dados.Persistencia;
using PortalDPGE.Dom.Regras;
using PortalDPGE.Dom.Util;
using PortalDPGE.Restrito.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace Transparencia.Web.Controllers
{
    [RoutePrefix("execucao-orcamentaria")]
    public class ExecucaoOrcamentariaController : Controller
    {
        [Route("index")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("receitas")]
        public ActionResult DemonstrativoReceitasDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Demonstrativo de Receita");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }
        [Route("execucao-orcamentaria")]
        public ActionResult ExecucaoOrcamentariaDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Execução Orçamentária");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }
        [Route("diarias")]
        public ActionResult DiariasDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Diárias");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }
        [Route("passagens-aereas")]
        public ActionResult PassagensAereasDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Passagens Aéreas");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }
        [Route("auxilio-livro")]
        public ActionResult AuxilioLivroDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Auxílio Livro");
            model.Link = DicionarioPortalDPGE.uploadsArquivos;

            return View("PastaDocumentos", model);
        }
        [Route("telefonia-e-internet-movel")]
        public ActionResult TelefoniaEInternetMovelDocumentos()
        {
            var model = new DocumentoModel();
            model.Documentos = DocumentosPorTipo("Telefonia e Internet Móvel");
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