using Api.Invest.Example;
using Api.Invest.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Invest.Controllers
{
    [ApiController]
    public class MeusInvestimentosController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<MeusInvestimentosController> _logger;

        public MeusInvestimentosController(ILogger<MeusInvestimentosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("investimentos/meus-investimentos")]
        [ProducesResponseType(typeof(Investimentos), StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(InvestExemploErro), StatusCodes.Status400BadRequest)]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(InvestExemploErro))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        public IEnumerable<Investimentos> GetInvestimentos()
        {
            var investimentos = new List<Investimentos>();

            var meusInvestimentos = new Investimentos
            {
                IR = 15,
                Nome = "teste",
                ValorInvestido = 100,
            };

            investimentos.Add(meusInvestimentos);

            return investimentos;
        }
    }
}
