﻿using System.Diagnostics;

namespace Mafmax.BuildService.BusinessLayer.Models;

/// <summary>
/// Точка в двумерном пространстве.
/// </summary>
[DebuggerDisplay("{X}, {Y}")]
public struct Point
{
    /// <summary>
    /// Координата по оси абсцисс.
    /// </summary>
    public int X { get; set; } 

    /// <summary>
    /// Координата по оси ординат.
    /// </summary>
    public int Y { get; set; } 
}