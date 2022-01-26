using Api.Invest.Model.Dtos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Api.Invest.Data.Repository
{
    public class TesouroDiretoRepository : ITesouroDiretoRepository
    {
        public IList<TDDto> GetAll()
        {
            using var client = new HttpClient();
            var listaTdd = new List<TDDto>();
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync("http://www.mocky.io/v2/5e3428203000006b00d9632a").Result;
            
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsStringAsync().Result;

            var listaTDD =  JsonConvert.DeserializeObject<TDDto>(result);
            listaTdd.Add(listaTDD);

            return listaTdd;
        }
    }
}
