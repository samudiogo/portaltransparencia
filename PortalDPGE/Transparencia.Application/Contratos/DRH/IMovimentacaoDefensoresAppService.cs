using Global.Dom.Entidade.PortalDPGE.Views;
using System.Collections.Generic;

namespace Transparencia.Application.Contratos.DRH
{
    public interface IMovimentacaoDefensoresAppService
    {
        IEnumerable<MovimentacaoDefensor> ListaMovimentacaoDefensores();
        IEnumerable<AntiguidadeDefensor> ListaAntiguidadeDefensores();
    }
}
