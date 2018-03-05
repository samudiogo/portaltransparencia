using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Transparencia.Web.Models
{
    public class LicitacaoViewModel
    {
        public int Id { get; set; }
        [Display(Name = @"Tipo:")]
        public string Tipo { get; set; }
        [DataType(DataType.Html)]
        [Display(Name = @"Objeto:")]
        public string Descricao { get; set; }
        [Display(Name = @"Nº Licitação:")]
        public string CodigoLicitacao { get; set; }
        [Display(Name = @"Nº Processo:")]
        public string CodigoProcesso { get; set; }
        [Display(Name = @"Local:")]
        public string Local { get; set; }
        [Display(Name = @"Empresa vencedora:")]
        public string EmpresaVencedora { get; set; }
        public string Modalidade { get; set; }
        [Display(Name = @"Situação:")]
        public string Situacao { get; set; }
        public List<LicitacaoDocumento> ListaDocumentos { get; set; }
        [Display(Name = @"Data Abertura:")]
        public DateTime? DataAbertura { get; set; }
        [Display(Name = @"Data Realização:")]
        public DateTime? DataRealizacao { get; set; }
        [Display(Name = @"Valor estimado:")]
        [DataType(DataType.Currency)]
        public decimal ValorEstimativa { get; set; }
        [Display(Name = @"Valor Final:")]
        [DataType(DataType.Currency)]
        public decimal ValorFinal { get; set; }
        [Display(Name = "Publicação do Aviso:")]
        public DateTime? DataPublicacaoAviso { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Observações:")]
        public string Observacao { get; set; }

    }

    public class FiltroLicitacaoViewModel
    {
        [Display(Name = @"Situação:")]
        public int IdFiltro { get; set; }
        public List<SelectListItem> ListaFiltro
        {
            get
            {
                List<SelectListItem> lista = new List<SelectListItem>();

                SelectListItem item0 = new SelectListItem();
                item0.Value = "0";
                item0.Text = "Todas";
                lista.Add(item0);

                SelectListItem item1 = new SelectListItem();
                item1.Value = "1";
                item1.Text = "Abertas";
                lista.Add(item1);

                SelectListItem item2 = new SelectListItem();
                item2.Value = "2";
                item2.Text = "Em Andamento";
                lista.Add(item2);

                SelectListItem item3 = new SelectListItem();
                item3.Value = "3";
                item3.Text = "Finalizadas";
                lista.Add(item3);

                SelectListItem item4 = new SelectListItem();
                item4.Value = "4";
                item4.Text = "Frustradas";
                lista.Add(item4);

                SelectListItem item5 = new SelectListItem();
                item5.Value = "5";
                item5.Text = "Pendentes";
                lista.Add(item5);

                return lista;
            }
        }
    }

    public class LicitacaoDocumento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Url { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime? DataInclusao { get; set; }
    }
}
