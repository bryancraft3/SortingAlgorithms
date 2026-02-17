// ----------------------------------------------------------------------------
// <copyright file="SortVisualizer.cs" company="Bryan Franke">
// Copyright (c) Bryan Franke. All rights reserved.
// </copyright>
// <summary>
// Coordinates and displays console-based visualizations of sorting algorithms.
// </summary>
// ----------------------------------------------------------------------------
namespace SortingAlgorithms
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public class SortVisualizer
  {
    /// <summary>
    /// Animates the Bubble Sort algorithm in the console by repeatedly drawing
    /// a vertical bar diagram representing the current state of the array.
    /// Axis labels are displayed beneath the bars, and the animation can be
    /// slowed down or stepped through interactively.
    /// </summary>
    /// <param name="array_int">
    /// The array of integers to be visualized and sorted. The original array
    /// is not modified; a cloned copy is used for the animation.
    /// </param>
    /// <param name="speed">
    /// The animation speed, expressed as updates per second. A value of 0 disables
    /// timed animation. Higher values result in faster updates.
    /// </param>
    /// <param name="stopAfterEachStep">
    /// If set to <c>true</c>, the animation pauses after each swap and waits for
    /// user input before continuing. If <c>false</c>, the animation proceeds
    /// automatically based on the specified speed.
    /// </param>
    /// <param name="color">
    /// The console background color used to draw the bars in the visualization.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the array is too large to be displayed withing the console window.
    /// Specifically, the array length must not exceed <c>Console.WindowHeight + 3</c>.
    /// </exception>
    /// <remarks>
    /// This method performs a visual Bubble Sort:
    /// <list type="bullet">
    /// <item><description>Determines bar width based on the maximum digit count.</description></item>
    /// <item><description>Draws the initial bar diagram and axis labels.</description></item>
    /// <item><description>Performs Bubble Sort, redrawing the diagram after each swap.</description></item>
    /// <item><description>Supports step-by-step mode or timed animation.</description></item>
    /// </list>
    /// The console is cleared and redrawn frequently, so this method is intended
    /// for visualization purposes rather than performance.
    /// </remarks>
    public static void BubbleSortAnimationWithAxisLabels(int[]? array_int, double speed, bool stopAfterEachStep, ConsoleColor color)
    {
      if (array_int == null)
      {
        throw new ArgumentNullException(nameof(array_int));
      }

      if (array_int.Length == 0)
      {
        throw new ArgumentException("Array must contain at least one element.", nameof(array_int));
      }

      if (speed <= 0 || speed > 1000)
      {
        throw new ArgumentOutOfRangeException(nameof(speed), "Parameter must be greater than 0 and less than or equal to 1000.");
      }

      if (!Enum.IsDefined(typeof(ConsoleColor), color))
      {
        throw new ArgumentOutOfRangeException(nameof(color), "Invalid console color.");
      }

      ConsoleUtils.SetCursorVisibility(false);

      int maxDigits = 0;
      int currentDigits = 0;
      for (int i = 0; i < array_int.Length; ++i)
      {
        currentDigits = array_int[i].ToString().Length;
        if (maxDigits < currentDigits)
        {
          maxDigits = currentDigits;
        }
      }

      int barWidth = maxDigits + 2;

      if (array_int.Length > Console.WindowHeight + 3)
      {
        throw new ArgumentOutOfRangeException(
          $"BubbeSortAnimation received invalid parameters. " +
          $"Length of array_int ({array_int.Length}) must be <= Console.WindowHeight + 3.");
      }

      ShapeRenderer sRenderer = new ShapeRenderer();
      int[] new_array_int = (int[])array_int.Clone();
      int n = new_array_int.Length;
      bool swapped = true;

      sRenderer.DrawVerticalBarDiagram(0, 9, array_int.Length, barWidth, new_array_int, color);
      DrawAxisLabels(array_int, barWidth);
      if (stopAfterEachStep)
      {
        Console.ReadLine();
      }

      while (swapped == true)
      {
        swapped = false;
        for (int i = 1; i <= n - 1; ++i)
        {
          if (new_array_int[i - 1] > new_array_int[i])
          {
            int temp = new_array_int[i - 1];
            new_array_int[i - 1] = new_array_int[i];
            new_array_int[i] = temp;
            swapped = true;
            Console.Clear();
            sRenderer.DrawVerticalBarDiagram(0, 9, array_int.Length, barWidth, new_array_int, color);
            DrawAxisLabels(new_array_int, barWidth);

            if (stopAfterEachStep)
            {
              Console.ReadLine();
            }
            else if (speed > 0.0)
            {
              Thread.Sleep((int)(1000 / speed));
            }
          }
        }

        n -= 1;
      }

      ConsoleUtils.SetCursorVisibility(true);
    }

    public void Start()
    {
      if (OperatingSystem.IsWindows() == false)
      {
        Console.Title = "SortingAlgorithms";
      }
      else
      {
        Console.Write("\u001b]0;SortingAlgorithms\u0007");
      }

      int[] unsortedArray = { 15, 0, 4, 36, 15, 20, 10 };

      // ShapeRenderer shapeRenderer = new ShapeRenderer();
      // ShapeRenderer.DrawRectangle(0, 0, 3, 3, (ConsoleColor)7);
      // ShapeRenderer.DrawFilledRectangle(1, 1, 3, 3, (ConsoleColor)7);
      // ShapeRenderer.DrawVerticalBar(0, Console.WindowHeight - 1, Console.WindowHeight, (ConsoleColor)7);
      // ShapeRenderer.DrawHorizontalBar(0, 0, Console.WindowWidth, (ConsoleColor)7);
      // ShapeRenderer.DrawVerticalBarDiagram(0, 9, 10, unordered_array, (ConsoleColor)7);
      Console.Clear();

      // BubbleSortAnimation(unsortedArray, 5, 4, false, (ConsoleColor)7);
      SortVisualizer.BubbleSortAnimationWithAxisLabels(unsortedArray, 5, true, (ConsoleColor)7);
    }

    /// <summary>
    /// Animates the Bubble Sort algorithm in the console by repeatedly drawing
    /// a vertical bar diagram representing the current state of the array.
    /// The animation can run automatically at a specified speed or pause after
    /// each swap for step-by-step visualization.
    /// </summary>
    /// <param name="array_int">
    /// The array of integers to be visualized and sorted. A cloned copy is used
    /// internally so the original array remains unchanged.
    /// </param>
    /// <param name="speed">
    /// The animation speed, expressed as updates per second. A value of 0 disables
    /// timed animation. Higher values result in faster visual updates.
    /// </param>
    /// <param name="barWidth">
    /// The width of each bar in characters. This determines the horizontal spacing
    /// of the bar diagram.
    /// </param>
    /// <param name="stopAfterEachStep">
    /// If <c>true</c>, the animation pauses after each swap and waits for user input
    /// before continuing. If <c>false</c>, the animation proceeds automatically
    /// based on the specified speed.
    /// </param>
    /// <param name="color">
    /// The console background color used to draw the bars in the visualization.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the array is too large to be displayed withing the console window.
    /// Specifically, the array length must not exceed <c>Console.WindowHeight</c>.
    /// </exception>
    /// <remarks>
    /// This method performs a visual Bubble Sort:
    /// <list type="bullet">
    /// <item><description>Draws the initial bar diagram.</description></item>
    /// <item><description>Performs Bubble Sort, redrawing the diagram after each swap.</description></item>
    /// <item><description>Supports step-by-step mode or timed animation.</description></item>
    /// </list>
    /// The console is cleared and redrawn frequently, making this method suitable
    /// for educational or demonstrative purposes reather than performance.
    /// </remarks>
    private static void BubbleSortAnimation(int[] array_int, double speed, int barWidth, bool stopAfterEachStep, ConsoleColor color)
    {
      if (array_int.Length > Console.WindowHeight)
      {
        throw new ArgumentOutOfRangeException(
          $"BubbeSortAnimation received invalid parameters. " +
          $"Length of array_int ({array_int.Length}) must be <= Console.WindowHeight.");
      }

      ShapeRenderer sRenderer = new ShapeRenderer();
      int[] new_array_int = (int[])array_int.Clone();
      int n = new_array_int.Length;
      bool swapped = true;

      sRenderer.DrawVerticalBarDiagram(0, 9, 10, barWidth, new_array_int, color);
      if (stopAfterEachStep)
      {
        Console.ReadLine();
      }

      while (swapped == true)
      {
        swapped = false;
        for (int i = 1; i <= n - 1; ++i)
        {
          if (new_array_int[i - 1] > new_array_int[i])
          {
            int temp = new_array_int[i - 1];
            new_array_int[i - 1] = new_array_int[i];
            new_array_int[i] = temp;
            swapped = true;
            Console.Clear();
            sRenderer.DrawVerticalBarDiagram(0, 9, 10, barWidth, new_array_int, color);
            if (stopAfterEachStep)
            {
              Console.ReadLine();
            }
            else if (speed > 0.0)
            {
              Thread.Sleep((int)(1000 / speed));
            }
          }
        }

        n -= 1;
      }
    }

    /// <summary>
    /// Draws numeric labels beneath each bar in a bar chart visualization.
    /// Each label represents the value of the corresponding bar.
    /// </summary>
    /// <param name="arrayInt">
    /// The array of integer values to display as labels. Each element is written
    /// below its corresponding bar.
    /// </param>
    /// <param name="barWidth">
    /// The horizontal width of each bar in characters. This value is used to
    /// calculate the horizontal spacing between labels.
    /// </param>
    /// <remarks>
    /// The method positions each label horizontally based on its index and the
    /// specified bar width. Labels are drawn on a single row located below the
    /// bar chart area. Cursor position is handled through <c>ConsoleUtils</c>.
    /// </remarks>
    private static void DrawAxisLabels(int[] arrayInt, int barWidth)
    {
      for (int i = 0; i < arrayInt.Length; ++i)
      {
        ConsoleUtils.SetCursorPosition((i * barWidth) + 1, arrayInt.Length + 3);
        Console.Write(arrayInt[i]);
      }
    }
  }
}
