using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Application.Interfaces.Repositories;

public interface IStockInRepository
{
    IQueryable<StockIn> StockIns { get; }
    Task<List<StockIn>> GetListAsync();
    Task<StockIn> GetByIdAsync(int stockInId);
    Task<int> InsertAsync(StockIn stockIn);
    Task UpdateAsync(StockIn stockIn);
    Task DeleteAsync(StockIn stockIn);
}
