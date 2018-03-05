using Transparencia.Web.Models;

namespace Transparencia.Web.Services
{
    public interface IPortalApiService
    {
        ConteudoViewModel ObterPorAlias(string AreaOuSecao, string alias);
    }
}
