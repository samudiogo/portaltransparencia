using System.Collections.Generic;
using Global.Dom.Entidade.PortalDPGE.Views;
using Transparencia.Application.Contratos.DRH;
using Transparencia.Dom.Servicos.DRH;

namespace Transparencia.Application.Servicos.DRH
{
    public class MovimentacaoDefensoresAppService : IMovimentacaoDefensoresAppService
    {
        private readonly IServicoMovimentacaoDefensores _servico;

        public MovimentacaoDefensoresAppService(IServicoMovimentacaoDefensores servico)
        {
            _servico = servico;
        }

        public IEnumerable<AntiguidadeDefensor> ListaAntiguidadeDefensores()
        {
            return _servico.ListaAntiguidadeDefensores();
        }

        public IEnumerable<MovimentacaoDefensor> ListaMovimentacaoDefensores()
        {
            return _servico.ListaMovimentacaoDefensores();
        }
    }
}
