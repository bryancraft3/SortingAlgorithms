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
      Console.Clear();
      Console.WriteLine("============================================");
      Console.WriteLine("       Sorting Algorithms Visualizer       ");
      Console.WriteLine("============================================");
      Console.WriteLine("This program demonstrates several classic\n" +
                        "algorithms using an interactive console-\n" +
                        "based visualization.");
      Console.WriteLine("\nYou can watch how each algorithm\n" +
                        "manipulates the array step-by-step, compare\n" + 
                        "their behavior, and explore the\n" +
                        "implementation in the library.");
      Console.WriteLine("\nAlgorithms included:");
      Console.WriteLine(" - Bubble Sort");
      Console.WriteLine("\nPress Enter to continue...");
      Console.ReadLine();
      Console.Clear();
      sortVisual.Start();
    }
  }
}
