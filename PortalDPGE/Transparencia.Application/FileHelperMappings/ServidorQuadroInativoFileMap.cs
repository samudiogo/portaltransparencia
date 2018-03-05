using FileHelpers;
using System;

namespace Transparencia.Application.FileHelperMappings
{
    [DelimitedRecord(";")]
    [IgnoreFirst, IgnoreEmptyLines]
    public class ServidorQuadroInativoFileMap
    {
        public string Nome;
        public string Matricula;
        public string Cargo;
        public string AtoNomeacao;
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime DataNomeacao;
        public string AtoAposentadoria;
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime DataAposentadoria;
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime Periodo;
    }
}
