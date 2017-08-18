using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PortalDPGE.Transparencia.Web.Models;

namespace PortalDPGE.Transparencia.Web.Services
{
    public interface IGestaoPessoaApiService
    {

        Task<IEnumerable<DateTime>> ObterPeriodoQuadroServidorAsync(string situacao = "");
        Task<IEnumerable<ServidorAtivoViewModel>> ObterListaServidorAtivoPorPeriodoAsync(DateTime periodo);
        Task<IEnumerable<ServidorInativoViewModel>> ObterListaServidorInativoPorPeriodoAsync(DateTime periodo);
        Task<IEnumerable<ServidorCedidoParaDprjViewModel>> ObterListaServidorCedidoParaDprjPorPeriodoAsync(DateTime periodo);
        Task<IEnumerable<ServidorCedidoPelaDprjViewModel>> ObterListaServidorCedidoPelaDprjPorPeriodoAsync(DateTime periodo);

        Task<Dictionary<string, int>> ObterTotaisDeServidoresAtivos();



    }
}