using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using static RHDP.Dom.Modelo.QuantitativoVagasCargos;

namespace Transparencia.Web.Models
{
    public class ServidorAtivoViewModel
    {
        public ServidorAtivoViewModel(Hashtable dados)
        {
            /*
                 .Add(Projections.Property(() => rfAlias.Id), "idRegistroFuncional")
                      .Add(Projections.Property(() => rfAlias.Matricula), "rf_matricula")
                      .Add(Projections.Property(() => rfAlias.DataPosse), "rf_dataPosse")
                      .Add(Projections.Property(() => rfAlias.DataNomeacao), "rf_dataNomeacao")
                      .Add(Projections.Property(() => ((RegistroServidor)rfAlias).FlagAprovadoEstagioProbatorio), "rs_AprovadoEstagio")
                      .Add(Projections.Property(() => pAlias.Nome), "Pessoa_Nome")                      
                      .Add(Projections.Property(() => orgAlias.NomeDpge), "Lotacao_Orgao_nome")
                      .Add(Projections.Property(() => cgAlias.Nome), "cargo")
                      .Add(Projections.Property(() => tlotAlias.Nome), "tipo_lotacao")
             */
            Nome = (string)dados["Pessoa_Nome"];
            Matricula = (string)dados["rf_matricula"];

            LotacaoAtual = (string)dados["Lotacao_Orgao_nome"];

            CargoEfetivo = dados["CargoEfetivo"] != null ? (string)dados["CargoEfetivo"] : "";
            CargoEmComissao = dados["CargoEmComissao"] != null ? (string)dados["CargoEmComissao"] : "";

            Nomeacao = dados["rf_dataNomeacao"] != null ? (DateTime?)dados["rf_dataNomeacao"] : null;
            Exercicio = dados["rf_dataPosse"] != null ? (DateTime?)dados["rf_dataPosse"] : null;
            //Lotacao = (string)dados["Lotacao_Orgao_nome"];

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Matrícula")]
        public string Matricula { get; set; }
        public string CargoEfetivo { get; set; }


        [Display(Name = "Lotação")]
        public string LotacaoAtual { get; set; }

        [Display(Name = "Nomeação")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime? Nomeacao { get; set; }

        [Display(Name = "Estável")]
        public string Estavel { get; set; }
        public DateTime? Exercicio { get; set; }
        public string Categoria { get; set; }

        public string CargoEmComissao { get; set; }


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



    public class AntiguidadeServidoresViewModel
    {
        public AntiguidadeServidoresViewModel(Hashtable dados)
        {
            //            .Add(Projections.Property(() => rsAlias.DataExercicio), "rs_dataExercicio")
            //.Add(Projections.Property(() => rsAlias.Antiguidade), "rs_Antiguidade")
            //.Add(Projections.Property(() => pAlias.Nome), "Pessoa_Nome")
            //.Add(Projections.Property(() => cgAlias.Simbolo), "Simbolo_cargo")
            ////.Add(Projections.Property(() => cgAlias.Nome+ " - "+ cgAlias.Simbolo), "cargo")
            //.Add(Projections.Property(() => cgAlias.Nome), "cargo");

            Nome = (string)dados["Pessoa_Nome"];
            OrdemAntiguidade = (int)dados["rs_Antiguidade"];
            CodigoCargo = (string)dados["Simbolo_cargo"];
            PosseExercicio = (DateTime)dados["rs_dataExercicio"];
            Cargo = (string)dados["cargo"];
        }

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



    public class APICargosVagosEOcupadosViewModel
    {
        public APICargosVagosEOcupadosViewModel(QuantitativoVagasCargosData dados)
        {
            CodigoCargo = dados.Cargo;
            Cargo = dados.Nome;
            Existentes = dados.Total;
            Ocupados = dados.Ocupadas;
            Vagos = dados.Livres;
        }
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