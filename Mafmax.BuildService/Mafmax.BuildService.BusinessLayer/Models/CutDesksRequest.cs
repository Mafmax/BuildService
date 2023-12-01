namespace Mafmax.BuildService.BusinessLayer.Models;

/// <summary>
/// Запрос на раскройку фасадных панелей.
/// </summary>
/// <param name="Desks">Массив панелей, которые нужно получить после раскройки.</param>
public record CutDesksRequest(Desk[] Desks);