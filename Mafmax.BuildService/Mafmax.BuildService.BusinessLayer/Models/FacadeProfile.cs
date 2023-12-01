namespace Mafmax.BuildService.BusinessLayer.Models;

/// <summary>
/// Профиль фасада здания.
/// </summary>
/// <param name="Corners">Вершины многоугольника, представляющего фасад.</param>
public record FacadeProfile(Point[] Corners); 