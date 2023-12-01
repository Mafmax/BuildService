using Mafmax.BuildService.BusinessLayer.Models;
using Mafmax.BuildService.BusinessLayer.Services.Facade;
using Microsoft.AspNetCore.Mvc;

namespace Mafmax.BuildService.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class FacadeController(IFacadeCalculationService facadeCalculationService) : ControllerBase
{
    /// <summary>
    /// ¬ычисл€ет количество и длины фасадных панелей дл€ полного покрыти€ фасада здани€.
    /// </summary>
    /// <param name="facadeProfile">ќ писание фасада здани€.</param>
    [HttpPost("calculateCoverage")]
    public ValueTask<FacadeCoverageCalculationResult> CalculateFacadeCoverage([FromBody] FacadeProfile facadeProfile) =>
        ValueTask.FromResult(facadeCalculationService.CalculateFacadeCoverage(facadeProfile));

    /// <summary>
    /// –аскраивает панели, минимизиру€ количество обрезков.
    /// </summary>
    /// <param name="request">«апрос, содержащий описание досок, которые нужно получить в результате раскройки.</param>
    [HttpPost("cutDesks")]
    public ValueTask<CutDesksResult> CutDesks([FromBody] CutDesksRequest request) => 
        ValueTask.FromResult(facadeCalculationService.CutDesks(request.Desks));
}
