using Newtonsoft.Json;
using System.Collections.Generic;

namespace Api.Invest.Model.Dtos
{
    public class LCIDto
    {
        [JsonProperty("lcis")]
        public List<RendaFixaDto> Lcis { get; set; }
    }
}
