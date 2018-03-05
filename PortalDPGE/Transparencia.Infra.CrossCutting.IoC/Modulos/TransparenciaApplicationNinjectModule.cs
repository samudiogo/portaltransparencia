using AutoMapper;
using Ninject;
using Ninject.Modules;
using Transparencia.Application.AutoMapper;
using Transparencia.Application.Contratos.DRH;
using Transparencia.Application.Servicos.DRH;

namespace Transparencia.Infra.CrossCutting.IoC.Modulos
{
    public class TransparenciaApplicationNinjectModule : NinjectModule
    {
        #region Overrides of NinjectModule

        public override void Load()
        {
            Bind<IMapper>().ToMethod(contexto =>
            {
                var configuracao = new MapperConfiguration(mapperConfig =>
                {
                    mapperConfig.AddProfile<AutoMapperProfile>();
                    mapperConfig.ConstructServicesUsing(t => Kernel?.Get(t));
                });
                return configuracao.CreateMapper();
            }).InSingletonScope();

            Bind<IGestaoPessoasAdmAppService>().To<GestaoPessoasAdmAppService>();

            //Consultas Públicas
            Bind<IGestaoPessoasConsultasAppService>().To<GestaoPessoasConsultasAppService>();
            Bind<IMovimentacaoDefensoresAppService>().To<MovimentacaoDefensoresAppService>();
            
        }

        #endregion
    }
}