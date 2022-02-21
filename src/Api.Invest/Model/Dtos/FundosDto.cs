using Newtonsoft.Json;
using System.Collections.Generic;

namespace Api.Invest.Model.Dtos
{
    public class FundosDto
    {
        [JsonProperty("fundos")]
        public List<ResponseFundosDto> Fundos { get; set; }
    }
}
