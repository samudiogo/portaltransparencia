using System.ComponentModel;

namespace Transparencia.Application.ViewModels.DRH
{
    public class AntiguidadeDefensorViewModel
    {
        public int PeriodoPosse { get; set; }
        [DisplayName(@"Código")]
        public string SiglaCargo { get; set; }
        [DisplayName(@"xxx")]
        public string NomeCargo { get; set; }
        [DisplayName(@"Ordem")]
        public int Ordem { get; set; }
        [DisplayName(@"Nome")]
        public string NomeDefensor { get; set; }
        [DisplayName(@"Classe")]
        public string PeriodoClasse { get; set; }
        [DisplayName(@"Carreira")]
        public string PeriodoCarreira { get; set; }
        [DisplayName(@"Estado")]
        public string PeriodoEstado { get; set; }
        [DisplayName(@"S.Público")]
        public string PeriodoServicoPublico { get; set; }
        [DisplayName(@"Aposentação")]
        public string PeriodoAposentacao { get; set; }
    }
}