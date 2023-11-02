using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Application.Interfaces.Repositories;

public interface IProductCategoryRepository
{
    IQueryable<ProductCategory> ProductCategories { get; }
    Task<List<ProductCategory>> GetListAsync();
    Task<ProductCategory> GetByIdAsync(int productCategoryId);
    Task<int> InsertAsync(ProductCategory productCategory);
    Task UpdateAsync(ProductCategory productCategory);
    Task DeleteAsync(ProductCategory productCategory);
}
