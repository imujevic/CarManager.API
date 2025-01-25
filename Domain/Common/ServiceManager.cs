﻿
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

namespace Services
{
    public class ServiceManager(
        IRepositoryManager repositoryManager,
        UserManager<Account> userManager,
        RoleManager<AccountRole> roleManager,
        ITokenService tokenService) : IServiceManager
    {
        private readonly Lazy<IAccountService> _lazyAccountService = new(() => new AccountService(repositoryManager, userManager, roleManager, tokenService));

        private readonly Lazy<IProductService> _lazyProductServicee = new(() => new ProductService(repositoryManager));

        private readonly Lazy<ICategoryService> _lazyCategoryService = new(() => new CategoryService(repositoryManager));

        private readonly Lazy<IOrderService> _lazyOrderService = new(() => new OrderService(repositoryManager));

        private readonly Lazy<IOrderItemService> _lazyOrderItemService = new(() => new OrderItemService(repositoryManager));

        public IAccountService AccountService => _lazyAccountService.Value;

        public IProductService ProductService => _lazyProductServicee.Value;

        public ICategoryService CategoryService => _lazyCategoryService.Value;

        public IOrderService OrderService => _lazyOrderService.Value;

        public IOrderItemService OrderItemService => _lazyOrderItemService.Value;
    }
}