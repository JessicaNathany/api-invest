using Api.Invest.Example;
using Api.Invest.Model;
using Api.Invest.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Invest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeusInvestimentosController : ControllerBase
    {
        [HttpGet]
        [Route("investimentos/obter-todos")]
        [ProducesResponseType(typeof(Investimento), StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(InvestExemploErro), StatusCodes.Status400BadRequest)]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(InvestExemploErro))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        public ActionResult GetInvestimentos([FromServices] IMeusInvestimentosService service)
        {
            service.ObterInvestimentos();
            return Ok(service);
        }

        [HttpGet]
        [Route("investimentos/obter-tesouro-direto")]
        [ProducesResponseType(typeof(Investimento), StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(InvestExemploErro), StatusCodes.Status400BadRequest)]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(InvestExemploErro))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        public ActionResult GetTesourdoDireto([FromServices] IMeusInvestimentosService service)
        {
            service.ObterInvestimentos();
            return Ok(service);
        }

        [HttpGet]
        [Route("investimentos/obter-tesouro-renda-fixa")]
        [ProducesResponseType(typeof(Investimento), StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(InvestExemploErro), StatusCodes.Status400BadRequest)]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(InvestExemploErro))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        public ActionResult GetRendaFixa([FromServices] IMeusInvestimentosService service)
        {
            service.ObterInvestimentos();
            return Ok(service);
        }

        [HttpGet]
        [Route("investimentos/obter-tesouro-fundos")]
        [ProducesResponseType(typeof(Investimento), StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(InvestExemploErro), StatusCodes.Status400BadRequest)]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(InvestExemploErro))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        public ActionResult GetFundos([FromServices] IMeusInvestimentosService service)
        {
            service.ObterInvestimentos();
            return Ok(service);
        }
    }
}
