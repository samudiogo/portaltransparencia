using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PortalDPGE.Transparencia.Web.Models;

namespace PortalDPGE.Transparencia.Web.Services
{
    public interface IGestaoPessoaApiService
    {

        Task<IEnumerable<DateTime>> ObterPeriodoQuadroServidorAsync(string situacao = "");

        Task<IEnumerable<ServidorModel>> ObterListaServidorPorSituaoPeriodoAsync(string situacao, DateTime periodo);

    }
}