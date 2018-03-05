using Global.Dados.Persistencia;
using RHDP.Dados.Persistencia;
using RHDP.Dom.Regras;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Transparencia.Application.Contratos.DRH;

namespace Transparencia.API.Controllers
{
    [RoutePrefix("api/gestaopessoas")]
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GestaoPessoasController : ApiController
    {
        private readonly IGestaoPessoasConsultasAppService _service;

        private readonly IMovimentacaoDefensoresAppService _serviceMovimentacaoDefensores;


        public GestaoPessoasController(IGestaoPessoasConsultasAppService service,
            IMovimentacaoDefensoresAppService serviceMovimentacaoDefensores)
        {
            _service = service;
            _serviceMovimentacaoDefensores = serviceMovimentacaoDefensores;
        }

        [HttpGet]
        [Route("quadrocargo/totais-quadro-servidores-ativos")]
        public async Task<IHttpActionResult> ObterTotaisQuadroAtivo()
        {
            var result = (await _service.ListaServidorQuadroAtivoViewModelAsync()).Where(w => !string.IsNullOrEmpty(w.Categoria)).ToList();
            if (!result.Any()) return NotFound();

            var model = result.Select(s => s.Categoria).Distinct()
                .ToDictionary(k => k, v => result.Count(c => c.Categoria.Equals(v)));
            return Ok(model);

        }
        [HttpGet]
        [Route("quadrocargo/{situacao}")]
        public async Task<IHttpActionResult> ObterQuadroCargos(string situacao)
        {
            if (string.IsNullOrEmpty(situacao)) return BadRequest("Preencha todos os parâmetros");

            if (situacao.Equals("ativo", StringComparison.InvariantCultureIgnoreCase))
                return Ok(await _service.ListaServidorQuadroAtivoViewModelAsync());

            if (situacao.Equals("inativo", StringComparison.InvariantCultureIgnoreCase))
                return Ok(await _service.ListaServidorQuadroInativoViewModelAsync());

            return BadRequest("Situação inválida: use ativo ou inativo");
        }

        [HttpGet]
        [Route("antiguidade-servidores")]
        public async Task<IHttpActionResult> ObterListaAntiguidadeServidores()
        {
            return Ok(await Task.Run(() => _service.ListaAntiguidadeServidores()));
        }

        [HttpGet]
        [Route("quadro-cargos-vagos-e-ocupados")]
        public async Task<IHttpActionResult> ObterListaQuadroCargosVagosEOcupados()
        {
            var temp = new VagaRegras() { Servico = new VagaDados() }.ListarQuantidadeVagasPorCargo();

            return Ok(await Task.Run(() => _service.ListaCargosVagosEOcupadosViewModelAsync()));
        }

        #region Movimentação
        [HttpGet]
        [Route("antiguidade-defensores-publicos")]
        public async Task<IHttpActionResult> ObterListaAntiguidadeDefensores()
        {
            return Ok(await Task.Run(() => _serviceMovimentacaoDefensores.ListaAntiguidadeDefensores()));
        }

        [HttpGet]
        [Route("movimentacao-defensores-publicos")]
        public async Task<IHttpActionResult> ObterListaMovimentacaoDefensores()
        {
            return Ok(await Task.Run(() => _serviceMovimentacaoDefensores.ListaMovimentacaoDefensores()));
        }
        #endregion

        #region Estagio
        [HttpGet]
        [Route("estagiarios")]
        public async Task<IHttpActionResult> ObterListaEstagiarios()
        {
            return Ok(await Task.Run(() => _service.ListaEstagiariosViewModelAsync()));
        }
        [HttpGet]
        [Route("residentes-juridicos")]
        public async Task<IHttpActionResult> ObterListaResidentesJuridicos()
        {
            return Ok(await Task.Run(() => _service.ListaResidentesJuridicosViewModelAsync()));
        }
        #endregion

    }
}