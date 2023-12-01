using Mafmax.BuildService.BusinessLayer.Services.Facade;
using Microsoft.Extensions.DependencyInjection;

namespace Mafmax.BuildService.BusinessLayer.Extensions;

/// <summary>
/// Класс с методами расширения для <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Регистрирует сервисы из сборки.
    /// </summary>
    public static IServiceCollection AddBusinessLayer(this IServiceCollection services) => 
        services.AddScoped<IFacadeCalculationService, FacadeCalculationService>();
} 