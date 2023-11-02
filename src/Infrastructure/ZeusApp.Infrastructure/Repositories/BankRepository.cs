using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZeusApp.Application.Interfaces.Repositories;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Infrastructure.Repositories;
public class BankRepository : IBankRepository
{
    private readonly IRepositoryAsync<Bank> _repository;

    public BankRepository(IRepositoryAsync<Bank> repository)
    {
        _repository = repository;
    }

    public IQueryable<Bank> Banks => _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id);

    public async Task DeleteAsync(Bank bank)
    {
        bank.Status = -1;
        await _repository.UpdateAsync(bank);
        //await _repository.DeleteAsync(Bank);
    }

    public async Task<Bank> GetByIdAsync(int bankId)
    {
        return await _repository.Entities.Where(p => p.Id == bankId & p.Status != -1).FirstOrDefaultAsync();
    }

    public async Task<List<Bank>> GetListAsync()
    {
        return await _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id).ToListAsync();
    }

    public async Task<int> InsertAsync(Bank bank)
    {
        await _repository.AddAsync(bank);
        return bank.Id;
    }

    public async Task UpdateAsync(Bank bank)
    {
        await _repository.UpdateAsync(bank);
    }
}
