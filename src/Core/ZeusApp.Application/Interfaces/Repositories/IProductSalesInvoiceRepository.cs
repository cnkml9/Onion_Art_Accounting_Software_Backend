using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Application.Interfaces.Repositories;

public interface IProductSalesInvoiceRepository
{
    IQueryable<ProductSalesInvoice> ProductSalesInvoices { get; }
    Task<List<ProductSalesInvoice>> GetListAsync();
    Task<ProductSalesInvoice> GetByIdAsync(int productSalesInvoiceId);
    Task<int> InsertAsync(ProductSalesInvoice productSalesInvoice);
    Task UpdateAsync(ProductSalesInvoice productSalesInvoice);
    Task DeleteAsync(ProductSalesInvoice productSalesInvoice);
}
