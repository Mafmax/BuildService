using Mafmax.BuildService.BusinessLayer.Services.Facade;
using Microsoft.Extensions.DependencyInjection;

namespace Mafmax.BuildService.BusinessLayer.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLayer(this IServiceCollection services) => 
        services.AddScoped<IFacadeCalculationService, FacadeCalculationService>();
}