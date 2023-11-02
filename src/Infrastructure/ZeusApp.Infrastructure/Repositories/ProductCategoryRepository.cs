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
public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly IRepositoryAsync<ProductCategory> _repository;

    public ProductCategoryRepository(IRepositoryAsync<ProductCategory> repository)
    {
        _repository = repository;
    }

    public IQueryable<ProductCategory> ProductCategories => _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id);

    public async Task DeleteAsync(ProductCategory productCategory)
    {
        productCategory.Status = -1;
        await _repository.UpdateAsync(productCategory);
    }

    public async Task<ProductCategory> GetByIdAsync(int productCategoryId)
    {
        return await _repository.Entities.Where(p => p.Id == productCategoryId && p.Status != -1).FirstOrDefaultAsync();
    }

    public async Task<List<ProductCategory>> GetListAsync()
    {
        return await _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id).ToListAsync();
    }

    public async Task<int> InsertAsync(ProductCategory productCategory)
    {
        await _repository.AddAsync(productCategory);
        return productCategory.Id;
    }

    public async Task UpdateAsync(ProductCategory productCategory)
    {
        await _repository.UpdateAsync(productCategory);
    }
}


