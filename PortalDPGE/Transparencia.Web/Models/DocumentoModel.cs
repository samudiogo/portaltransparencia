using Global.Dom.Entidade.PortalDPGE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transparencia.Web.Models
{
    public class DocumentoModel
    {
        public TipoDocumento Documentos { get; set; }
        public String Link { get; set; }
        public String ConteudoHtml { get; set; }
        
    }
}