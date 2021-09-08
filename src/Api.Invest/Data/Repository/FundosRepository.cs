﻿using Api.Invest.Extensions;
using Api.Invest.Model.Dtos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Api.Invest.Data.Repository
{
    public class FundosRepository : IFundosRepository
    {
        private readonly AppSettings _appSettings;
        public FundosRepository(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }
        public IList<FundosDto> GetAll()
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //HttpResponseMessage response = client.GetAsync("http://www.mocky.io/v2/5e3429a33000008c00d96336").Result;
            HttpResponseMessage response = client.GetAsync(_appSettings.FundosUrl).Result;

            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<FundosDto>>(result);
        }
    }
}
