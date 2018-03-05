using Global.Dom.Util;
using MvcPaging;
using PortalDPGE.Dados.Persistencia;
using PortalDPGE.Dom.Regras;
using PortalDPGE.Dom.Util;
using PortalDPGE.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace Transparencia.Web.Controllers
{
    public class PortalController : Controller
    {
        private readonly int _pageSize = int.Parse(DicionarioPortalDPGE.PaginacaoPadrao);

        // GET: Portal
        public ActionResult Index()
        {
            return View();
        }
        #region BuscaGeral

        /// <summary>
        /// Página de resultado de busca:
        /// </summary>
        /// <param name="palavrachave">palavra ou frase digitada pelo usuario para efetuar uma busca</param>
        /// <param name="tipo"></param>
        /// <param name="page"></param>
        /// <returns>Retorna todos os conteúdos e notícias que contenha a palavra ou frase digitada pelo usuário</returns>
        /// GET: Busca/{texto}
        public ActionResult BuscaGeral(string palavrachave, string tipo, int? page)
        {
            palavrachave = palavrachave/*.RemoveAcentos()*/.ConverteDuploEspaco() ?? string.Empty;

            tipo = tipo ?? string.Empty;

            var isCompleta = tipo.Equals("completa");

            var resultadoIsCompleta = false;

            var dbPaginasList = new PaginaRegras { Servico = new PaginaDados() }.BuscaPaginaList(out resultadoIsCompleta,
                palavrachave, isCompleta);

            var modelList = dbPaginasList.ToList().Select(pagina => new PaginaViewModel().PrepareModel(pagina));

            var paginaAtual = page - 1 ?? 0;
            ViewBag.ResultadoIsCompleta = resultadoIsCompleta;
            ViewBag.Palavra = palavrachave;
            ViewBag.tipo = tipo; //tipo de busca, simples ou completa
            return View("BuscaGeral", modelList.ToPagedList(paginaAtual, _pageSize));
        }
        #endregion

        public ActionResult DescreveAcessibilidade()
        {
            return View();
        }

        public ActionResult PerguntasFrequentes()
        {
            return View();
        }
    }
}