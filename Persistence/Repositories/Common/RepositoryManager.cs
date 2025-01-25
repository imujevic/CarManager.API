using Domain.Repositories;

namespace Persistence.Repositories
{
    public class RepositoryManager(DataContext dbContext) : IRepositoryManager
    {
        private readonly Lazy<IAccountRepository> _lazyAccountRepository = new(() => new AccountRepository(dbContext));
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork = new(() => new UnitOfWork(dbContext));
        private readonly Lazy<ICarRepository> _lazyCarRepository = new(() => new CarRepository(dbContext));
        private readonly Lazy<IOwnerRepository> _lazyOwnerRepository = new(() => new OwnerRepository(dbContext));
        private readonly Lazy<IServiceRecordRepository> _lazyServiceRecordRepository = new(() => new ServiceRecordRepository(dbContext));
        private readonly Lazy<IInspectionRepository> _lazyInspectionRepository = new(() => new InspectionRepository(dbContext));
        private readonly Lazy<IBookingRepository> _lazyBookingRepository = new(() => new BookingRepository(dbContext));
        private readonly Lazy<IServiceCenterRepository> _lazyServiceCenterRepository = new(() => new ServiceCenterRepository(dbContext));

        public IAccountRepository AccountRepository => _lazyAccountRepository.Value;
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
        public ICarRepository CarRepository => _lazyCarRepository.Value;
        public IOwnerRepository OwnerRepository => _lazyOwnerRepository.Value;
        public IServiceRecordRepository ServiceRecordRepository => _lazyServiceRecordRepository.Value;
        public IInspectionRepository InspectionRepository => _lazyInspectionRepository.Value;
        public IBookingRepository BookingRepository => _lazyBookingRepository.Value;
        public IServiceCenterRepository ServiceCenterRepository => _lazyServiceCenterRepository.Value;
    }
}
