using Mafmax.BuildService.BusinessLayer.Models;

namespace Mafmax.BuildService.BusinessLayer.Services.Facade;

/// <summary>
/// Содержит методы для проведения расчетов, связанных с фасадом.
/// </summary>
public interface IFacadeCalculationService
{
    /// <summary>
    /// Вычисляет количество и длины панелей для покрытия фасада.
    /// </summary>
    /// <param name="facadeProfile">Профиль фасада.</param>
    FacadeCoverageCalculationResult CalculateFacadeCoverage(FacadeProfile facadeProfile);

    /// <summary>
    /// Получает информацию о разрезах панелей минимизируя количество отходов.
    /// </summary>
    /// <param name="desks">Панели, которые нужно получить в итоге.</param>
    CutDesksResult CutDesks(Desk[] desks);
}