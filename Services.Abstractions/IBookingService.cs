namespace Services.Abstractions;

public interface IBookingService
{
    Task<IEnumerable<BookingDto>> GetAll(CancellationToken cancellationToken = default);

    Task<BookingDto> GetById(int bookingId, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Create(CreateBookingDto bookingDto, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Update(int bookingId, UpdateBookingDto bookingDto, CancellationToken cancellationToken = default);

    Task Delete(int bookingId, CancellationToken cancellationToken = default);
}
