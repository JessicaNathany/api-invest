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

        List<Investimento> totalInvestimentos = new List<Investimento>();
        public MeusInvestimentosService(IRendaFixaRepository rendaFixaRepository, IFundosRepository fundosRepository, ITesouroDiretoRepository tesouroDiretoRepository)
        {
            _rendaFixaRepository = rendaFixaRepository;
            _fundosRepository = fundosRepository;
            _tesouroDiretoRepository = tesouroDiretoRepository;
        }

        public IList<Investimento> ObterInvestimentos()
        {
            try
            {
                var investimentosTesouroDireto = ObtemTodosInvestimentosTesouroDireto();
                totalInvestimentos.AddRange(investimentosTesouroDireto);

                var investimentosRendaFixa = ObtemTodosInvestimentosRendaFixa();
                totalInvestimentos.AddRange(investimentosRendaFixa);

                var investimentosFundos = ObtemTodosInvestimentosFundos();
                totalInvestimentos.AddRange(investimentosFundos);

                return totalInvestimentos;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel obter os resultados da busca. Tente mais tarde", ex);
            }
        }

        private List<Investimento> ObtemTodosInvestimentosTesouroDireto()
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
                    investimento.Nome = itemTesouroDireto.Nome;
                    investimento.ValorInvestido = itemTesouroDireto.ValorInvestido;
                    investimento.ValorTotal = itemTesouroDireto.ValorTotal;
                    investimento.Vencimento = itemTesouroDireto.Vencimento;
                    investimento.IR = Convert.ToDouble(itemTesouroDireto.ValorTotal - itemTesouroDireto.ValorInvestido) - 10 / 100;
                    investimento.ValorResgate = CalculoResgate(itemTesouroDireto.Vencimento);
                    // calcular valor do resgate
                }

                investimentosTesouro.Add(investimento);
            }

            return investimentosTesouro;
        }

        private List<Investimento> ObtemTodosInvestimentosRendaFixa()
        {
            var investimentosRendaFixa = new List<Investimento>();
            var investimento = new Investimento();

            var listaRendaFixa = _rendaFixaRepository.ObterTodos();

            if (listaRendaFixa == null)
                return investimentosRendaFixa;

            foreach(var itens in listaRendaFixa)
            {
                var itensRendaFixa = itens.Lcis;

                foreach (var item  in itensRendaFixa)
                {
                    investimento.Nome = item.Nome;
                    investimento.ValorInvestido = Convert.ToDecimal(item.CapitalInvestido);
                    investimento.Vencimento = item.Vencimento;
                    investimento.IR = item.CapitalAtual - item.CapitalInvestido; // validar regra IR
                    investimento.IR = Convert.ToDouble(item.CapitalAtual - item.CapitalInvestido) - 5 / 100; // validar calculo IR
                    investimento.ValorResgate = CalculoResgate(item.Vencimento);
                }
            }

            return investimentosRendaFixa;
        }

        private List<Investimento> ObtemTodosInvestimentosFundos()
        {
            var investimentosFundos = new List<Investimento>();
            var investimento = new Investimento();

            var listaFundos = _fundosRepository.ObterTodos();

            if (listaFundos == null)
                return investimentosFundos;

            foreach (var itens in listaFundos)
            {
                var itemFundos = itens.Fundos;

                foreach (var item in itemFundos)
                {
                    investimento.Nome = item.Nome;
                    investimento.ValorInvestido = item.CapitalInvestido;
                    investimento.Vencimento = item.DataResgate;
                    investimento.IR = Convert.ToDouble(item.ValorAtual - item.CapitalInvestido) - 15 / 100;
                    investimento.ValorResgate = CalculoResgate(item.DataResgate);

                    //calcular valor do resgate
                }
            }

            return investimentosFundos;
        }

        private double CalculoResgate(DateTime dataVencimento)
        {
            double valorResgate = 0;
            var dataResgate = DateTime.Now;

            var investimentoComMetadeTempoCustodia = dataVencimento.AddMonths(-3);
            var investimentoComAteTresMesesVencer = dataVencimento.AddMonths(-3);
            var outrosInvestimentoVencimento = dataVencimento.AddMonths(-3);

            return valorResgate;
        }
    }
}
