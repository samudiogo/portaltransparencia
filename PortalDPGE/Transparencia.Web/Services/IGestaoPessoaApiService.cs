using Global.Dom.Entidade.PortalDPGE.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Transparencia.Web.Models;

namespace Transparencia.Web.Services
{
    public interface IGestaoPessoaApiService
    {

        Task<IEnumerable<DateTime>> ObterPeriodoQuadroServidorAsync(string situacao = "");
        Task<IEnumerable<ServidorAtivoViewModel>> ObterListaServidorAtivoPorPeriodoAsync(DateTime periodo);
        Task<IEnumerable<ServidorInativoViewModel>> ObterListaServidorInativoPorPeriodoAsync(DateTime periodo);
        Task<IEnumerable<ServidorCedidoParaDprjViewModel>> ObterListaServidorCedidoParaDprjPorPeriodoAsync(DateTime periodo);
        Task<IEnumerable<ServidorCedidoPelaDprjViewModel>> ObterListaServidorCedidoPelaDprjPorPeriodoAsync(DateTime periodo);
        Task<Dictionary<string, int>> ObterTotaisDeServidoresAtivos();

        Task<IEnumerable<AntiguidadeDefensor>> ObterListaAntiguidadeDefensoresAsync();
        Task<IEnumerable<MovimentacaoDefensor>> ObterListaMovimentacaoDefensoresAsync();
    }
}