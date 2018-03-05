using System;
using FileHelpers;

namespace Transparencia.Application.FileHelperMappings
{
    [DelimitedRecord(";")]
    [IgnoreFirst, IgnoreEmptyLines]
    public class ServidorQuadroAtivoFileMap
    {
        [FieldOrder(10)]
        public string Nome;
        [FieldOrder(20)]
        public string Matricula;
        [FieldOrder(30)]
        public string Categoria;
        [FieldOrder(40)]
        public string Cargo;
        [FieldOrder(50)]
        public string Funcao;
        [FieldOrder(60)]
        public string Lotacao;
        [FieldOrder(70)]
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime Nomeacao;
        [FieldOrder(80)]
        public string Estavel;
        [FieldOrder(90)]
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime Periodo;
    }
}