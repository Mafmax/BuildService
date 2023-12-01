using Mafmax.BuildService.BusinessLayer.Models;

namespace Mafmax.BuildService.BusinessLayer.Services.Facade;

public class FacadeCalculationService : IFacadeCalculationService
{
    private const int DESK_HEIGHT = 13500;
    private const int DESK_WIDTH = 500;

    /// <inheritdoc />
    public FacadeCoverageCalculationResult CalculateFacadeCoverage(FacadeProfile facadeProfile)
    {
        var corners = facadeProfile.Corners.AsSpan();
        var (leftmostXIndex, rightmostXIndex) = GetMarginalCoordXIndices(ref corners);
        var (leftmostX, rightmostX) = (corners[leftmostXIndex].X, corners[rightmostXIndex].X);
        var panelsCount = (int)Math.Ceiling(Math.Abs(leftmostX - rightmostX) * 1.0 / DESK_WIDTH);
        var (lastTopIndex, lastBottomIndex) = (leftmostXIndex, leftmostXIndex);
        var desks = new Desk[panelsCount];

        for (var panelIndex = 0; panelIndex < panelsCount; panelIndex++)
        {
            var leftSideX = panelIndex * DESK_WIDTH + leftmostX;
            var rightSideX = Math.Min(leftSideX + DESK_WIDTH, rightmostX);
            var deskLength = GetDeskLength(ref corners, ref lastBottomIndex, ref lastTopIndex, leftSideX, rightSideX);
            desks[panelIndex] = new Desk(deskLength);
        }

        return new FacadeCoverageCalculationResult(desks);
    }

    /// <inheritdoc />
    public CutDesksResult CutDesks(Desk[] desks)
    {
        throw new NotImplementedException();
    }

    private static int GetDeskLength(ref Span<Point> corners, ref int lastBottomIndex, ref int lastTopIndex, int leftSideX, int rightSideX)
    {
        var low = GetDeskEndY(ref corners, ref lastBottomIndex, leftSideX, rightSideX, top: false);
        var high = GetDeskEndY(ref corners, ref lastTopIndex, leftSideX, rightSideX, top: true);
        var deskLength = Math.Abs(high - low);

        return deskLength;
    }

    private static int GetDeskEndY(ref Span<Point> corners, ref int lastCoveredCornerIndex, int leftSide, int rightSide, bool top)
    {
        var startIndex = lastCoveredCornerIndex;
        var leftIntersectionPoint = GetIntersectionPoint(ref corners, ref lastCoveredCornerIndex, leftSide, top);
        var rightIntersectionPoint = GetIntersectionPoint(ref corners, ref lastCoveredCornerIndex, rightSide, top);

        var midPointEnd = leftIntersectionPoint.Y;
        
        for (var i = IncrementIndex(corners.Length, startIndex, top) ; i != lastCoveredCornerIndex; i = IncrementIndex(corners.Length, i, top))
        {
            var midCorner = corners[i];
            if (midCorner.X > rightSide)
            {
                break;
            }

            midPointEnd = top ? Math.Max(midPointEnd, midCorner.Y) : Math.Min(midPointEnd, midCorner.Y);
        }

        var rightY = rightIntersectionPoint.Y;
        var low = top ? Math.Max(midPointEnd, rightY) : Math.Min(midPointEnd, rightY);

        return low;
    }

    private static Point GetIntersectionPoint(ref Span<Point> corners, ref int lastCoveredCornerIndex, int x, bool top)
    {
        var nextIndex = lastCoveredCornerIndex;
        while (true)
        {
            var nextCorner = corners[nextIndex];

            if (nextCorner.X < x)
            {
                lastCoveredCornerIndex = nextIndex;
                nextIndex = IncrementIndex(corners.Length, lastCoveredCornerIndex, top);
                continue;
            }

            if (nextCorner.X == x)
            {
                lastCoveredCornerIndex = nextIndex;
                return nextCorner;
            }

            var lastCorner = corners[lastCoveredCornerIndex];
            var y = (nextCorner.Y - lastCorner.Y) * (x - lastCorner.X) / (nextCorner.X - lastCorner.X) + lastCorner.Y;

            return new Point { X = x, Y = y };
        }
    }

    private static (int LeftmostIndex, int RightmostIndex) GetMarginalCoordXIndices(ref Span<Point> corners)
    {
        var leftmostIndex = 0;
        var rightmostIndex = corners.Length - 1;
        for (var i = 0; i < corners.Length; i++)
        {
            var corner = corners[i];
            var leftCorner = corners[leftmostIndex];
            var rightCorner = corners[rightmostIndex];
            if (corner.X < leftCorner.X)
            {
                leftmostIndex = i;
            }

            if (corner.X > rightCorner.X)
            {
                rightmostIndex = i;
            }
        }

        return (leftmostIndex, rightmostIndex);
    }

    private static int IncrementIndex(int length, int index, bool clockwise) =>
        ((clockwise ? index + 1 : index - 1) + length) % length;
}