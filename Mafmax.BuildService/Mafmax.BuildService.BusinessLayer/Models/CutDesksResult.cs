namespace Mafmax.BuildService.BusinessLayer.Models;

/// <summary>
/// Результат раскройки фасадных панелей.
/// </summary>
/// <param name="Parts">Массив панелей с информацией о разрезах, которые необходимо совершить.</param>
public record CutDesksResult(CuttedDesk[] Parts);