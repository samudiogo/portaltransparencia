
using System;
using System.ComponentModel.DataAnnotations;

namespace PortalDPGE.Transparencia.Web.Models
{
    public class ServidorModel
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
        public string Situacao { get; set; }
    }
    public class ServidorAtivoViewModel
    {
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string CargoEfetivo { get; set; }
        public string Funcao { get; set; }
        public string Lotacao { get; set; }
        public string AtoPortaria { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Vitalicio { get; set; }
    }
    public class ServidorCedidoParaMPViewModel
    {
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string CargoDeOrigem { get; set; }
        public string CargoAtual { get; set; }
        public string Funcao { get; set; }
        public string Lotacao { get; set; }
        public string AtoPortariaCessao { get; set; }
        public DateTime DataPublicacaoCessao { get; set; }
        public string OrgaoDestino { get; set; }
    }
    public class ServidorCedidoPeloMPViewModel
    {
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Funcao { get; set; }
        public string Lotacao { get; set; }
        public string AtoPortariaCessao { get; set; }
        public DateTime DataPublicacaoCessao { get; set; }
        public string OrgaoDestino { get; set; }
        public string Onus { get; set; }
    }
    public class ServidorInativoViewModel
    {
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string CargoEfetivo { get; set; }
        public string AtoPortariaNomeacao { get; set; }
        public DateTime DataPublicacaoNomeacao { get; set; }
        public string AtoPortariaAposentadoria { get; set; }
        public DateTime DataPublicacaoAposentadoria { get; set; }
    }
    public class PensionistaViewModel
    {
        public string InstituidorPensao { get; set; }
        public string CargoEfetivo { get; set; }
        public string Pensionista { get; set; }
        public string AtoPortariaConcessaoDaPensao { get; set; }
        public DateTime DataPublicacaoConcessaoDaPensao { get; set; }
        }
}