using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class BookingRepository(DataContext dataContext) : RepositoryBase<Booking>(dataContext), IBookingRepository
{
    public void CreateBooking(Booking booking, CancellationToken cancellationToken = default)
        => Create(booking);

    public void DeleteBooking(Booking booking, CancellationToken cancellationToken = default)
        => Delete(booking);

    public void UpdateBooking(Booking booking, CancellationToken cancellationToken = default)
        => Update(booking);

    public async Task<IEnumerable<Booking>> GetAll(CancellationToken cancellationToken = default)
    {
        return await FindAll().ToListAsync(cancellationToken);
    }

    public async Task<Booking> GetById(int bookingId, CancellationToken cancellationToken = default)
    {
        return await FindByCondition(b => b.Id == bookingId)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
