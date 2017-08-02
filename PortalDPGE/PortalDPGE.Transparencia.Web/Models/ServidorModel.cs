
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
        public DateTime Nomeacao { get; set; }
        [Display(Name = "Estável")]
        public string Estavel { get; set; }
        public int Antiguidade { get; set; }
    }
}