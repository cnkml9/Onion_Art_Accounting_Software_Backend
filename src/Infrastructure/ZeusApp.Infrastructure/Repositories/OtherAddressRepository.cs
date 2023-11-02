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
public class OtherAddressRepository : IOtherAddressRepository
{
    private readonly IRepositoryAsync<OtherAddress> _repository;

    public OtherAddressRepository(IRepositoryAsync<OtherAddress> repository)
    {
        _repository = repository;
    }

    public IQueryable<OtherAddress> OtherAddresses => _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id);

    public async Task DeleteAsync(OtherAddress otherAddress)
    {
        otherAddress.Status = -1;
        await _repository.UpdateAsync(otherAddress);
    }

    public async Task<OtherAddress> GetByIdAsync(int otherAddressId)
    {
        return await _repository.Entities.Where(p => p.Id == otherAddressId && p.Status != -1).FirstOrDefaultAsync();
    }

    public async Task<List<OtherAddress>> GetListAsync()
    {
        return await _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id).ToListAsync();
    }

    public async Task<int> InsertAsync(OtherAddress otherAddress)
    {
        await _repository.AddAsync(otherAddress);
        return otherAddress.Id;
    }

    public async Task UpdateAsync(OtherAddress otherAddress)
    {
        await _repository.UpdateAsync(otherAddress);
    }
}

