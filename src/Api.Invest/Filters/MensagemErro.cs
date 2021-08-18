using Api.Invest.Filters;
using System.Collections.Generic;

namespace Api.Invest
{
    public class MensagemErro
    {
        public MensagemErro()
        {
            Erros = new List<Erro>();
        }

        public List<Erro> Erros { get; set; }
    }
}
