namespace Mafmax.BuildService.BusinessLayer.Models;

/// <summary>
/// Результат операции по вычислению количества панелей для покрытия фасада.
/// </summary>
/// <param name="Desks">Массив панелей, необходимых для покрытия.</param>
public record FacadeCoverageCalculationResult(Desk[] Desks); 