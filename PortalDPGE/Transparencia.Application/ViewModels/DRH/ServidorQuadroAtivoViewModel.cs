using System;
namespace Transparencia.Application.ViewModels.DRH
{

    public class ServidorQuadroAtivoViewModel
    {
        /// <summary>
        /// Nome do Servidor.
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Matrícula do Servidor.
        /// </summary>
        public string Matricula { get; set; }

        public string Categoria { get; set; }

        /// <summary>
        /// Cargo do Servidor.
        /// </summary>
        public string CargoEfetivo { get; set; }
        /// <summary>
        /// Função do Servidor.
        /// </summary>
        public string CargoEmComissao { get; set; }
        /// <summary>
        /// Lotação do Servidor.
        /// </summary>
        public string LotacaoAtual { get; set; }
        /// <summary>
        /// Data de Nomeação do servidor.
        /// </summary>
        public DateTime Nomeacao { get; set; }

        public DateTime Exercicio { get; set; }
        /// <summary>
        /// Verificação de Estabilidade do Servidor (Estável: "SIM" ou "NÃO").
        /// </summary>
        public string Estavel { get; set; }
    }

    public class TotalServidorQuadroAtivoViewModel
    {
        public string Descricao { get; set; }
        public int Total { get; set; }
    }
}