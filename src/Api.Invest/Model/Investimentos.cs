﻿using System;

namespace Api.Invest.Model
{
    public class Investimentos
    {
        public string Nome { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorInvestido { get; set; }
        public double ValorResgate { get; set; }
        public DateTime Vencimento { get; set; }
        public double IR { get; set; }
    }
}
