using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZeusApp.Application.Interfaces.Repositories;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Infrastructure.Repositories;

public class SalesInvoiceRepository : ISalesInvoiceRepository
{
    private readonly IRepositoryAsync<SalesInvoice> _repository;

    public SalesInvoiceRepository(IRepositoryAsync<SalesInvoice> repository)
    {
        _repository = repository;
    }

    public IQueryable<SalesInvoice> SalesInvoices => _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id);

    public async Task DeleteAsync(SalesInvoice salesInvoice)
    {
        salesInvoice.Status = -1;
        await _repository.UpdateAsync(salesInvoice);
        //await _repository.DeleteAsync(salesInvoice);
    }

    public async Task<SalesInvoice> GetByIdAsync(int salesInvoiceId)
    {
        return await _repository.Entities.Where(p => p.Id == salesInvoiceId & p.Status != -1).FirstOrDefaultAsync();
    }

    public async Task<List<SalesInvoice>> GetListAsync()
    {
        return await _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id).ToListAsync();
    }

    public async Task<int> InsertAsync(SalesInvoice salesInvoice)
    {
        await _repository.AddAsync(salesInvoice);
        return salesInvoice.Id;
    }

    public async Task UpdateAsync(SalesInvoice salesInvoice)
    {
        await _repository.UpdateAsync(salesInvoice);
    }
}
