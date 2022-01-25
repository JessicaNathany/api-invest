using Api.Invest.Example;
using Api.Invest.Model;
using Api.Invest.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace Api.Invest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeusInvestimentosController : ControllerBase
    {
        //private readonly IMeusInvestimentosService _meusInvestimentosService;

        //public MeusInvestimentosController(IMeusInvestimentosService meusInvestimentosService)
        //{
        //    _meusInvestimentosService = meusInvestimentosService;
        //}

        [HttpGet]
        [Route("investimentos/meus-investimentos")]
        [ProducesResponseType(typeof(Investimentos), StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(InvestExemploErro), StatusCodes.Status400BadRequest)]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(InvestExemploErro))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        public ActionResult GetInvestimentos([FromServices] IMeusInvestimentosService service)
        {
            service.ObterInvestimentos();
            return Ok(service);
        }
    }
}
