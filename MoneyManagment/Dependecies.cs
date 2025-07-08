
using Application.Abstractions.IAssetService;
using Application.Abstractions.ILiabilityService;
using Application.Dtos;
using Application.Features.Create.Assets;
using Application.Features.Create.Liability;
using Application.Services.Assets;
using Application.Services.Liabilitys;
using Domain.Abstractions;
using FastEndpoints;
using Infrastructure.DB;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MoneyManagment
{
    public static class Dependecies
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            // Register your services here
            services.AddScoped<CommandHandler<AssetCommand,AssetDto>,AssetCommandHandler>();
            //services.AddScoped<LiabilityCommandHandler>();
            
            services.AddScoped<IAssetServiceCreate, AssetService>();
            services.AddScoped<ILiabilityServiceCreate, LiabilityService>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.TryAddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
