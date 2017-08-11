using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PortalDPGE.Transparencia.Web.Models;

namespace PortalDPGE.Transparencia.Web.Services
{
    public class GestaoPessoaApiService : IGestaoPessoaApiService
    {

        private const string EndPointUrl = "http://dev.api.transparencia.def.rj.br/api/";

        #region Implementation of IGestaoPessoaApiService

        public async Task<IEnumerable<DateTime>> ObterPeriodoQuadroServidorAsync(string situacao = "")
        {
            using (var webClient = new HttpClient())
            {
                webClient.BaseAddress = new Uri(EndPointUrl);
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
                webClient.BaseAddress = new Uri(EndPointUrl);
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
                webClient.BaseAddress = new Uri(EndPointUrl);
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
                webClient.BaseAddress = new Uri(EndPointUrl);
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
                webClient.BaseAddress = new Uri(EndPointUrl);
                webClient.DefaultRequestHeaders.Accept.Clear();
                webClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await webClient.GetAsync($"gestaopessoas/quadroscargoscedidosPelaDprj/{periodo:'01'-MM-yyyy}");
                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<IEnumerable<ServidorCedidoPelaDprjViewModel>>(await response.Content
                        .ReadAsStringAsync());
            }
            return null;
        }

        #endregion

        private IEnumerable<DateTime> GetMockDate()
        {
            var lista = new List<DateTime>();
            var dataInicial = new DateTime(2016, 1, 1);
            for (var i = 0; i <= 20; i++)
                lista.Add(dataInicial.AddMonths(i));

            return lista;
        }
    }
}