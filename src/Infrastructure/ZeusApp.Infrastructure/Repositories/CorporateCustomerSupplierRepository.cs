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
public class CorporateCustomerSupplierRepository : ICorporateCustomerSupplierRepository
{
    private readonly IRepositoryAsync<CorporateCustomerSupplier> _repository;

    public CorporateCustomerSupplierRepository(IRepositoryAsync<CorporateCustomerSupplier> repository)
    {
        _repository = repository;
    }

    public IQueryable<CorporateCustomerSupplier> CorporateCustomerSuppliers => _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id);

    public async Task DeleteAsync(CorporateCustomerSupplier corporateCustomerSupplier)
    {
        corporateCustomerSupplier.Status = -1;
        await _repository.UpdateAsync(corporateCustomerSupplier);
    }

    public async Task<CorporateCustomerSupplier> GetByIdAsync(int corporateCustomerSupplierId)
    {
        return await _repository.Entities
            .Include(x => x.Contact)
            .Include(x => x.Banks)
            .Include(x => x.OtherAddresses)
            .Include(x => x.RelatedPersons)
            .Where(p => p.Id == corporateCustomerSupplierId && p.Status != -1).FirstOrDefaultAsync();
    }

    public async Task<List<CorporateCustomerSupplier>> GetListAsync()
    {
        return await _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id).ToListAsync();
    }

    public async Task<int> InsertAsync(CorporateCustomerSupplier corporateCustomerSupplier)
    {
        await _repository.AddAsync(corporateCustomerSupplier);
        return corporateCustomerSupplier.Id;
    }

    public async Task UpdateAsync(CorporateCustomerSupplier corporateCustomerSupplier)
    {
        await _repository.UpdateAsync(corporateCustomerSupplier);
    }
}
