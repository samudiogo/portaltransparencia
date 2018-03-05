using System;

namespace Transparencia.Application.ViewModels.DRH
{
    public class ResidentesJuridicosViewModel
    {
        /// <summary>
        /// Nome do Residente Jurídico.
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// CPF do Residente Jurídico.
        /// </summary>
        public string CPF { get; set; }
        /// <summary>
        /// Lotação do Residente Jurídico.
        /// </summary>
        public string Lotacao { get; set; }
        /// <summary>
        /// Data de início de contrato do Residente Jurídico.
        /// </summary>
        public DateTime Inicio { get; set; }
        /// <summary>
        /// Previsão de término do Residente Jurídico.
        /// </summary>
        public DateTime PrevisaoDeTermino { get; set; }
        /// <summary>
        /// nº do consurso/ano do Residente Jurídico.
        /// </summary>
        public string Concurso { get; set; }
    }
}