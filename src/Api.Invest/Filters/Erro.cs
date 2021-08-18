using Newtonsoft.Json;

namespace Api.Invest.Filters
{
    public class Erro
    {
        [JsonProperty("codigo")]
        public string Codigo { get; set; }

        [JsonProperty("mensagem")]
        public string Mensagem { get; set; }
    }
}
