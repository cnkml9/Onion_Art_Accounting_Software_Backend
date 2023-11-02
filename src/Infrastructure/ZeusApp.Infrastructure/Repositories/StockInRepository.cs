using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZeusApp.Application.Interfaces.Repositories;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Infrastructure.Repositories;

public class StockInRepository : IStockInRepository
{
    private readonly IRepositoryAsync<StockIn> _repository;

    public StockInRepository(IRepositoryAsync<StockIn> repository)
    {
        _repository = repository;
    }

    public IQueryable<StockIn> StockIns => _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id);

    public async Task DeleteAsync(StockIn stockIn)
    {
        stockIn.Status = -1;
        await _repository.UpdateAsync(stockIn);
        //await _repository.DeleteAsync(stockIn);
    }

    public async Task<StockIn> GetByIdAsync(int stockOutId)
    {
        return await _repository.Entities.Where(p => p.Id == stockOutId & p.Status != -1).FirstOrDefaultAsync();
    }

    public async Task<List<StockIn>> GetListAsync()
    {
        return await _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id).ToListAsync();
    }

    public async Task<int> InsertAsync(StockIn stockIn)
    {
        await _repository.AddAsync(stockIn);
        return stockIn.Id;
    }

    public async Task UpdateAsync(StockIn stockIn)
    {
        await _repository.UpdateAsync(stockIn);
    }
}
