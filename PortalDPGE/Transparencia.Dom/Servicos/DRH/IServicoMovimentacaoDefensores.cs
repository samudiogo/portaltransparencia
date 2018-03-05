using Global.Dom.Entidade.PortalDPGE.Views;
using System.Collections.Generic;

namespace Transparencia.Dom.Servicos.DRH
{
    public interface IServicoMovimentacaoDefensores
    {
        IEnumerable<MovimentacaoDefensor> ListaMovimentacaoDefensores();
        IEnumerable<AntiguidadeDefensor> ListaAntiguidadeDefensores();

    }
}
