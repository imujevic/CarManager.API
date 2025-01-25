using Contract.Account;

namespace Services.Abstractions;

public interface IOwnerService
{
    Task<IEnumerable<OwnerDto>> GetAll(CancellationToken cancellationToken = default);

    Task<OwnerDto> GetById(int ownerId, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Create(CreateOwnerDto ownerDto, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Update(int ownerId, UpdateOwnerDto ownerDto, CancellationToken cancellationToken = default);

    Task Delete(int ownerId, CancellationToken cancellationToken = default);
}
