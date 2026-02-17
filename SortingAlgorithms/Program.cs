// -------------------------------------------------------------------------
// <copyright file="Program.cs" company="Bryan Franke">
// Copyright (c) Bryan Franke. All rights reserved.
// </copyright>
// <summary>
// Defines the application entry point and initializes the program.
// </summary>
// -------------------------------------------------------------------------
namespace SortingAlgorithms
{
  /// <summary>
  /// Application entry point. Creates a SortVisualizer instance and invokes
  /// its Start method to run the sorting animation workflow.
  /// </summary>
  internal class Program
  {
    private static void Main(string[] args)
    {
      SortVisualizer sortVisual = new SortVisualizer();
      sortVisual.Start();
    }
  }
}
