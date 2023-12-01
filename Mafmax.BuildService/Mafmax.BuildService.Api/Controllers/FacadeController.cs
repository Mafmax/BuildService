using Mafmax.BuildService.BusinessLayer.Models;
using Mafmax.BuildService.BusinessLayer.Services.Facade;
using Microsoft.AspNetCore.Mvc;

namespace Mafmax.BuildService.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class FacadeController(IFacadeCalculationService facadeCalculationService) : ControllerBase
{
    /// <summary>
    /// Вычисляет количество и длины фасадных панелей для полного покрытия фасада здания.
    /// </summary>
    /// <param name="facadeProfile">Описание фасада зданиЯ.</param>
    [HttpPost("calculateCoverage")]
    public ValueTask<FacadeCoverageCalculationResult> CalculateFacadeCoverage([FromBody] FacadeProfile facadeProfile) =>
        ValueTask.FromResult(facadeCalculationService.CalculateFacadeCoverage(facadeProfile));

    /// <summary>
    /// Раскраивает панели, минимизируя количество обрезков.
    /// </summary>
    /// <param name="request">Запрос, содержащий описание досок, которые нужно получить в результате раскройки.</param>
    [HttpPost("cutDesks")]
    public ValueTask<CutDesksResult> CutDesks([FromBody] CutDesksRequest request) => 
        ValueTask.FromResult(facadeCalculationService.CutDesks(request.Desks));
}
