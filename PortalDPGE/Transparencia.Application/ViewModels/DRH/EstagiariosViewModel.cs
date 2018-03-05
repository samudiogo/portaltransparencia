using System;

namespace Transparencia.Application.ViewModels.DRH
{
    public class EstagiariosViewModel
    {
        /// <summary>
        /// Nome do Estagiário.
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// CPF do Estagiário.
        /// </summary>
        public string CPF { get; set; }
        /// <summary>
        /// Lotação do Estagiário.
        /// </summary>
        public string Lotacao { get; set; }
        /// <summary>
        /// Nível do Estagiário.
        /// </summary>
        public string Nivel { get; set; }
        /// <summary>
        /// Especialidade do Estagiário.
        /// </summary>
        public string Especialidade { get; set; }
        /// <summary>
        /// Entidade de ensino do Estagiário.
        /// </summary>
        public string EntidadeDeEnsino { get; set; }
        /// <summary>
        /// Data de início do contrato do Estagiário.
        /// </summary>
        public DateTime InicioDoContrato { get; set; }
        /// <summary>
        /// Data de previsão do término do contrato do Estagiário.
        /// </summary>
        public DateTime PrevisaoDeTermino { get; set; }
    }
}