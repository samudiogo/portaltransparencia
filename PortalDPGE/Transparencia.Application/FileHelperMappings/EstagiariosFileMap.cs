using FileHelpers;
using System;

namespace Transparencia.Application.FileHelperMappings
{
    [DelimitedRecord(";")]
    [IgnoreFirst, IgnoreEmptyLines]
    public class EstagiariosFileMap
    {
        public string Nome;
        public string CPF;
        public string Lotacao;
        public string Nivel;
        public string Especialidade;
        public string EntidadeDeEnsino;
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime InicioDoContrato;
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime PrevisaoDeTermino;
    }
}