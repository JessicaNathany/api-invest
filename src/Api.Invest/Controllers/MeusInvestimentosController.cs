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
        //[SwaggerOperation(Summary = CartoesMessageSummary.CancelarCartaoDigital)]
        [ProducesResponseType(typeof(Investimentos), StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(InvestExemploErro), StatusCodes.Status400BadRequest)]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(InvestExemploErro))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        public IEnumerable<WeatherForecast> GetInvestimentos()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray();
        }
    }
}
