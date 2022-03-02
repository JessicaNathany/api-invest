using Api.Invest.Data.Repository;
using Api.Invest.Model;
using Api.Invest.Service.Interface;
using System.Collections.Generic;

namespace Api.Invest.Service
{
    public class TesouroDiretoServices : ITesouroDiretoServices
    {
        private readonly ITesouroDiretoRepository _tesouroDiretoRepository;
        private readonly IResgateService _resgateService;
        public TesouroDiretoServices(ITesouroDiretoRepository tesouroDiretoRepository, IResgateService resgateService)
        {
            _tesouroDiretoRepository = tesouroDiretoRepository;
            _resgateService = resgateService;
        }
        public List<Investimento> ObtemTodosInvestimentosTesouroDireto()
        {
            var investimentosTesouro = new List<Investimento>();
            var investimento = new Investimento();

            var listaTesouroDireto = _tesouroDiretoRepository.ObterTodos();

            if (listaTesouroDireto == null)
                return investimentosTesouro;

            foreach (var item in listaTesouroDireto)
            {
                var tesourosDireto = item.TesourosDireto;

                foreach (var itemTesouroDireto in tesourosDireto)
                {
                    investimento.TipoInvestimento = "Tesouro Direto";
                    investimento.Nome = itemTesouroDireto.Nome;
                    investimento.ValorInvestido = itemTesouroDireto.ValorInvestido;
                    investimento.ValorTotal = itemTesouroDireto.ValorTotal;
                    investimento.Vencimento = itemTesouroDireto.Vencimento;
                    investimento.ValorResgate = _resgateService.CalculoResgate(itemTesouroDireto.ValorTotal, itemTesouroDireto.ValorInvestido, "tesouro direto");

                    investimentosTesouro.Add(investimento);
                }
            }

            return investimentosTesouro;
        }
    }
}
