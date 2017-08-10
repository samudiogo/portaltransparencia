
namespace PortalDPGE.Transparencia.Web.Models
{    
    public class CargoProvimentoEfetivoViewModel
    {
        public string Cargo { get; set; }
        public double Subsidio { get; set; }
    }
    public class FuncaoGratificadaViewModel
    {
        public string Funcao { get; set; }
        public double Valor { get; set; }
    }
    public class CargosVagosEOcupadosViewModel
    {
        public string Cargo { get; set; }
        public int Existentes { get; set; }
        public int Ocupados { get; set; }
        public int Vagos { get; set; }
    }
}