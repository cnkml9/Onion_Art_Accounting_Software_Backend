using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZeusApp.Application.Interfaces.Repositories;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Infrastructure.Repositories;

public class CustomerSupplierRepository : ICustomerSupplierRepository
{
    private readonly IRepositoryAsync<CustomerSupplier> _repository;

    public CustomerSupplierRepository(IRepositoryAsync<CustomerSupplier> repository)
    {
        _repository = repository;
    }

    public IQueryable<CustomerSupplier> CustomerSuppliers => _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id);

    public async Task DeleteAsync(CustomerSupplier CustomerSupplier)
    {
        CustomerSupplier.Status = -1;
        await _repository.UpdateAsync(CustomerSupplier);
    }

    public async Task<CustomerSupplier> GetByIdAsync(int customerSupplierId)
    {
        return await _repository.Entities
            .Include(x => x.Contact)
            .Include(x => x.Banks)
            .Include(x => x.OtherAddresses)
            .Include(x => x.RelatedPersons)
            .SingleOrDefaultAsync(p => p.Id == customerSupplierId && p.Status != -1);
    }
    
    public async Task<List<CustomerSupplier>> GetListAsync()
    {
        return await _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id).ToListAsync();
    }

    public async Task<int> InsertAsync(CustomerSupplier customerSupplier)
    {
        await _repository.AddAsync(customerSupplier);
        return customerSupplier.Id;
    }

    public async Task UpdateAsync(CustomerSupplier customerSupplier)
    {
        await _repository.UpdateAsync(customerSupplier);
    }
}
