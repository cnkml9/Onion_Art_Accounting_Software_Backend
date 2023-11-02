using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZeusApp.Application.Interfaces.Repositories;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Infrastructure.Repositories;

public class SalesInvoiceCategoryRepository : ISalesInvoiceCategoryRepository
{
    private readonly IRepositoryAsync<SalesInvoiceCategory> _repository;

    public SalesInvoiceCategoryRepository(IRepositoryAsync<SalesInvoiceCategory> repository)
    {
        _repository = repository;
    }

    public IQueryable<SalesInvoiceCategory> SalesInvoiceCategories => _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id);

    public async Task DeleteAsync(SalesInvoiceCategory salesInvoiceCategory)
    {
        salesInvoiceCategory.Status = -1;
        await _repository.UpdateAsync(salesInvoiceCategory);
        //await _repository.DeleteAsync(salesInvoiceCategory);
    }

    public async Task<SalesInvoiceCategory> GetByIdAsync(int salesInvoiceCategoryId)
    {
        return await _repository.Entities.Where(p => p.Id == salesInvoiceCategoryId & p.Status != -1).FirstOrDefaultAsync();
    }

    public async Task<List<SalesInvoiceCategory>> GetListAsync()
    {
        return await _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id).ToListAsync();
    }

    public async Task<int> InsertAsync(SalesInvoiceCategory salesInvoiceCategory)
    {
        await _repository.AddAsync(salesInvoiceCategory);
        return salesInvoiceCategory.Id;
    }

    public async Task UpdateAsync(SalesInvoiceCategory salesInvoiceCategory)
    {
        await _repository.UpdateAsync(salesInvoiceCategory);
    }
}
