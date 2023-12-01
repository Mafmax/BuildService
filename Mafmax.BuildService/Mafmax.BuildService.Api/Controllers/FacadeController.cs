using Mafmax.BuildService.BusinessLayer.Models;
using Mafmax.BuildService.BusinessLayer.Services.Facade;
using Microsoft.AspNetCore.Mvc;

namespace Mafmax.BuildService.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class FacadeController(IFacadeCalculationService facadeCalculationService) : ControllerBase
{
    /// <summary>
    /// ��������� ���������� � ����� �������� ������� ��� ������� �������� ������ ������.
    /// </summary>
    /// <param name="facadeProfile">� ������� ������ ������.</param>
    [HttpPost("calculateCoverage")]
    public ValueTask<FacadeCoverageCalculationResult> CalculateFacadeCoverage([FromBody] FacadeProfile facadeProfile) =>
        ValueTask.FromResult(facadeCalculationService.CalculateFacadeCoverage(facadeProfile));

    /// <summary>
    /// ����������� ������, ����������� ���������� ��������.
    /// </summary>
    /// <param name="request">������, ���������� �������� �����, ������� ����� �������� � ���������� ���������.</param>
    [HttpPost("cutDesks")]
    public ValueTask<CutDesksResult> CutDesks([FromBody] CutDesksRequest request) => 
        ValueTask.FromResult(facadeCalculationService.CutDesks(request.Desks));
}
