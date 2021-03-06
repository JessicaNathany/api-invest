using Api.Invest.Model.Dtos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Api.Invest.Data.Repository
{
    public class RendaFixaRepository : IRendaFixaRepository
    {
        public IList<LCIDto> ObterTodos()
        {
            using var client = new HttpClient();
            var listaLci = new List<LCIDto>();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync("http://www.mocky.io/v2/5e3429a33000008c00d96336").Result;

            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsStringAsync().Result;

            var jsonSerializeLCIs = JsonConvert.DeserializeObject<LCIDto>(result);
            listaLci.Add(jsonSerializeLCIs);

            return listaLci;
        }
    }
}
