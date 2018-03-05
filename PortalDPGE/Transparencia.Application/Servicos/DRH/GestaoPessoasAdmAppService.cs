using AutoMapper;
using Global.Dom.Entidade.Transparencia.DRH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Transparencia.Application.Contratos.DRH;
using Transparencia.Application.ViewModels.DRH;
using Transparencia.Dom.Servicos.DRH;

namespace Transparencia.Application.Servicos.DRH
{
    public class GestaoPessoasAdmAppService : IGestaoPessoasAdmAppService
    {
        private readonly IServicoEstagiarios _servicoEstagiarios;
        private readonly IServicoResidentesJuridicos _servicoResidentesJuridicos;
        private readonly IMapper _mapper;

        public GestaoPessoasAdmAppService(IServicoEstagiarios servicoEst,
            IServicoResidentesJuridicos servicoResidentesJuridicos,
            IMapper mapper)
        {
            _servicoEstagiarios = servicoEst;
            _servicoResidentesJuridicos = servicoResidentesJuridicos;
            _mapper = mapper;
        }

        public void SalvaListaEstagiarios(IEnumerable<EstagiariosViewModel> estagiariosViewModel)
        {
            var sessao = _servicoEstagiarios.AbrirSessao();
            var trans = _servicoEstagiarios.AbrirTransacao(sessao);
            try
            {
                var estagiarios = _mapper.Map<IEnumerable<Estagiarios>>(estagiariosViewModel);
                var agora = DateTime.Now;
                var listaDb = _servicoEstagiarios.ListarTodos();
                if (listaDb.Any())
                    foreach (var item in listaDb)
                        _servicoEstagiarios.Excluir(sessao, item);

                
                foreach (var est in estagiarios)
                {
                    //TODO: aplicar regras das história de usuário 
                    est.UltimaAtualizacao = agora;
                    est.CPF = Regex.Replace(est.CPF, @"[^\d]", "");
                    _servicoEstagiarios.Inserir(sessao, est);
                }

                _servicoEstagiarios.CommitarTransacao(trans);
            }
            catch (Exception e)
            {
                _servicoEstagiarios.Rollback(trans);
                throw new Exception(e.Message);
            }
            finally
            {
                _servicoEstagiarios.FecharSessao(sessao);
            }
        }

        public void SalvaListaResidentesJuridicos(IEnumerable<ResidentesJuridicosViewModel> residentesViewModel)
        {
            var sessao = _servicoResidentesJuridicos.AbrirSessao();
            var trans = _servicoResidentesJuridicos.AbrirTransacao(sessao);
            try
            {
                var residentes = _mapper.Map<IEnumerable<ResidentesJuridicos>>(residentesViewModel);
                var agora = DateTime.Now;
                var listaDb = _servicoResidentesJuridicos.ListarTodos();
                if (listaDb.Any())
                    foreach (var item in listaDb)
                        _servicoResidentesJuridicos.Excluir(sessao, item);


                foreach (var res in residentes)
                {
                    //TODO: aplicar regras das história de usuário 
                    res.UltimaAtualizacao = agora;
                    res.CPF = Regex.Replace(res.CPF, @"[^\d]", "");
                    _servicoResidentesJuridicos.Inserir(sessao, res);
                }

                _servicoResidentesJuridicos.CommitarTransacao(trans);
            }
            catch (Exception e)
            {
                _servicoResidentesJuridicos.Rollback(trans);
                throw new Exception(e.Message);
            }
            finally
            {
                _servicoResidentesJuridicos.FecharSessao(sessao);
            }
        }
    }
}
