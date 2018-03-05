using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using Transparencia.Infra.CrossCutting.IoC.Modulos;

namespace Transparencia.Infra.CrossCutting.IoC
{
    public class IoC
    {
        public IKernel Kernel { get; }

        public IoC()
        {
            Kernel = GetNinjectModules();
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(Kernel));
        }

        private static StandardKernel GetNinjectModules() => new StandardKernel(new TransparenciaApplicationNinjectModule(),
            new TransparenciaServicoNinjectModule());

    }
}