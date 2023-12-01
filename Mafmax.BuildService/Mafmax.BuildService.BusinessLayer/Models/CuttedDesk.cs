namespace Mafmax.BuildService.BusinessLayer.Models;

/// <summary>
/// Раскроенная панель.
/// </summary>
/// <param name="Parts">Массив длин, которые нужно отрезать от исходной панели.</param>
public record CuttedDesk(int[] Parts);