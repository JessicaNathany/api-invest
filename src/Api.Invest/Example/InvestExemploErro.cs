using Api.Invest.Filters;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Invest.Example
{
    public class InvestExemploErro : IExamplesProvider<MensagemErro>
    {
        public MensagemErro GetExamples()
        {
            var mensagem = new MensagemErro();

            mensagem.Erros.AddRange(new List<Erro>
            {
                new Erro
                {
                    Codigo = "1",
                    Mensagem = "Dados inválidos"
                }
            });

            return mensagem;
        }
    }
}
