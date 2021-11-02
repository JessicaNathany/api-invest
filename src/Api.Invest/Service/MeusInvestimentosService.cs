using Api.Invest.Data.Repository;
using Api.Invest.Model;
using Api.Invest.Model.Dtos;
using Api.Invest.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Invest.Service
{
    public class MeusInvestimentosService : IMeusInvestimentosService
    {
        private readonly IRendaFixaRepository _rendaFixaRepository;
        private readonly IFundosRepository _fundosRepository;
        private readonly ITesouroDiretoRepository _tesouroDiretoRepository;

        public MeusInvestimentosService(IRendaFixaRepository rendaFixaRepository, IFundosRepository fundosRepository, ITesouroDiretoRepository tesouroDiretoRepository)
        {
            _rendaFixaRepository = rendaFixaRepository;
            _fundosRepository = fundosRepository;
            _tesouroDiretoRepository = tesouroDiretoRepository;
        }

        public IList<Investimentos> ObterTodosInvestimentos()
        {
            try
            {
                var totalInvestimentos = new List<Investimentos>();
                var investimentos = new Investimentos();

                var rendasFixa = ObtemListaRendaFixa();
                var listaTesouroDireto = ObtemListaTesouroDireto();




                /* Cálculo do resgate: investimento com mais da metade do tempo em custódia. 
                 * Perde 15% do valor investido.
                 * Investimento com até 3 meses para vencer: Perde 6% do valor investido
                 * Outros: Perde 30% do valor investido
                 */


                return totalInvestimentos;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possivel obter os resultados da busca. Tente mais tarde");
            }
        }

        private List<TesouroDiretoDto> ObtemListaTesouroDireto()
        {
            var tesouroDireto = new TesouroDiretoDto();
            var listaTesouroDireto = new List<TesouroDiretoDto>();

            var tesourosDiretoRepository = _tesouroDiretoRepository.GetAll();

            foreach (var item in tesourosDiretoRepository)
            {
                tesouroDireto.ValorInvestido = item.ValorInvestido;
                tesouroDireto.ValorTotal = item.ValorTotal;
                tesouroDireto.Vencimento = item.Vencimento;
                tesouroDireto.DataCompra = item.DataCompra;
                tesouroDireto.Iof = item.Iof;
                tesouroDireto.Indice = item.Indice;
                tesouroDireto.Tipo = item.Tipo;
                tesouroDireto.Nome = item.Nome;
            }

            listaTesouroDireto.Add(tesouroDireto);

            return listaTesouroDireto;
        }

        private List<RendaFixaDto> ObtemListaRendaFixa()
        {
            var listRendasFixa = new List<RendaFixaDto>();
            var rendaFixa = new RendaFixaDto();

            var rendasFixaRepository = _rendaFixaRepository.GetAll();

            foreach (var item in rendasFixaRepository)
            {
                
            }

            return listRendasFixa;
        }
    }
}
