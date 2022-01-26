using System;

namespace Api.Invest.Model.Dtos
{
    public class RendaFixaDto
    {
        public double CapitalInvestido { get; set; }
        public double CapitalAtual { get; set; }
        public string Quantidade { get; set; }
        public DateTime Vencimento { get; set; }
        public string Iof { get; set; }
        public string OutrasTaxas { get; set; }
        public string Taxas { get; set; }
        public string Indice { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public bool GarantidoFGC { get; set; }
        public DateTime DataOperacao { get; set; }
        public double PrecoUnitario { get; set; }
        public bool Primario { get; set; }
    }
}
