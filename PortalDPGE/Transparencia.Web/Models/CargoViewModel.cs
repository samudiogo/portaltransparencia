
using System.Collections.Generic;

namespace Transparencia.Web.Models
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
        public class CargosVagosEOcupadosViewModelData
        {
            public string Cargo { get; set; }
            public int Total { get; set; }
            public int Ocupados { get; set; }
            public int Vagos { get; set; }

        }

        public List<CargosVagosEOcupadosViewModelData> Data { get; set; }

    }


}