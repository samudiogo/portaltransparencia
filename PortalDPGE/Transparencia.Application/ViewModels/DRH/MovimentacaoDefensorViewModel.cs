using System;
using System.ComponentModel.DataAnnotations;

namespace Transparencia.Application.ViewModels.DRH
{
    public class MovimentacaoDefensorViewModel
    {
        public int Id { get; set; }
        public string Ano { get; set; }

        public string Mes { get; set; }
        [DataType(DataType.Url)]
        public string UrlMapa { get; set; }
        [DataType(DataType.Url)]
        public string PlantaoDiurno { get; set; }
        [DataType(DataType.Url)]
        public string PlantaoNoturno { get; set; }
        [DataType(DataType.Url)]
        public string JusticaItinerante { get; set; }
        [DataType(DataType.Url)]
        public string PlantaoFeriado { get; set; }

    }
    public class MovimentacaoDocumentoViewModel
    {
        public int Id { get; set; }
        public DateTime DataPublicacao { get; set; }

        public string NomeArquivo { get; set; }
        [DataType(DataType.Url)]
        public string Url { get; set; }
    }
}