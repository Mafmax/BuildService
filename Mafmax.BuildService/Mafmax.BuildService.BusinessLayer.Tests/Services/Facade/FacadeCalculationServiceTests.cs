using FluentAssertions;
using Mafmax.BuildService.BusinessLayer.Models;
using Mafmax.BuildService.BusinessLayer.Services.Facade;
using Mafmax.BuildService.BusinessLayer.Utils;

namespace Mafmax.BuildService.BusinessLayer.Tests.Services.Facade;

public class FacadeCalculationServiceTests
{
    private const int DESK_HEIGHT = DeskParameters.DeskLength;
    private const int DESK_WIDTH = DeskParameters.DeskWidth;
    private const int ZERO = 0;

    [Fact]
    public void CalculateFacadeConverage_WithNotIntegerDesksCount_ShouldReturnFullCoverageResult()
    {
        const int appendix = 1;

        // Arrange
        var facade = CreateProfile((ZERO, ZERO), (ZERO, DESK_HEIGHT), (DESK_WIDTH + appendix, DESK_HEIGHT), (DESK_WIDTH + appendix, ZERO));
        var sut = GetCalculationService();

        // Act
        var desks = sut.CalculateFacadeCoverage(facade).Desks;
        var desksCount = desks.Length;
        var firstDeskLength = desks.FirstOrDefault()?.Length;
         
        // Assert
        desksCount.Should().Be(2);
        firstDeskLength.Should().Be(DESK_HEIGHT, 
            because: "Если фасад не покрывается полностью целыми панелями, то должен учитываться участок фасада, ширина которого меньше ширины панели.");
    }

    [Fact]
    public void CalculateFacadeConverage_WithQuadShape_ShouldReturnDesksWithFacadeWidthLength()
    {
        // Arrange
        const int facadeHeight = 1;
        var facade = CreateProfile((ZERO, ZERO), (ZERO, facadeHeight), (DESK_WIDTH, facadeHeight), (DESK_WIDTH, ZERO));
        var sut = GetCalculationService();

        // Act
        var desks = sut.CalculateFacadeCoverage(facade).Desks;
        var desksCount = desks.Length;
        var firstDeskLength = desks.FirstOrDefault()?.Length;

        // Assert
        desksCount.Should().Be(1);
        firstDeskLength.Should().Be(facadeHeight,
            because: "Если панель больше фасада, то должна возвращаться длина равная высоте фасада.");
    }

    [Fact]
    public void CalculateFacadeConverage_WithFacadeWithPeak_ShouldCoverPeak()
    {
        // Arrange
        const int peakX = DESK_WIDTH / 2;
        var facade = CreateProfile((ZERO, ZERO), (peakX, DESK_HEIGHT), (DESK_WIDTH, ZERO));
        var sut = GetCalculationService();

        // Act
        var desks = sut.CalculateFacadeCoverage(facade).Desks;
        var desksCount = desks.Length;
        var firstDeskLength = desks.FirstOrDefault()?.Length;

        // Assert
        desksCount.Should().Be(1);
        firstDeskLength.Should().Be(DESK_HEIGHT,
            because: "Панель должна покрывать углы.");
    }

    private static IFacadeCalculationService GetCalculationService() => new FacadeCalculationService();

    private static FacadeProfile CreateProfile(params (int X, int Y)[] coords) =>
        new(coords.Select(coord => new Point { X = coord.X, Y = coord.Y }).ToArray());
}