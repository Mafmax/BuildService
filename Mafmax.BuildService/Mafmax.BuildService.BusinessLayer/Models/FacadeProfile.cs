namespace Mafmax.BuildService.BusinessLayer.Models;

public record FacadeProfile(Point[] Corners);

public struct Point
{
    public int X { get; set; } 
    public int Y { get; set; } 
}