using Api.Invest.Model.Dtos;
using System.Collections.Generic;

namespace Api.Invest.Data.Repository
{
    public interface ITesouroDiretoRepository
    {
        IList<TDDto> GetAll();
    }
}
