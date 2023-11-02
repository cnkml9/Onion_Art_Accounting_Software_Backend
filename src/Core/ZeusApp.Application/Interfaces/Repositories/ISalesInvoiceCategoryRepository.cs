using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Application.Interfaces.Repositories;

public interface ISalesInvoiceCategoryRepository
{
    IQueryable<SalesInvoiceCategory> SalesInvoiceCategories { get; }
    Task<List<SalesInvoiceCategory>> GetListAsync();
    Task<SalesInvoiceCategory> GetByIdAsync(int salesInvoiceCategoryId);
    Task<int> InsertAsync(SalesInvoiceCategory salesInvoiceCategory);
    Task UpdateAsync(SalesInvoiceCategory salesInvoiceCategory);
    Task DeleteAsync(SalesInvoiceCategory salesInvoiceCategory);
}
