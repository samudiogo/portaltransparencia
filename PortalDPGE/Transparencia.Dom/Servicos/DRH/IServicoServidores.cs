using System.Collections.Generic;
using Global.Dom.Entidade.Transparencia.DRH;


namespace Transparencia.Dom.Servicos.DRH
{
    public interface IServicoServidores
    {
        IEnumerable<ServidorAtivo> ListaServidoresAtivos();
        IEnumerable<ServidorInativo> ListaServidoresInativos();
        IEnumerable<CargosVagosEOcupados> ListaCargosVagosEOcupados();
        IEnumerable<AntiguidadeServidores> ListaAntiguidadeServidores();
    }
}
