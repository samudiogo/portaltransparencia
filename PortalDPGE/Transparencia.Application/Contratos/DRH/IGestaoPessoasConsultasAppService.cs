using System.Collections.Generic;
using System.Threading.Tasks;
using Transparencia.Application.ViewModels.DRH;

namespace Transparencia.Application.Contratos.DRH
{
    public interface IGestaoPessoasConsultasAppService
    {
        Task<IEnumerable<ServidorQuadroAtivoViewModel>> ListaServidorQuadroAtivoViewModelAsync();
        Task<IEnumerable<ServidorQuadroInativoViewModel>> ListaServidorQuadroInativoViewModelAsync();
        Task<IEnumerable<CargosVagosEOcupadosViewModel>> ListaCargosVagosEOcupadosViewModelAsync();
        Task<IEnumerable<AntiguidadeServidoresViewModel>> ListaAntiguidadeServidores();

        Task<IEnumerable<EstagiariosViewModel>> ListaEstagiariosViewModelAsync();
        Task<IEnumerable<ResidentesJuridicosViewModel>> ListaResidentesJuridicosViewModelAsync();

    }
}