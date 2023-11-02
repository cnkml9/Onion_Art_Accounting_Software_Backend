using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Application.Interfaces.Repositories;

public interface IStockOutRepository
{
    IQueryable<StockOut> StockOuts { get; }
    Task<List<StockOut>> GetListAsync();
    Task<StockOut> GetByIdAsync(int stockOutId);
    Task<int> InsertAsync(StockOut stockOut);
    Task UpdateAsync(StockOut stockOut);
    Task DeleteAsync(StockOut stockOut);
}
