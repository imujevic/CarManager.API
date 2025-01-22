using Domain.Entities;

namespace Domain.Repositories;

public interface IOrderItemRepository : IRepositoryBase<ServiceRecord>
{
    Task<IEnumerable<ServiceRecord>> GetAll(CancellationToken cancellationToken = default);

    Task<IEnumerable<ServiceRecord>> GetByOrderId(int orderId, CancellationToken cancellationToken = default);

    Task<ServiceRecord> GetById(int orderItemId, CancellationToken cancellationToken = default);

    void CreateOrderItem(ServiceRecord orderItem, CancellationToken cancellationToken = default);

    void DeleteOrderItem(ServiceRecord orderItem, CancellationToken cancellationToken = default);

    void UpdateOrderItem(ServiceRecord orderItem, CancellationToken cancellationToken = default);
}