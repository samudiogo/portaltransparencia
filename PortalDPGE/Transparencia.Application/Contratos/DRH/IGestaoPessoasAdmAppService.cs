using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transparencia.Application.ViewModels.DRH;

namespace Transparencia.Application.Contratos.DRH
{
    public interface IGestaoPessoasAdmAppService
    {
        void SalvaListaEstagiarios(IEnumerable<EstagiariosViewModel> estagiarios);
        void SalvaListaResidentesJuridicos(IEnumerable<ResidentesJuridicosViewModel> residentes);
    }
}
