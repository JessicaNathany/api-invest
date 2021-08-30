using Api.Invest.Model;
using System.Collections.Generic;

namespace Api.Invest.Service.Interface
{
    public interface IMeusInvestimentosService
    {
        IList<Investimentos> ObterTodosInvestimentos();
    }
}
