using Api.Invest.Data.Repository;
using Api.Invest.Model;
using System.Collections.Generic;

namespace Api.Invest.Service.Interface
{
    public class FundoService : IFundoService
    {
        private readonly IResgateService _resgateService;
        private readonly IFundoRepository _fundoRepository;
        public FundoService(IFundoRepository fundoRepository, IResgateService resgateService)
        {
            _fundoRepository = fundoRepository;
            _resgateService = resgateService;
        }
        public List<Investimento> ObtemTodosInvestimentosFundos()
        {
            var investimentosFundos = new List<Investimento>();
            var investimento = new Investimento();

            var listaFundos = _fundoRepository.ObterTodos();

            if (listaFundos == null)
                return investimentosFundos;

            foreach (var itens in listaFundos)
            {
                var itemFundos = itens.Fundos;

                foreach (var item in itemFundos)
                {
                    investimento.TipoInvestimento = "Fundos";
                    investimento.Nome = item.Nome;
                    investimento.ValorInvestido = item.CapitalInvestido;
                    investimento.Vencimento = item.DataResgate;
                    investimento.ValorResgate = _resgateService.CalculoResgate(item.ValorAtual, item.CapitalInvestido, "fundos");

                    investimentosFundos.Add(investimento);
                }
            }

            return investimentosFundos;
        }
    }
}
