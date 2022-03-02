using Api.Invest.Model;
using System.Collections.Generic;

namespace Api.Invest.Service.Interface
{
    public interface IRendaFixaService
    {
        List<Investimento> ObtemTodosInvestimentosRendaFixa();
    }
}
