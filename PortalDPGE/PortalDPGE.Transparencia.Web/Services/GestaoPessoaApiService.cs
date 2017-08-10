using System;
using System.Collections.Generic;
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
            return await Task.Run(() => GetMockDate());
        }

        public async Task<IEnumerable<ServidorModel>> ObterListaServidorPorSituaoPeriodoAsync(string situacao, DateTime periodo)
        {
            using (var webClient = new HttpClient())
            {
                webClient.BaseAddress = new Uri(EndPointUrl);
                webClient.DefaultRequestHeaders.Accept.Clear();
                webClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await webClient.GetAsync($"gestaopessoas/quadroscargos/{situacao}/{periodo:'01'-MM-yyyy}");
                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<IEnumerable<ServidorModel>>(await response.Content
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