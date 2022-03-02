using System;

namespace Api.Invest.Model
{
    public class Investimento
    {
        public string TipoInvestimento { get; set; }
        public string Nome { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorInvestido { get; set; }
        public decimal ValorResgate { get; set; }
        public DateTime Vencimento { get; set; }
    }
}
