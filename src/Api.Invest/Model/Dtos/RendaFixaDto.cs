using System;

namespace Api.Invest.Model.Dtos
{
    public class RendaFixaDto
    {
        public int CapitalInvestido { get; set; }
        public int CapitalAtual { get; set; }
        public int Quantidade { get; set; }
        public DateTime Vencimento { get; set; }
        public int Iof { get; set; }
        public int OutrasTaxas { get; set; }
        public int Taxas { get; set; }
        public string Indice { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public bool GarantidoFGC { get; set; }
        public DateTime DataOperacao { get; set; }
        public double PrecoUnitario { get; set; }
        public bool Primario { get; set; }
    }
}
