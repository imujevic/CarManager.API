using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class InspectionRepository(DataContext dataContext) : RepositoryBase<Inspection>(dataContext), IInspectionRepository
{
    public void CreateInspection(Inspection inspection, CancellationToken cancellationToken = default)
        => Create(inspection);

    public void DeleteInspection(Inspection inspection, CancellationToken cancellationToken = default)
        => Delete(inspection);

    public void UpdateInspection(Inspection inspection, CancellationToken cancellationToken = default)
        => Update(inspection);

    public async Task<IEnumerable<Inspection>> GetAll(CancellationToken cancellationToken = default)
    {
        return await FindAll().ToListAsync(cancellationToken);
    }

    public async Task<Inspection> GetById(int inspectionId, CancellationToken cancellationToken = default)
    {
        return await FindByCondition(i => i.Id == inspectionId)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
