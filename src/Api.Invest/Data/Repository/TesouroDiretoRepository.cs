using Api.Invest.Extensions;
using Api.Invest.Model.Dtos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Api.Invest.Data.Repository
{
    public class TesouroDiretoRepository : ITesouroDiretoRepository
    {
        private readonly AppSettings _appSettings;

        public TesouroDiretoRepository(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public IList<TDDto> GetAll()
        {
            using var client = new HttpClient();
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //HttpResponseMessage response = client.GetAsync("http://www.mocky.io/v2/5e3428203000006b00d9632a").Result;
            HttpResponseMessage response = client.GetAsync(_appSettings.TesouroDiretoUrl).Result;
            
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<TDDto>>(result);
        }
    }
}
