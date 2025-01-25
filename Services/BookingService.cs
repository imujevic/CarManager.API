using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Services
{
    public class BookingService(IRepositoryManager repositoryManager) : IBookingService
    {
        public async Task<GeneralResponseDto> Create(BookingCreateDto BookingDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var Booking = BookingDto.Adapt<Booking>();
                repositoryManager.BookingRepository.CreateBooking(Booking);
                var rowsAffected = await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (rowsAffected != 1)
                {
                    return new GeneralResponseDto
                    {
                        IsSuccess = false,
                        Message = "Error!"
                    };
                }

                return new GeneralResponseDto { Message = "Success!" };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task Delete(int BookingId, CancellationToken cancellationToken = default)
        {
            var Booking = await repositoryManager.BookingRepository.GetById(BookingId, cancellationToken);
            repositoryManager.BookingRepository.DeleteBooking(Booking, cancellationToken);
            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<BookingDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var Bookings = await repositoryManager.BookingRepository.GetAll(cancellationToken);
            return Bookings.Adapt<IEnumerable<BookingDto>>();
        }

        public async Task<BookingDto> GetById(int BookingId, CancellationToken cancellationToken = default)
        {
            var Booking = await repositoryManager.BookingRepository.GetById(BookingId, cancellationToken);
            return Booking.Adapt<BookingDto>();
        }

        public async Task<GeneralResponseDto> Update(int BookingId, BookingUpdateDto BookingDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingBooking = await repositoryManager.BookingRepository.GetById(BookingId, cancellationToken);
                if (existingBooking == null)
                    return new GeneralResponseDto { IsSuccess = false, Message = "Booking not found." };

                BookingDto.Adapt(existingBooking);

                repositoryManager.BookingRepository.UpdateBooking(existingBooking);
                var res = await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (res != 1)
                    return new GeneralResponseDto { IsSuccess = false };

                return new GeneralResponseDto { Message = "Success!" };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
