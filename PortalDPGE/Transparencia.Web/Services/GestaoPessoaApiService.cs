using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Transparencia.Web.Models;
using Transparencia.Web.Utils;
//using Transparencia.Application.ViewModels.DRH;
using Global.Dom.Entidade.PortalDPGE.Views;

namespace Transparencia.Web.Services
{
    public class GestaoPessoaApiService : IGestaoPessoaApiService
    {

        private readonly string _endPointUrl = AmbienteUtils.ObterAmbienteApi();

        #region Implementation of IGestaoPessoaApiService

        public async Task<IEnumerable<DateTime>> ObterPeriodoQuadroServidorAsync(string situacao = "")
        {
            using (var webClient = new HttpClient())
            {
                webClient.BaseAddress = new Uri(_endPointUrl);
                webClient.DefaultRequestHeaders.Accept.Clear();
                webClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await webClient.GetAsync($"gestaopessoas/periodosquadrocargo/{situacao}");
                if (response.IsSuccessStatusCode)
                    return (JsonConvert.DeserializeObject<HashSet<DateTime>>(await response.Content
                        .ReadAsStringAsync())).OrderBy(d=> d.Date);
            }
            return null;
        }

        public async Task<IEnumerable<ServidorAtivoViewModel>> ObterListaServidorAtivoPorPeriodoAsync(DateTime periodo)
        {
            using (var webClient = new HttpClient())
            {
                webClient.BaseAddress = new Uri(_endPointUrl);
                webClient.DefaultRequestHeaders.Accept.Clear();
                webClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await webClient.GetAsync($"gestaopessoas/quadrocargo/ativo/{periodo:'01'-MM-yyyy}");
                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<IEnumerable<ServidorAtivoViewModel>>(await response.Content
                        .ReadAsStringAsync());
            }
            return null;
        }

        public async Task<IEnumerable<ServidorInativoViewModel>> ObterListaServidorInativoPorPeriodoAsync(DateTime periodo)
        {
            using (var webClient = new HttpClient())
            {
                webClient.BaseAddress = new Uri(_endPointUrl);
                webClient.DefaultRequestHeaders.Accept.Clear();
                webClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await webClient.GetAsync($"gestaopessoas/servidoresinativo/{periodo:'01'-MM-yyyy}");
                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<IEnumerable<ServidorInativoViewModel>>(await response.Content
                        .ReadAsStringAsync());
            }
            return null;
        }

        public async Task<IEnumerable<ServidorCedidoParaDprjViewModel>> ObterListaServidorCedidoParaDprjPorPeriodoAsync(DateTime periodo)
        {
            using (var webClient = new HttpClient())
            {
                webClient.BaseAddress = new Uri(_endPointUrl);
                webClient.DefaultRequestHeaders.Accept.Clear();
                webClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await webClient.GetAsync($"gestaopessoas/quadrocargocedidosParaDprj/{periodo:'01'-MM-yyyy}");
                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<IEnumerable<ServidorCedidoParaDprjViewModel>>(await response.Content
                        .ReadAsStringAsync());
            }
            return null;
        }

        public async Task<IEnumerable<ServidorCedidoPelaDprjViewModel>> ObterListaServidorCedidoPelaDprjPorPeriodoAsync(DateTime periodo)
        {
            using (var webClient = new HttpClient())
            {
                webClient.BaseAddress = new Uri(_endPointUrl);
                webClient.DefaultRequestHeaders.Accept.Clear();
                webClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await webClient.GetAsync($"gestaopessoas/quadroscargoscedidosPelaDprj/{periodo:'01'-MM-yyyy}");
                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<IEnumerable<ServidorCedidoPelaDprjViewModel>>(await response.Content
                        .ReadAsStringAsync());
            }
            return null;
        }

        public async Task<Dictionary<string, int>> ObterTotaisDeServidoresAtivos()
        {
            using (var webClient = new HttpClient())
            {
                webClient.BaseAddress = new Uri(_endPointUrl);
                webClient.DefaultRequestHeaders.Accept.Clear();
                webClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await webClient.GetAsync("gestaopessoas/quadrocargo/totalquadroativo/");
                if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<IEnumerable<TotalCargoAtivoViewModel>>(await response.Content
                        .ReadAsStringAsync()).ToDictionary(k => k.Descricao, v => v.Total);
                
            }
            return null;
        }

        public async Task<IEnumerable<AntiguidadeDefensor>> ObterListaAntiguidadeDefensoresAsync()
        {
            using (var webClient = new HttpClient())
            {
                webClient.BaseAddress = new Uri(_endPointUrl);
                webClient.DefaultRequestHeaders.Accept.Clear();
                webClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await webClient.GetAsync("gestaopessoas/movimentacao/antiguidade-defensores");
                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<IEnumerable<AntiguidadeDefensor>>(await response.Content
                        .ReadAsStringAsync());
            }
            return null;
        }

        public async Task<IEnumerable<MovimentacaoDefensor>> ObterListaMovimentacaoDefensoresAsync()
        {
            using (var webClient = new HttpClient())
            {
                webClient.BaseAddress = new Uri("http://dev.apitransparencia.rj.def.br/api/");
                webClient.DefaultRequestHeaders.Accept.Clear();
                webClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await webClient.GetAsync("gestaopessoas/movimentacao/movimentacao-defensores");
                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<IEnumerable<MovimentacaoDefensor>>(await response.Content
                        .ReadAsStringAsync());
            }
            return null;
        }

        #endregion
    }
}