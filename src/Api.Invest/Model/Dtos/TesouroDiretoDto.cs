using Newtonsoft.Json;
using System;

namespace Api.Invest.Model.Dtos
{
    public class TesouroDiretoDto
    {
        public decimal ValorInvestido { get; set; }
        
        public decimal ValorTotal { get; set; }

        public DateTime Vencimento { get; set; }

        [JsonProperty("dataDeCompra")]
        public DateTime DataCompra { get; set; }

        public int Iof { get; set; }

        public string Indice { get; set; }

        public string Tipo { get; set; }

        public string Nome { get; set; }
    }
}
