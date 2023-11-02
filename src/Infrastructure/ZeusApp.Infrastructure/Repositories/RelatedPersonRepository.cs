using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZeusApp.Application.Interfaces.Repositories;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Infrastructure.Repositories;

public class RelatedPersonRepository : IRelatedPersonRepository
{
    private readonly IRepositoryAsync<RelatedPerson> _repository;

    public RelatedPersonRepository(IRepositoryAsync<RelatedPerson> repository)
    {
        _repository = repository;
    }

    public IQueryable<RelatedPerson> RelatedPersons => _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id);

    public async Task DeleteAsync(RelatedPerson relatedPerson)
    {
        relatedPerson.Status = -1;
        await _repository.UpdateAsync(relatedPerson);
        //await _repository.DeleteAsync(relatedPerson);
    }

    public async Task<RelatedPerson> GetByIdAsync(int relatedPersonId)
    {
        return await _repository.Entities.Where(p => p.Id == relatedPersonId & p.Status != -1).FirstOrDefaultAsync();
    }

    public async Task<List<RelatedPerson>> GetListAsync()
    {
        return await _repository.Entities.Where(p => p.Status != -1).OrderBy(o => o.DisplayOrder).ThenBy(o => o.Id).ToListAsync();
    }

    public async Task<int> InsertAsync(RelatedPerson relatedPerson)
    {
        await _repository.AddAsync(relatedPerson);
        return relatedPerson.Id;
    }

    public async Task UpdateAsync(RelatedPerson relatedPerson)
    {
        await _repository.UpdateAsync(relatedPerson);
    }
}
