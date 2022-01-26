using Api.Invest.Data.Repository;
using Api.Invest.Model;
using Api.Invest.Model.Dtos;
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

        List<Investimentos> totalInvestimentos = new List<Investimentos>();
        public MeusInvestimentosService(IRendaFixaRepository rendaFixaRepository, 
                                        IFundosRepository fundosRepository, 
                                        ITesouroDiretoRepository tesouroDiretoRepository)
        {
            _rendaFixaRepository = rendaFixaRepository;
            _fundosRepository = fundosRepository;
            _tesouroDiretoRepository = tesouroDiretoRepository;
        }

        public IList<Investimentos> ObterInvestimentos()
        {
            try
            {
                var investimentos = new Investimentos();

                var teste = ObtemTodosInvestimentosTesouroDireto();



                /*
                 * Criar um endpoint que retorne o valor total do investimento do cliente e lista dos seus investimentos. 
                 * Cada item da lista deverá conter seu valor unitário, cálculo de IR conforme regra abaixo e valor calculado 
                 * caso o cliente queira resgatar seu investimento na data. O contrato esperado para o retorno é o seguinte:
                 * 
                 * {
                       "valorTotal": 829.68,
                       //Aqui deverão ser listados todos os investimentos retornados pelos 3 serviços
                       "investimentos": [{
                       "nome": "Tesouro Selic 2025",
                       "valorInvestido": 799.4720,
                       "valorTotal": 829.68,
                       "vencimento": "2025-03-01T00:00:00",
                       "Ir": 3.0208,
                       "valorResgate": 705.228
                   }]
                   }*/


                /* Cálculo do resgate: investimento com mais da metade do tempo em custódia. 
                 * Perde 15% do valor investido.
                 * Investimento com até 3 meses para vencer: Perde 6% do valor investido
                 * Outros: Perde 30% do valor investido
                 */


                return totalInvestimentos;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel obter os resultados da busca. Tente mais tarde", ex);
            }
        }

        private List<Investimentos> ObtemTodosInvestimentosTesouroDireto()
        {
            var investimentosTesouro = new List<Investimentos>();
            var investimento = new Investimentos();

            var listaTesouroDireto = _tesouroDiretoRepository.GetAll();

            if (listaTesouroDireto == null)
                return null;

            foreach (var item in listaTesouroDireto)
            {
                var tesourosDireto = item.TesourosDireto;

                foreach (var itemTesouroDireto in tesourosDireto)
                {
                    investimento.Nome = itemTesouroDireto.Nome;
                    investimento.ValorInvestido = itemTesouroDireto.ValorInvestido;
                    investimento.ValorTotal = itemTesouroDireto.ValorTotal;
                    investimento.Vencimento = itemTesouroDireto.Vencimento;
                    // incluir o cálculo do resgate e o cálculo do IR
                }

                investimentosTesouro.Add(investimento);
            }

            return investimentosTesouro;
        }
    }
}
