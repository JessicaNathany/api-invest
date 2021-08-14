using System;

namespace Api.Invest.Model
{
    public class Investimentos
    {
        public string Nome { get; set; }
        public double ValorTotal { get; set; }
        public double ValorInvestido { get; set; }
        public double ValorResgate { get; set; }
        public DateTime Vencimento { get; set; }
        public double IR { get; set; }
    }
}
