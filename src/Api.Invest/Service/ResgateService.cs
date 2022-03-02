using Api.Invest.Service.Interface;
using System;

namespace Api.Invest.Service
{
    public class ResgateService : IResgateService
    {
        public decimal CalculoResgate(decimal valorTotal, decimal valorInvestido, string tipoInvestimento)
        {
            decimal valorResgate = 0;

            switch (tipoInvestimento)
            {
                case "tesouro direto":
                    return CalcularTaxaRentabilidadeTesouroDireto(valorTotal, valorInvestido);

                case "renda fixa":
                    return CalcularTaxaRentabilidadeRendaFixa(valorTotal, valorInvestido);

                case "fundos":
                    return CalcularTaxaRentabilidadeFundos(valorTotal, valorInvestido);

                default: return valorResgate;
            }
        }

        private decimal CalcularTaxaRentabilidadeTesouroDireto(decimal valorTotal, decimal valorInvestido)
        {
            var rentabilidade = valorTotal - valorInvestido;
            decimal taxaRentabilidadeTesouroDireto = (rentabilidade * 10) / 100;

            var valorResgate = Convert.ToDecimal(valorTotal - taxaRentabilidadeTesouroDireto);

            return valorResgate;
        }

        private decimal CalcularTaxaRentabilidadeRendaFixa(decimal valorTotal, decimal valorInvestido)
        {
            var rentabilidade = valorTotal - valorInvestido;
            decimal taxaRentabilidadeRendaFixa = (rentabilidade * 5) / 100;

            var valorResgate = Convert.ToDecimal(valorTotal - taxaRentabilidadeRendaFixa);

            return valorResgate;
        }

        private decimal CalcularTaxaRentabilidadeFundos(decimal valorTotal, decimal valorInvestido)
        {
            var rentabilidade = valorTotal - valorInvestido;
            decimal taxaRentabilidadeFundos = (rentabilidade * 15) / 100;

            var valorResgate = Convert.ToDecimal(valorTotal - taxaRentabilidadeFundos);

            return valorResgate;
        }
    }
}
