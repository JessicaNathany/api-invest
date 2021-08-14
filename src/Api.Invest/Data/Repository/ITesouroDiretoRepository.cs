using Api.Invest.Model.Dtos;
using System.Threading.Tasks;

namespace Api.Invest.Data.Repository
{
    public interface ITesouroDiretoRepository
    {
        Task<TDDto> GetAllAsync();
    }
}
