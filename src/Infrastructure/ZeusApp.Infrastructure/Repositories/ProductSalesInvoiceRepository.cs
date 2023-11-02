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
public class ProductSalesInvoiceRepository : IProductSalesInvoiceRepository
{
    private readonly IRepositoryAsync<ProductSalesInvoice> _repository;

    public ProductSalesInvoiceRepository(IRepositoryAsync<ProductSalesInvoice> repository)
    {
        _repository = repository;
    }

    public IQueryable<ProductSalesInvoice> ProductSalesInvoices => _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id);

    public async Task DeleteAsync(ProductSalesInvoice productSalesInvoice)
    {
        productSalesInvoice.Status = -1;
        await _repository.UpdateAsync(productSalesInvoice);
    }

    public async Task<ProductSalesInvoice> GetByIdAsync(int productSalesInvoiceId)
    {
        return await _repository.Entities.Where(p => p.Id == productSalesInvoiceId && p.Status != -1).FirstOrDefaultAsync();
    }

    public async Task<List<ProductSalesInvoice>> GetListAsync()
    {
        return await _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id).ToListAsync();
    }

    public async Task<int> InsertAsync(ProductSalesInvoice productSalesInvoice)
    {
        await _repository.AddAsync(productSalesInvoice);
        return productSalesInvoice.Id;
    }

    public async Task UpdateAsync(ProductSalesInvoice productSalesInvoice)
    {
        await _repository.UpdateAsync(productSalesInvoice);
    }
}
