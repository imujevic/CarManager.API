global using Contract;
global using System.Security.Claims;

namespace Services.Abstractions
{
    public interface IServiceManager
    {
        IAccountService AccountService { get; }
        IOwnerService OwnerService { get; }
        ICarService CarService { get; }
        IServiceRecordService ServiceRecordService { get; }
        IInspectionService InspectionService { get; }
        IServiceCenterService ServiceCenterService { get; }
        IBookingService BookingService { get; }
    }

}