namespace Api.Invest.Service.Interface
{
    public interface IResgateService
    {
        decimal CalculoResgate(decimal valorTotal, decimal valorInvestido, string tipoInvestimento);
    }
}
