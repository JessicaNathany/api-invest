using Newtonsoft.Json;
using System.Collections.Generic;

namespace Api.Invest.Model.Dtos
{
    public class TDDto
    {
        [JsonProperty("tds")]
        public List<TesouroDiretoDto> TesourosDireto {get; set;}
    }
}
