using Mafmax.BuildService.BusinessLayer.Models;

namespace Mafmax.BuildService.BusinessLayer.Services.Facade;

public interface IFacadeCalculationService
{
    FacadeCoverageCalculationResult CalculateFacadeCoverage(FacadeProfile facadeProfile);

    CutDesksResult CutDesks(Desk[] desks);
}