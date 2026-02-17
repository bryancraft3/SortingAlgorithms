// --------------------------------------------------------------------------
// <copyright file="ShapeRenderer.cs" company="Bryan Franke">
// Copyright (c) Bryan Franke. All rights reserved.
// </copyright>
// <summary>
// Provides utility methods for rendering shapes and bar-based visualizations
// in the console, including vertical bars, horizontal bars, rectangles, and
// full bar diagrams used for sorting animations.
// </summary>
// --------------------------------------------------------------------------
namespace SortingAlgorithms
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  internal class ShapeRenderer
  {
    /// <summary>
    /// Draws a rectangular outline on the console using the specified background color.
    /// The rectangle is drawn using spaces, with only the border rendered.
    /// </summary>
    /// <param name="coordX">
    /// The X-coordinate (column) of the rectangle's top-left corner.
    /// Must be within the range 0 to Console.WindowWidth - 1.
    /// </param>
    /// <param name="coordY">
    /// The Y-coordinate (row) of the rectangle's top-left corner.
    /// Must be within the range 0 to Console.WindowHeight - 1.
    /// </param>
    /// <param name="width">
    /// The width of the rectangle in characters. Must be zero or positive.
    /// The value coordX + width must not exceed Console.WindowWidth - 1.
    /// </param>
    /// <param name="height">
    /// The height of the rectangle in characters. Must be zero or positive.
    /// The value coordY + height must not exceed Console.WindowHeight - 1.
    /// </param>
    /// <param name="color">
    /// The background color used to draw the rectangle.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when any coordinate is outside the console window bounds,
    /// or when width/height are negative, or when the rectangle does not
    /// fit entirely within the console window.
    /// </exception>
    /// <remarks>
    /// This method temporarily changes the console background color and cursor position.
    /// Original console settings are restored after drawing.
    /// Only the border of the rectangle is drawn; the interior remains unchanged.
    /// </remarks>
    public void DrawRectangle(int coordX, int coordY, int width, int height, ConsoleColor color)
    {
      // Safely get console dimensions (fallback for test environments)
      int windowWidth;
      int windowHeight;

      if (Console.IsOutputRedirected)
      {
        // Reasonable fallback values for headless environments
        windowWidth = 80;
        windowHeight = 25;
      }
      else
      {
        windowWidth = Console.WindowWidth;
        windowHeight = Console.WindowHeight;
      }

      if (coordX < 0 || coordX >= windowWidth || coordY < 0 || coordY >= windowHeight)
      {
        throw new ArgumentOutOfRangeException(
          $"DrawRectangle received out-of-bounds coordinates ({coordX}, {coordY}. " +
          $"Valid range is coordX: 0-{windowWidth - 1}, coordY: 0-{windowWidth - 1}.");
      }

      if (width < 0 || coordX + width >= windowWidth || height < 0 || coordY + height >= windowHeight)
      {
        throw new ArgumentOutOfRangeException(
          $"DrawRectangle received invalid parameters. " +
          $"width ({width}) and height ({height}) must be >= 0. " +
          $"The rectangle must also fit inside the console window: " +
          $"coordX + width <= {windowWidth - 1}, " +
          $"coordY + height <= {windowHeight - 1}.");
      }

      if (!Enum.IsDefined(typeof(ConsoleColor), color))
      {
        throw new ArgumentOutOfRangeException(nameof(color), "DrawRectangle received invalid parameter.");
      }

      ConsoleUtils.StoreConsoleSettings();
      ConsoleUtils.SetBackgroundColor(color);

      for (int rows = 0; rows < height; ++rows)
      {
        if (rows == 0 || rows == height - 1)
        {
          for (int cols = 0; cols < width; ++cols)
          {
            ConsoleUtils.SetCursorPosition(cols + coordX, rows + coordY);
            Console.Write(" ");
          }
        }
        else
        {
          ConsoleUtils.SetCursorPosition(coordX, rows + coordY);
          Console.Write(" ");
          ConsoleUtils.SetCursorPosition(width + coordX - 1, rows);
          Console.Write(" ");
        }
      }

      ConsoleUtils.RestoreConsoleSettings();
    }

    /// <summary>
    /// Draws a filled rectangle on the console using the specified background color.
    /// The rectangle is rendered as a solid block of spaces.
    /// </summary>
    /// <param name="coordX">
    /// The X-coordinate (column) of the rectangle's top-left corner.
    /// Must be within the range 0 to Console.WindowWidth - 1.
    /// </param>
    /// <param name="coordY">
    /// The Y-coordinate (row) fo the rectangle's top-left corner.
    /// Must be within the range 0 to Console.WindowHeight - 1.
    /// </param>
    /// <param name="width">
    /// The width of the rectangle in characters. Must be zero or positive.
    /// The value coordX + width must not exceed Console.WindowWidth - 1.
    /// </param>
    /// <param name="height">
    /// The height of the rectangle in characters. Must be zero or positive.
    /// The value coordY + height must not exceed Console.WindowHeight - 1.
    /// </param>
    /// <param name="color">
    /// The background color used to fill the rectangle.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when any coordinate is outside the console window bounds,
    /// when width or height is negative, or when the rectangle does not
    /// fit entirely within the console window.
    /// </exception>
    /// <remarks>
    /// This method temporarily changes the console background color and cursor position.
    /// Original console settings are restored after drawing.
    /// The rectangle is filled completely; no border is drawn.
    /// </remarks>
    public void DrawFilledRectangle(int coordX, int coordY, int width, int height, ConsoleColor color)
    {
      // Safely get console dimensions (fallback for test environments)
      int windowWidth;
      int windowHeight;

      if (Console.IsOutputRedirected)
      {
        // Reasonable fallback values for headless environments
        windowWidth = 80;
        windowHeight = 25;
      }
      else
      {
        windowWidth = Console.WindowWidth;
        windowHeight = Console.WindowHeight;
      }

      if (coordX < 0 || coordX >= windowWidth || coordY < 0 || coordY >= windowHeight)
      {
        throw new ArgumentOutOfRangeException(
          $"DrawFilledRectangle received out-of-bounds coordinates ({coordX}, {coordY}. " +
          $"Valid range is coordX: 0-{windowWidth - 1}, coordY: 0-{windowHeight - 1}.");
      }

      if (width < 0 || coordX + width >= windowWidth || coordY < 0 || coordY + height >= windowHeight)
      {
        throw new ArgumentOutOfRangeException(
          $"DrawFilledRectangle received invalid parameters. " +
          $"width ({width}) and height ({height}) must be >= 0. " +
          $"The rectangle must also fit inside the console window: " +
          $"coordX + width <= {windowWidth - 1}, " +
          $"coordY + height <= {windowHeight - 1}.");
      }

      ConsoleUtils.StoreConsoleSettings();
      ConsoleUtils.SetBackgroundColor(color);

      for (int rows = 0; rows < height; ++rows)
      {
        for (int cols = 0; cols < width; ++cols)
        {
          ConsoleUtils.SetCursorPosition(cols + coordX, rows + coordY);
          Console.Write(" ");
        }
      }

      ConsoleUtils.RestoreConsoleSettings();
    }

    /// <summary>
    /// Draws a vertical bar in the console using the specified background color.
    /// The bar is rendered as a column of space characters extending upward
    /// from the starting coordinate.
    /// </summary>
    /// <param name="coordX">
    /// The X-coordinate (column) of the bar's base. Must be within the range
    /// 0 to Console.WindowWidth - 1.
    /// </param>
    /// <param name="coordY">
    /// The Y-coordinate (row) of the bar's base. Must be within the range
    /// 0 to Console.WindowHeight - 1.
    /// </param>
    /// <param name="height">
    /// The height of the bar in characters. Must be zero or positive.
    /// The bar extends upward from <paramref name="coordY"/>, so
    /// <c>coordY - (height - 1)</c> must remain within the console window.
    /// </param>
    /// <param name="color">
    /// The background color used to draw the bar.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the starting coordinates are outside the console window,
    /// or when the specified height would cause the bar to extend beyond
    /// the upper boundary of the console.
    /// </exception>
    /// <remarks>
    /// This method temporarily changes the console background color and cursor
    /// position. Original console settings are restored after drawing.
    /// The bar is drawn from bottom to top, one character per row.
    /// </remarks>
    public void DrawVerticalBar(int coordX, int coordY, int height, ConsoleColor color)
    {
      // Safely get console dimensions (fallback for test environments)
      int windowWidth;
      int windowHeight;

      if (Console.IsOutputRedirected)
      {
        // Reasonable fallback values for headless environments
        windowWidth = 80;
        windowHeight = 25;
      }
      else
      {
        windowWidth = Console.WindowWidth;
        windowHeight = Console.WindowHeight;
      }

      if (coordX < 0 || coordX >= windowWidth || coordY < 0 || coordY >= windowHeight)
      {
        throw new ArgumentOutOfRangeException(
          $"DrawVerticalBar received out-of-bounds coordinates ({coordX}, {coordY}. " +
          $"Valid range is coordX: 0-{windowWidth - 1}, coordY: 0-{windowHeight - 1}.");
      }

      if (height < 0 || coordY + 1 < height)
      {
        throw new ArgumentOutOfRangeException(
          $"DrawVerticalBar received invalid parameters. " +
          $"height ({height}) must be >= 0. " +
          $"The vertical bar must also fit inside the console window: " +
          $"coordY + 1 >= height.");
      }

      if (!Enum.IsDefined(typeof(ConsoleColor), color))
      {
        throw new ArgumentOutOfRangeException(nameof(color), "DrawVerticalBar received invalid parameter.");
      }

      ConsoleUtils.StoreConsoleSettings();
      ConsoleUtils.SetBackgroundColor(color);

      for (int i = 0; i < height; ++i)
      {
        ConsoleUtils.SetCursorPosition(coordX, coordY - i);
        Console.Write(" ");
      }

      ConsoleUtils.RestoreConsoleSettings();
    }

    /// <summary>
    /// Draws a horizontal bar in the console using the specified background color.
    /// The bar is rendered as a sequence of space characters extending to the right
    /// from the starting coordinate.
    /// </summary>
    /// <param name="coordX">
    /// The X-coordinate (column) of the bar's starting position. Must be within the
    /// range 0 to Console.WindowWidth - 1.
    /// </param>
    /// <param name="coordY">
    /// The Y-coordinate (row) of the bar's starting position. Must be within the
    /// range 0 to Console.WindowHeight - 1.
    /// </param>
    /// <param name="length">
    /// The lenght of the bar in characters. Must be zero or positive.
    /// The bar extends horizontally to the right, so
    /// <c>coordX + length</c> must no exceed <c>Console.WindowWidth</c>.
    /// </param>
    /// <param name="color">
    /// The background color used to draw the bar.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the starting coordinates are outside the console window,
    /// or when the specified length would cause the bar to extend beyond
    /// the right boundary of the console.
    /// </exception>
    /// <remarks>
    /// This method temporarily changes the console background color and cursor
    /// position. Original console settings are restored after drawing.
    /// The bar is drawn from left to right, one character per column.
    /// </remarks>
    public void DrawHorizontalBar(int coordX, int coordY, int length, ConsoleColor color)
    {
      // Safely get console dimensions (fallback for test environments)
      int windowWidth;
      int windowHeight;

      if (Console.IsOutputRedirected)
      {
        // Reasonable fallback values for headless environments
        windowWidth = 80;
        windowHeight = 25;
      }
      else
      {
        windowWidth = Console.WindowWidth;
        windowHeight = Console.WindowHeight;
      }

      if (coordX < 0 || coordX >= windowWidth || coordY < 0 || coordY >= windowHeight)
      {
        throw new ArgumentOutOfRangeException(
          $"DrawHorizontalBar received out-of-bounds coordinates ({coordX}, {coordY}. " +
          $"Valid range is coordX: 0-{windowWidth - 1}, coordY: 0-{windowHeight - 1}.");
      }

      if (length < 0 || coordX + length > windowWidth)
      {
        throw new ArgumentOutOfRangeException(
          $"DrawHorizontalBar received invalid parameters. " +
          $"length ({length}) must be >= 0. " +
          $"The horizontal bar must also fit inside the console window: " +
          $"coordX + length - 1 < {windowWidth - 1}.");
      }

      if (!Enum.IsDefined(typeof(ConsoleColor), color))
      {
        throw new ArgumentOutOfRangeException(nameof(color), "DrawHorizontalBar received invalid parameter.");
      }

      ConsoleUtils.StoreConsoleSettings();
      ConsoleUtils.SetBackgroundColor(color);

      for (int i = 0; i < length; ++i)
      {
        ConsoleUtils.SetCursorPosition(coordX + i, coordY);
        Console.Write(" ");
      }

      ConsoleUtils.RestoreConsoleSettings();
    }

    /// <summary>
    /// Draws a vertical bar diagram in the console, where each bar's height
    /// corresponds to the relative order of the values in the provided array.
    /// Bars are drawn using repeated calls to <see cref="DrawVerticalBar"/>.
    /// </summary>
    /// <param name="coordX">
    /// The X-coordinate (column) of the diagrams's leftmost bar. Must be within
    /// the range 0 to Console.WindowWidth - 1.
    /// </param>
    /// <param name="coordY">
    /// The Y-coordinate (row) of the diagram's baseline. Bars extend upward
    /// from this position. Must be within the range 0 to Console.WindowHeight - 1.
    /// </param>
    /// <param name="height">
    /// The maximum height of the diagram in characters. Must be zero or positive.
    /// The diagram must fit vertically withing the console window, meaning
    /// <c>coordY - (height - 1)</c> must not be above row 0.
    /// </param>
    /// <param name="barWidth">
    /// The width of each bar in characters. Must be greater than zero.
    /// Each bar is drawn as a block of <paramref name="barWidth"/> adjacent
    /// vertical bars.
    /// </param>
    /// <param name="array">
    /// The array of integer values to visualize. The values are converted into
    /// relative ranks (1 = smallest value, N = largest value), and each bar's
    /// height is determined by its rank.
    /// </param>
    /// <param name="color">
    /// The background color used to draw the bars.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when:
    /// <list type="bullet">
    /// <item><description>The starting coordinates are outside the console window.</description></item>
    /// <item><description>The specified height would cause the diagram to extend beyond the top of the console.</description></item>
    /// <item><description><paramref name="barWidth"/> is less than or equal to zero.</description></item>
    /// <item><description>The diagram would extend beyond the right edge of the console window.</description></item>
    /// </list>
    /// </exception>
    /// <remarks>
    /// This method first computes a ranking of the array values, ensuring that
    /// bars representing relative order rather than absolute magnitude. The diagram
    /// is then drawn left-to-right, with each bar rendered as a block of
    /// <paramref name="barWidth"/> vertical bars.
    ///
    /// This method is intened for visualization purposes and may clear or
    /// overwrite portions of the console.
    /// </remarks>
    public void DrawVerticalBarDiagram(int coordX, int coordY, int height, int barWidth, int[]? array, ConsoleColor color)
    {
      // Safely get console dimensions (fallback for test environments)
      int windowWidth;
      int windowHeight;

      if (Console.IsOutputRedirected)
      {
        // Reasonable fallback values for headless environments
        windowWidth = 80;
        windowHeight = 25;
      }
      else
      {
        windowWidth = Console.WindowWidth;
        windowHeight = Console.WindowHeight;
      }

      if (coordX < 0 || coordX >= windowWidth || coordY < 0 || coordY >= windowHeight)
      {
        throw new ArgumentOutOfRangeException(
          $"DrawVerticalBarDiagram received out-of-bounds coordinates ({coordX}, {coordY}. " +
          $"Valid range is coordX: 0-{windowWidth - 1}, coordY: 0-{windowHeight - 1}.");
      }

      if (height < 0 || coordY + 1 < height)
      {
        throw new ArgumentOutOfRangeException(
          $"DrawVerticalBarDiagram received invalid parameters. " +
          $"height ({height}) must be >= 0. " +
          $"The vertical bar must also fit inside the console window: " +
          $"coordY + 1 >= height.");
      }

      if (array == null)
      {
        throw new ArgumentNullException();
      }

      if (array.Length == 0)
      {
        return;
      }

      if (coordX + (barWidth * array.Length) >= windowWidth)
      {
        throw new ArgumentOutOfRangeException(
          $"DrawVerticalBarDiagram received out-of-bounds parameters. " +
          $"Valid range is coordX + barWidth * barCount: 1-{windowWidth - 1}.");
      }

      if (!Enum.IsDefined(typeof(ConsoleColor), color))
      {
        throw new ArgumentOutOfRangeException(nameof(color), "DrawVerticalBarDiagram received invalid parameter.");
      }

      int count = array.Length;
      int[] copyArray = (int[])array.Clone();
      int[] orderArray = new int[count];
      int minValue;
      int minIndex;
      for (int i = 0; i < count; ++i)
      {
        minValue = copyArray.Min();
        minIndex = Array.IndexOf(copyArray, minValue);
        orderArray[minIndex] = i + 1;
        copyArray[minIndex] = int.MaxValue;
      }

      if (coordX < 0 || coordX >= windowWidth || coordY < 0 || coordY >= windowHeight)
      {
        throw new ArgumentOutOfRangeException(
          $"DrawVerticalBarDiagram received out-of-bounds coordinates ({coordX}, {coordY}. " +
          $"Valid range is coordX: 0-{windowWidth - 1}, coordY: 0-{windowHeight - 1}.");
      }

      if (height < 0 || coordY + 1 < height)
      {
        throw new ArgumentOutOfRangeException(
          $"DrawVerticalBarDiagram received invalid parameters. " +
          $"height ({height}) must be >= 0. " +
          $"The vertical bar diagram must also fit inside the console window: " +
          $"coordY + 1 >= height.");
      }

      if (barWidth <= 0)
      {
        throw new ArgumentOutOfRangeException(
          $"DrawVerticalBarDiagram received invalid parameters. " +
          $"barWidth ({barWidth}) must be > 0.");
      }

      if (count < 0 || coordX + (count * barWidth) - 1 >= windowWidth)
      {
        throw new ArgumentOutOfRangeException(
          $"DrawVerticalBarDiagram received invalid parameters. " +
          $"count ({count}) must be >= 0. " +
          $"coordX + count - 1 < Console.WindowWidth.");
      }

      for (int i = 0; i < count; ++i)
      {
        for (int j = 0; j < barWidth; ++j)
        {
          this.DrawVerticalBar(coordX + (i * barWidth) + j, coordY, orderArray[i], color);
        }
      }
    }
  }
}
