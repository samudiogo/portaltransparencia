using PortalDPGE.Transparencia.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDPGE.Transparencia.Web.Services
{
    public interface IPortalApiService
    {
        ConteudoViewModel ObterPorAlias(string AreaOuSecao, string alias);
    }
}
