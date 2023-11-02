using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Application.Interfaces.Repositories;
public interface ICustomerSupplierRepository
{
    IQueryable<CustomerSupplier> CustomerSuppliers { get; }
    Task<List<CustomerSupplier>> GetListAsync();
    Task<CustomerSupplier> GetByIdAsync(int customerCategoryId);
    Task<int> InsertAsync(CustomerSupplier customerCategory);
    Task UpdateAsync(CustomerSupplier customerCategory);
    Task DeleteAsync(CustomerSupplier customerCategory);
}
