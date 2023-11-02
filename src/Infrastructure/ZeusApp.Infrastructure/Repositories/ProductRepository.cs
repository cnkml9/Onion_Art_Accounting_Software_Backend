using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZeusApp.Application.Interfaces.Repositories;
using ZeusApp.Domain.Entities.Catalog;
using ZeusApp.Infrastructure.DbContexts;

namespace ZeusApp.Infrastructure.Repositories;
public class ProductRepository : IProductRepository
{
    private readonly IRepositoryAsync<Product> _repository;

    public ProductRepository(IRepositoryAsync<Product> repository)
    {
        _repository = repository;
    }

    public IQueryable<Product> Products => _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id);

    public async Task DeleteAsync(Product product)
    {
        product.Status = -1;
        await _repository.UpdateAsync(product);
    }

    public async Task<Product> GetByIdAsync(int productId)
    {
        return await _repository.Entities.Where(p => p.Id == productId && p.Status != -1).FirstOrDefaultAsync();
    }

    public async Task<List<Product>> GetListAsync()
    {
        return await _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id).ToListAsync();
    }

    public async Task<int> InsertAsync(Product product)
    {
        await _repository.AddAsync(product);
        return product.Id;
    }

    public async Task UpdateAsync(Product product)
    {
        await _repository.UpdateAsync(product);
    }
}
