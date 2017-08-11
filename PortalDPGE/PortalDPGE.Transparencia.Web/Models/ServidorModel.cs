
using System;
using System.ComponentModel.DataAnnotations;

namespace PortalDPGE.Transparencia.Web.Models
{
    public class ServidorAtivoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Matrícula")]
        public string Matricula { get; set; }
        public string Cargo { get; set; }
        [Display(Name = "Função")]
        public string Funcao { get; set; }
        [Display(Name = "Lotação")]
        public string Lotacao { get; set; }
        [Display(Name = "Nomeação")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime Nomeacao { get; set; }
        [Display(Name = "Estável")]
        public string Estavel { get; set; }
        public int Antiguidade { get; set; }
        public DateTime Periodo { get; set; }
        
        
    }
    
    public class ServidorInativoViewModel
    {
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string CargoEfetivo { get; set; }
        public string AtoPortariaNomeacao { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime DataPublicacaoNomeacao { get; set; }
        public string AtoPortariaAposentadoria { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime DataPublicacaoAposentadoria { get; set; }
    }

    public class ServidorCedidoParaDprjViewModel
    {
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string CargoDeOrigem { get; set; }
        public string CargoAtual { get; set; }
        public string Funcao { get; set; }
        public string Lotacao { get; set; }
        public string AtoPortariaCessao { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime DataPublicacaoCessao { get; set; }
        public string OrgaoDestino { get; set; }
    }

    public class ServidorCedidoPelaDprjViewModel
    {
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Funcao { get; set; }
        public string Lotacao { get; set; }
        public string AtoPortariaCessao { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime DataPublicacaoCessao { get; set; }
        public string OrgaoDestino { get; set; }
        public string Onus { get; set; }
    }

    public class PensionistaViewModel
    {
        public string InstituidorPensao { get; set; }
        public string CargoEfetivo { get; set; }
        public string Pensionista { get; set; }
        public string AtoPortariaConcessaoDaPensao { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime DataPublicacaoConcessaoDaPensao { get; set; }
    }
}