global using Contract;
global using Domain.Entities;
global using Domain.Repositories;
global using Mapster;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.Extensions.Configuration;
global using Microsoft.IdentityModel.Tokens;
global using Services.Abstractions;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using System.Text;
using System.Security.Principal;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAccountService> _lazyAccountService;
        private readonly Lazy<ICarService> _lazyCarService;
        private readonly Lazy<IOwnerService> _lazyOwnerService;
        private readonly Lazy<IServiceRecordService> _lazyServiceRecordService;
        private readonly Lazy<IInspectionService> _lazyInspectionService;
        private readonly Lazy<IBookingService> _lazyBookingService;
        private readonly Lazy<IServiceCenterService> _lazyServiceCenterService;

        public ServiceManager(
            IRepositoryManager repositoryManager,
            UserManager<Account> userManager,
            RoleManager<AccountRole> roleManager,
            ITokenService tokenService)
        {
            _lazyAccountService = new(() => new AccountService(repositoryManager, userManager, roleManager, tokenService));
            _lazyCarService = new(() => new CarService(repositoryManager));
            _lazyOwnerService = new(() => new OwnerService(repositoryManager));
            _lazyServiceRecordService = new(() => new ServiceRecordService(repositoryManager));
            _lazyInspectionService = new(() => new InspectionService(repositoryManager));
            _lazyBookingService = new(() => new BookingService(repositoryManager));
            _lazyServiceCenterService = new(() => new ServiceCenterService(repositoryManager));
        }

        public IAccountService AccountService => _lazyAccountService.Value;
        public ICarService CarService => _lazyCarService.Value;
        public IOwnerService OwnerService => _lazyOwnerService.Value;
        public IServiceRecordService ServiceRecordService => _lazyServiceRecordService.Value;
        public IInspectionService InspectionService => _lazyInspectionService.Value;
        public IBookingService BookingService => _lazyBookingService.Value;
        public IServiceCenterService ServiceCenterService => _lazyServiceCenterService.Value;
    }
}
