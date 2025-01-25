namespace Domain.Repositories
{
    public interface IRepositoryManager
    {
        IAccountRepository AccountRepository { get; }
        ICarRepository CarRepository { get; }
        IOwnerRepository OwnerRepository { get; }
        IServiceRecordRepository ServiceRecordRepository { get; }
        IInspectionRepository InspectionRepository { get; }
        IBookingRepository BookingRepository { get; }
        IServiceCenterRepository ServiceCenterRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
