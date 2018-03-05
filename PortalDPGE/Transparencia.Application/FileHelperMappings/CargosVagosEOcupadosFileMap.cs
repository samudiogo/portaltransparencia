using FileHelpers;

namespace Transparencia.Application.FileHelperMappings
{ 
    [DelimitedRecord(";")]
    [IgnoreFirst, IgnoreEmptyLines]
    public class CargosVagosEOcupadosFileMap
    {
        public string CodigoCargo;
        public string Cargo;
        public int Existentes;
        public int Ocupados;
        public int Vagos;
    }
}
