using System;
using System.ComponentModel.DataAnnotations;

namespace Transparencia.Application.ViewModels.DRH
{
    public class AntiguidadeServidoresViewModel
    {
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Código do cargo")]
        public string CodigoCargo { get; set; }
        [Display(Name = "cargo Efetivo")]
        public string Cargo { get; set; }
        [Display(Name = "Ordem da Antiguidade")]
        public int OrdemAntiguidade { get; set; }
        [Display(Name = "Posse/Exercício")]
        public DateTime PosseExercicio { get; set; }
    }
}