using Domain.Entities;

namespace Domain.Repositories;

public interface IInspectionRepository : IRepositoryBase<Inspection>
{
    Task<IEnumerable<Inspection>> GetAll(CancellationToken cancellationToken = default);

    Task<Inspection> GetById(int inspectionId, CancellationToken cancellationToken = default);

    void CreateInspection(Inspection inspection, CancellationToken cancellationToken = default);

    void DeleteInspection(Inspection inspection, CancellationToken cancellationToken = default);

    void UpdateInspection(Inspection inspection, CancellationToken cancellationToken = default);
}