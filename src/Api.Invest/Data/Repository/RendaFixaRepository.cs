using Api.Invest.Model.Dtos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Api.Invest.Data.Repository
{
    public class RendaFixaRepository : IRendaFixaRepository
    {
        public IList<LCIDto> GetAll()
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

           HttpResponseMessage response = client.GetAsync("http://www.mocky.io/v2/5e3429a33000008c00d96336").Result;

            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<LCIDto>>(result);
        }
    }
}
