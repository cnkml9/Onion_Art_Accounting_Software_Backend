using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Application.Interfaces.Repositories;

public interface ISalesInvoiceRepository
{
    IQueryable<SalesInvoice> SalesInvoices { get; }
    Task<List<SalesInvoice>> GetListAsync();
    Task<SalesInvoice> GetByIdAsync(int salesInvoiceId);
    Task<int> InsertAsync(SalesInvoice salesInvoice);
    Task UpdateAsync(SalesInvoice salesInvoice);
    Task DeleteAsync(SalesInvoice salesInvoice);
}
