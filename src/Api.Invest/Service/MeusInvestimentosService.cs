using Api.Invest.Model;
using Api.Invest.Service.Interface;
using System;
using System.Collections.Generic;

namespace Api.Invest.Service
{
    public class MeusInvestimentosService : IMeusInvestimentosService
    {
        private readonly IRendaFixaService _rendaFixaService;
        private readonly IFundoService _fundosService;
        private readonly ITesouroDiretoServices _tesouroService;
        
        public MeusInvestimentosService(IRendaFixaService rendaFixaService, IFundoService fundosService, ITesouroDiretoServices tesouroDiretoService)
        {
            _rendaFixaService = rendaFixaService;
            _fundosService = fundosService;
            _tesouroService = tesouroDiretoService;
        }

        public IList<Investimento> ObterInvestimentos()
        {
            try
            {
                var totalInvestimentos = new List<Investimento>();

                var investimentosTesouroDireto = _tesouroService.ObtemTodosInvestimentosTesouroDireto();
                totalInvestimentos.AddRange(investimentosTesouroDireto);

                var investimentosRendaFixa = _rendaFixaService.ObtemTodosInvestimentosRendaFixa();
                totalInvestimentos.AddRange(investimentosRendaFixa);

                var investimentosFundos = _fundosService.ObtemTodosInvestimentosFundos();
                totalInvestimentos.AddRange(investimentosFundos);

                return totalInvestimentos;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel obter os resultados da busca. Tente mais tarde", ex);
            }
        }
    }
}
