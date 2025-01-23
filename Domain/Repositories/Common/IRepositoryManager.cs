namespace Domain.Repositories
{
    public interface IRepositoryManager
    {
        IAccountRepository AccountRepository { get; }
        IProductRepository ProductRepository { get; }
        ICarRepository CategoryRepository { get; }
        IUnitOfWork UnitOfWork { get; }
        IOrderRepository OrderRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
    }
}