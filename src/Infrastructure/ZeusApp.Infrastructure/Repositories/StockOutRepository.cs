using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZeusApp.Application.Interfaces.Repositories;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Infrastructure.Repositories;

public class StockOutRepository : IStockOutRepository
{
    private readonly IRepositoryAsync<StockOut> _repository;

    public StockOutRepository(IRepositoryAsync<StockOut> repository)
    {
        _repository = repository;
    }

    public IQueryable<StockOut> StockOuts => _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id);

    public async Task DeleteAsync(StockOut stockOut)
    {
        stockOut.Status = -1;
        await _repository.UpdateAsync(stockOut);
        //await _repository.DeleteAsync(stockOut);
    }

    public async Task<StockOut> GetByIdAsync(int stockOutId)
    {
        return await _repository.Entities.Where(p => p.Id == stockOutId & p.Status != -1).FirstOrDefaultAsync();
    }

    public async Task<List<StockOut>> GetListAsync()
    {
        return await _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id).ToListAsync();
    }

    public async Task<int> InsertAsync(StockOut stockOut)
    {
        await _repository.AddAsync(stockOut);
        return stockOut.Id;
    }

    public async Task UpdateAsync(StockOut stockOut)
    {
        await _repository.UpdateAsync(stockOut);
    }
}
