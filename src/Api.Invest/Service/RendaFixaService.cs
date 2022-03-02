using Api.Invest.Data.Repository;
using Api.Invest.Model;
using Api.Invest.Service.Interface;
using System;
using System.Collections.Generic;

namespace Api.Invest.Service
{
    public class RendaFixaService : IRendaFixaService
    {
        private readonly IRendaFixaRepository _rendaFixaRepository;
        private readonly IResgateService _resgateService;
        public RendaFixaService(IRendaFixaRepository rendaFixaRepository, IResgateService resgateService)
        {
            _rendaFixaRepository = rendaFixaRepository;
            _resgateService = resgateService;
        }

        public List<Investimento> ObtemTodosInvestimentosRendaFixa()
        {
            var investimentosRendaFixa = new List<Investimento>();
            var investimento = new Investimento();

            var listaRendaFixa = _rendaFixaRepository.ObterTodos();

            if (listaRendaFixa == null)
                return investimentosRendaFixa;

            foreach (var itens in listaRendaFixa)
            {
                var itensRendaFixa = itens.Lcis;

                foreach (var item in itensRendaFixa)
                {
                    investimento.TipoInvestimento = "Renda Fixa - LCIs";
                    investimento.Nome = item.Nome;
                    investimento.ValorInvestido = Convert.ToDecimal(item.CapitalInvestido);
                    investimento.Vencimento = item.Vencimento;
                    investimento.ValorResgate = _resgateService.CalculoResgate((decimal)item.CapitalAtual, (decimal)item.CapitalInvestido, "renda fixa");

                    investimentosRendaFixa.Add(investimento);
                }
            }

            return investimentosRendaFixa;
        }
    }
}
