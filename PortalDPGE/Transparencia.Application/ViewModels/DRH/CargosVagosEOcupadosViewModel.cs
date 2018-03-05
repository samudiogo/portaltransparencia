using System;

namespace Transparencia.Application.ViewModels.DRH
{
    public class CargosVagosEOcupadosViewModel
    {
        /// <summary>
        /// Código do Cargo.
        /// </summary>
        public string CodigoCargo { get; set; }
        /// <summary>
        /// Nome do Cargo.
        /// </summary>
        public string Cargo { get; set; }
        /// <summary>
        /// Total de Cargos existentes;
        /// </summary>
        public int Existentes { get; set; }
        /// <summary>
        /// Número de Cargos ocupados.
        /// </summary>
        public int Ocupados { get; set; }
        /// <summary>
        /// Número de Cargos vagos.
        /// </summary>
        public int Vagos { get; set; }
    }
}