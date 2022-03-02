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
            var investimentos = service.ObterInvestimentos();
            return Ok(investimentos);
        }

        [HttpGet]
        [Route("investimentos/obter-tesouro-direto")]
        [ProducesResponseType(typeof(Investimento), StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(InvestExemploErro), StatusCodes.Status400BadRequest)]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(InvestExemploErro))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        public ActionResult GetTesourdoDireto([FromServices] ITesouroDiretoServices service)
        {
            var listaTesouroDireto = service.ObtemTodosInvestimentosTesouroDireto();
            return Ok(listaTesouroDireto);
        }

        [HttpGet]
        [Route("investimentos/obter-tesouro-renda-fixa")]
        [ProducesResponseType(typeof(Investimento), StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(InvestExemploErro), StatusCodes.Status400BadRequest)]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(InvestExemploErro))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        public ActionResult GetRendaFixa([FromServices] IRendaFixaService service)
        {
            var listaRendaFixa = service.ObtemTodosInvestimentosRendaFixa();
            return Ok(listaRendaFixa);
        }

        [HttpGet]
        [Route("investimentos/obter-tesouro-fundos")]
        [ProducesResponseType(typeof(Investimento), StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(InvestExemploErro), StatusCodes.Status400BadRequest)]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(InvestExemploErro))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        public ActionResult GetFundos([FromServices] IFundoService service)
        {
           var listaFundos =  service.ObtemTodosInvestimentosFundos();
            return Ok(listaFundos);
        }
    }
}
