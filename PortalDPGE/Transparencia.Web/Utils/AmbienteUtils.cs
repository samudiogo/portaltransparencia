using Global.Dom.Util;

namespace Transparencia.Web.Utils
{
    public static class AmbienteUtils
    {
        /// <summary>
        /// Retorna o endereço base da api
        /// </summary>
        /// <returns>url exemplo: "http://apitransparencia.rj.def.br/api/"</returns>
        public static string ObterAmbienteApi()
        {
            return string.Empty;
            switch (Itario.AmbienteSite())
            {
                
                case ModoSite.HomologacaoProderj:
                    return "http://apitransparencia.proderj.rj.gov.br/api/";
                case ModoSite.Producao:
                    return "http://apitransparencia.rj.def.br/api/";
                case ModoSite.Homologacao:
                case ModoSite.Desenvolvimento:
                case ModoSite.Desconhecido:
                default:
                    return "http://dev.apitransparencia.rj.def.br/api/";
            }
        }
    }
}