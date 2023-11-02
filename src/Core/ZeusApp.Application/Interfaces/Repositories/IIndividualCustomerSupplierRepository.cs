using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Application.Interfaces.Repositories;

public interface IIndividualCustomerSupplierRepository
{
    IQueryable<IndividualCustomerSupplier> IndividualCustomerSuppliers { get; }
    Task<List<IndividualCustomerSupplier>> GetListAsync();
    Task<IndividualCustomerSupplier> GetByIdAsync(int individualCustomerSupplierId);
    Task<int> InsertAsync(IndividualCustomerSupplier individualCustomerSupplier);
    Task UpdateAsync(IndividualCustomerSupplier individualCustomerSupplier);
    Task DeleteAsync(IndividualCustomerSupplier individualCustomerSupplier);
}
