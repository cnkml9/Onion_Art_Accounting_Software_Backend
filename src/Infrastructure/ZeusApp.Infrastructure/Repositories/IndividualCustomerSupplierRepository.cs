using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZeusApp.Application.Interfaces.Repositories;
using ZeusApp.Domain.Entities.Catalog;
using ZeusApp.Infrastructure.DbContexts;

namespace ZeusApp.Infrastructure.Repositories;
public class IndividualCustomerSupplierRepository : IIndividualCustomerSupplierRepository
{
    private readonly IRepositoryAsync<IndividualCustomerSupplier> _repository;
    private readonly ApplicationDbContext _context;
    public IndividualCustomerSupplierRepository(IRepositoryAsync<IndividualCustomerSupplier> repository, ApplicationDbContext context)
    {
        _repository = repository;
        _context = context;
    }

    public IQueryable<IndividualCustomerSupplier> IndividualCustomerSuppliers => _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id);

    public async Task DeleteAsync(IndividualCustomerSupplier individualCustomerSupplier)
    {
        individualCustomerSupplier.Status = -1;
        await _repository.UpdateAsync(individualCustomerSupplier);
    }

    public async Task<IndividualCustomerSupplier> GetByIdAsync(int individualCustomerSupplierId)
    {
        return await _repository.Entities
            .Include(x => x.Contact)
           .Include(x => x.Banks)
           .Include(x => x.OtherAddresses)
          .Include(x => x.RelatedPersons)
            .Where(p => p.Id == individualCustomerSupplierId && p.Status != -1).FirstOrDefaultAsync();
    }

    public async Task<List<IndividualCustomerSupplier>> GetListAsync()
    {
        return await _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id).ToListAsync();
    }

    public async Task<int> InsertAsync(IndividualCustomerSupplier individualCustomerSupplier)
    {
        await _repository.AddAsync(individualCustomerSupplier);
        return individualCustomerSupplier.Id;
    }

  

    public async Task UpdateAsync(IndividualCustomerSupplier individualCustomerSupplier)
    {

        await _repository.UpdateAsync(individualCustomerSupplier);
    }
}

