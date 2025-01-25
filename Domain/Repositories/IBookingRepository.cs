using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IBookingRepository : IRepositoryBase<Booking>
    {
        Task<IEnumerable<Booking>> GetAll(CancellationToken cancellationToken = default);

        Task<Booking> GetById(int bookingId, CancellationToken cancellationToken = default);

        void CreateBooking(Booking booking, CancellationToken cancellationToken = default);

        void DeleteBooking(Booking booking, CancellationToken cancellationToken = default);

        void UpdateBooking(Booking booking, CancellationToken cancellationToken = default);
    }
}
