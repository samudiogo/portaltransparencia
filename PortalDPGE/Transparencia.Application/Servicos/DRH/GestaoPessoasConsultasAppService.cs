using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Global.Dom.Util;
using Transparencia.Application.Contratos.DRH;
using Transparencia.Application.ViewModels.DRH;
using Transparencia.Dom.Servicos.DRH;


namespace Transparencia.Application.Servicos.DRH
{
    public class GestaoPessoasConsultasAppService : IGestaoPessoasConsultasAppService
    {
        private readonly IServicoServidores _servicoServidorAtivo;
        private readonly IServicoResidentesJuridicos _servicoResidentesJuridicos;
        private readonly IServicoEstagiarios _servicoEstagiarios;
        private readonly IMapper _mapper;

        public GestaoPessoasConsultasAppService(IServicoServidores servicoServidorAtivo,
            IMapper mapper,
            IServicoEstagiarios servicoEstagiarios,
            IServicoResidentesJuridicos servicoResidentesJuridicos)
        {
            _servicoServidorAtivo = servicoServidorAtivo;
            _mapper = mapper;
            _servicoEstagiarios = servicoEstagiarios;
            _servicoResidentesJuridicos = servicoResidentesJuridicos;
        }

        public async Task<IEnumerable<ServidorQuadroAtivoViewModel>> ListaServidorQuadroAtivoViewModelAsync()
        {
            var listaServidor = new List<ServidorQuadroAtivoViewModel>();

            await Task.Run(() => listaServidor =
                _mapper.Map<List<ServidorQuadroAtivoViewModel>>(_servicoServidorAtivo.ListaServidoresAtivos()));

            return listaServidor;
        }

        public async Task<IEnumerable<ServidorQuadroInativoViewModel>> ListaServidorQuadroInativoViewModelAsync()
        {
            var listaServidor = new List<ServidorQuadroInativoViewModel>();

            await Task.Run(() => listaServidor =
                _mapper.Map<List<ServidorQuadroInativoViewModel>>(_servicoServidorAtivo.ListaServidoresInativos()));

            return listaServidor;
        }

        public async Task<IEnumerable<CargosVagosEOcupadosViewModel>> ListaCargosVagosEOcupadosViewModelAsync()
        {
            var listaServidor = new List<CargosVagosEOcupadosViewModel>();

            await Task.Run(() => listaServidor =
                _mapper.Map<List<CargosVagosEOcupadosViewModel>>(_servicoServidorAtivo.ListaCargosVagosEOcupados()));

            return listaServidor;
        }

        public async Task<IEnumerable<AntiguidadeServidoresViewModel>> ListaAntiguidadeServidores()
        {
            var listaServidor = new List<AntiguidadeServidoresViewModel>();

            await Task.Run(() => listaServidor =
                _mapper.Map<List<AntiguidadeServidoresViewModel>>(_servicoServidorAtivo.ListaAntiguidadeServidores()));

            return listaServidor;
        }

        public async Task<IEnumerable<EstagiariosViewModel>> ListaEstagiariosViewModelAsync()
        {
            var listaEstagiarios = new List<EstagiariosViewModel>();

            await Task.Run(() =>
            {
                var listaDb = _servicoEstagiarios.ListarTodos();

                listaDb.AsParallel().ForAll(e => e.CPF = e.CPF.MascaraCpf());

                listaEstagiarios = _mapper.Map<List<EstagiariosViewModel>>(listaDb);
            });

            return listaEstagiarios;
        }

        public async Task<IEnumerable<ResidentesJuridicosViewModel>> ListaResidentesJuridicosViewModelAsync()
        {
            var listaResidentesJuridicos = new List<ResidentesJuridicosViewModel>();

            await Task.Run(() =>
            {
                var listaDb = _servicoResidentesJuridicos.ListarTodos();

                foreach (var item in listaDb)
                    item.CPF = item.CPF.MascaraCpf();

                listaResidentesJuridicos = _mapper.Map<List<ResidentesJuridicosViewModel>>(listaDb);
            });

            return listaResidentesJuridicos;
        }
    }
}