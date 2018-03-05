using Global.Dados.Persistencia;
using Global.Dom.Servico;
using Ninject.Modules;
using Transparencia.Dados.Persistencia.DRH;
using Transparencia.Dom.Servicos.DRH;

namespace Transparencia.Infra.CrossCutting.IoC.Modulos
{
    public class TransparenciaServicoNinjectModule : NinjectModule
    {
        #region Overrides of NinjectModule

        public override void Load()
        {
            Bind(typeof(IServicoBase<,>)).To(typeof(GenericoDados<,>));

            Bind<IServicoServidores>().To<ServidorDados>();
            Bind<IServicoMovimentacaoDefensores>().To<MovimentacaoDefensores>();
            Bind<IServicoEstagiarios>().To<EstagiariosDados>();
            Bind<IServicoResidentesJuridicos>().To<ResidentesJuridicosDados>();
            
        }

        #endregion
    }
}
