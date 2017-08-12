using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalDPGE.Transparencia.Web.Models
{
    public class PortalViewModel
    {

    }
    public class ConteudoViewModel
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Secao { get; set; }
        public string Titulo { get; set; }
        public string ConteudoHtml { get; set; }
        public int NivelAcesso { get; set; }
    }

}