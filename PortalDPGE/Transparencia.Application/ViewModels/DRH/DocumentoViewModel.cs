using System;
using System.Collections.Generic;

namespace Transparencia.Application.ViewModels.DRH
{

    public class DocumentoViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string DocumentoUrl { get; set; }
        public DateTime DataPublicacao { get; set; }
    }

    public class DocumentoCidadaoAtendimentoViewModel
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public IEnumerable<DocumentoItemViewModel> ListaDocumentoItems { get; set; }
    }

    public class DocumentoItemViewModel
    {

        public string Titulo { get; set; }
        public string Link { get; set; }
    }

    public class DocumentoLegislacaoViewModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Link { get; set; }
    }

    public class DocumentoMovimentacaoViewModel
    {
        public string Id { get; set; }
        public DateTime Mes { get; set; }
        public IEnumerable<DocumentoItemViewModel> ListaDocumentoItems { get; set; }
    }
}