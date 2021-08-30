using Api.Invest.Data.Repository;
using Api.Invest.Model;
using Api.Invest.Service.Interface;
using System;
using System.Collections.Generic;

namespace Api.Invest.Service
{
    public class MeusInvestimentosService : IMeusInvestimentosService
    {
        private readonly IRendaFixaRepository _rendaFixaRepository;
        private readonly IFundosRepository _fundosRepository;
        private readonly ITesouroDiretoRepository _tesouroDiretoRepository;

        public IList<Investimentos> ObterTodosInvestimentos()
        {
            try
            {
                var meusInvestimentos = RetornaTotalDeInvestimentos();

                return meusInvestimentos;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possivel obter os resultados da busca. Tente mais tarde");
            }
        }

        private IList<Investimentos> RetornaTotalDeInvestimentos()
        {
            var totalInvestimentos = new List<Investimentos>();
            var meusInvestimentos = new Investimentos();

            var listaRendaFixa = _rendaFixaRepository.GetAll();
            var listaFundos = _fundosRepository.GetAll();
            var listaTesouroDireto = _tesouroDiretoRepository.GetAll();

            // buscar os titulos separados e fazer a soma

            // somar todos os titulos e adicionar na lista meusinvestimentos



            

            return totalInvestimentos;
        }
    }
}
