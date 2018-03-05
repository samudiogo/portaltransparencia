using System;

namespace Transparencia.Application.ViewModels.DRH
{
    public class ServidorQuadroInativoViewModel
    {
        /// <summary>
        /// Nome do Servidor.
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Matrícula do Servidor.
        /// </summary>
        public string Matricula { get; set; }
        /// <summary>
        /// Cargo do Servidor.
        /// </summary>
        public string CargoEfetivo { get; set; }
  
        /// <summary>
        /// Ato de aposentadoria do Servidor.
        /// </summary>
        public DateTime Aposentadoria { get; set; }

    }
}
