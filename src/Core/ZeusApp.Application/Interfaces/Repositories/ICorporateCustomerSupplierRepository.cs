using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Application.Interfaces.Repositories;
public interface ICorporateCustomerSupplierRepository
{
    IQueryable<CorporateCustomerSupplier> CorporateCustomerSuppliers { get; }
    Task<List<CorporateCustomerSupplier>> GetListAsync();
    Task<CorporateCustomerSupplier> GetByIdAsync(int corporateCustomerSupplierId);
    Task<int> InsertAsync(CorporateCustomerSupplier corporateCustomerSupplier);
    Task UpdateAsync(CorporateCustomerSupplier corporateCustomerSupplier);
    Task DeleteAsync(CorporateCustomerSupplier corporateCustomerSupplier);
}
