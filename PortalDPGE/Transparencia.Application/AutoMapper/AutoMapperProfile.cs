using AutoMapper;
using Global.Dom.Entidade.PortalDPGE;
using Global.Dom.Entidade.Transparencia.DRH;
using Transparencia.Application.FileHelperMappings;
using Transparencia.Application.ViewModels.DRH;
using Transparencia.Application.ViewModels.Portal;

namespace Transparencia.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Mapeamento de domínio para ViewModel
            CreateMap<ServidorAtivo, ServidorQuadroAtivoViewModel>()
                .ForAllMembers(opt => opt.AllowNull());
            CreateMap<ServidorInativo, ServidorQuadroInativoViewModel>()
                .ForAllMembers(opt => opt.AllowNull());
            CreateMap<AntiguidadeServidores, AntiguidadeServidoresViewModel>()
                .ForAllMembers(opt => opt.AllowNull());
            CreateMap<CargosVagosEOcupados, CargosVagosEOcupadosViewModel>();
            CreateMap<Estagiarios, EstagiariosViewModel>();
            CreateMap<ResidentesJuridicos, ResidentesJuridicosViewModel>();

            CreateMap<Conteudo, ConteudoConsultaViewModel>();

            //Mapeamento de ViewModel para domínio
            CreateMap<ServidorQuadroAtivoViewModel, ServidorAtivo>();
            CreateMap<ServidorQuadroInativoViewModel, ServidorInativo>();
            CreateMap<CargosVagosEOcupadosViewModel, CargosVagosEOcupados>();
            CreateMap<EstagiariosViewModel, Estagiarios>();
            CreateMap<ResidentesJuridicosViewModel, ResidentesJuridicos>();


            CreateMap<ConteudoConsultaViewModel, Conteudo>();
            //Outros
            CreateMap<ServidorQuadroAtivoFileMap, ServidorQuadroAtivoViewModel>().ReverseMap();
            CreateMap<ServidorQuadroInativoFileMap, ServidorQuadroInativoViewModel>().ReverseMap();
            CreateMap<CargosVagosEOcupadosFileMap, CargosVagosEOcupadosViewModel>().ReverseMap();
            CreateMap<EstagiariosFileMap, EstagiariosViewModel>().ReverseMap();
            CreateMap<ResidentesJuridicosFileMap, ResidentesJuridicosViewModel>().ReverseMap();
        }
    }
}