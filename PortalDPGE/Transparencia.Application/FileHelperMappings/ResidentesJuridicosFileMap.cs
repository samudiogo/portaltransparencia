using FileHelpers;
using System;

namespace Transparencia.Application.FileHelperMappings
{
    [DelimitedRecord(";")]
    [IgnoreFirst, IgnoreEmptyLines]
    public class ResidentesJuridicosFileMap
    {
        public string Nome;
        public string CPF;
        public string Lotacao;
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime Inicio;
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime PrevisaoDeTermino;
        public string Concurso;
    }
}