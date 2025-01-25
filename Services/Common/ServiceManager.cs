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

namespace Services;
{
    public class ServiceManager(
        IRepositoryManager repositoryManager,
        UserManager<Account> userManager,
        RoleManager<AccountRole> roleManager,
        ITokenService tokenService) : IServiceManager
    {
        private readonly Lazy<IAccountService> _lazyAccountService = new(() => new AccountService(repositoryManager, userManager, roleManager, tokenService));

        private readonly Lazy<ICarService> _lazyCarService = new(() => new CarService(repositoryManager));

        private readonly Lazy<IServiceRecordService> _lazyServiceRecordService = new(() => new ServiceRecordService(repositoryManager));

        private readonly Lazy<IInspectionService> _lazyInspectionService = new(() => new InspectionService(repositoryManager));

        private readonly Lazy<IBookingService> _lazyBookingService = new(() => new BookingService(repositoryManager));

        private readonly Lazy<IServiceCenterService> _lazyServiceCenterService = new(() => new ServiceCenterService(repositoryManager));

        public IAccountService AccountService => _lazyAccountService.Value;

        public ICarService CarService => _lazyCarService.Value;

        public ICarOwnerService CarOwnerService => _lazyCarOwnerService.Value;

        public IServiceRecordService ServiceRecordService => _lazyServiceRecordService.Value;

        public IInspectionService InspectionService => _lazyInspectionService.Value;

        public IBookingService BookingService => _lazyBookingService.Value;

        public IServiceCenterService ServiceCenterService => _lazyServiceCenterService.Value;
    }
}
