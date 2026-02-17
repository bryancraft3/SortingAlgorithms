// -------------------------------------------------------------------------
// <copyright file="ConsoleUtils.cs" company="Bryan Franke">
// Copyright (c) Bryan Franke. All rights reserved.
// </copyright>
// <summary>
// Provides utility methods for managing console colors, cursor visibility,
// window titles, and other console-related features in a platform-safe way.
// </summary>
// -------------------------------------------------------------------------
namespace SortingAlgorithms
{
  using System;

  /* Console commands, which need to be restored before exiting the console:
   * ForegroundColor
   * BackgroundColor
   * CursorVisibility
   * Write("\u001b]0;Titleu0007")
  */

  /// <summary>
  /// Provides methods for managing the console's appearance.
  /// </summary>
  internal class ConsoleUtils
  {
    private static ConsoleColor originalForegroundColor;
    private static ConsoleColor originalBackgroundColor;
    private static bool originalCursorVisibility;
    private static string originalWindowTitle = string.Empty;

    /// <summary>
    /// Captures the current console appearance and state settings.
    /// </summary>
    /// <remarks>
    /// The stored values can be used later to restore the console to its
    /// original state. This method does not persist settings across sessions;
    /// it only records them for use within the current application.
    /// </remarks>
    public static void StoreConsoleSettings()
    {
      // Always safe
      originalForegroundColor = Console.ForegroundColor;
      originalBackgroundColor = Console.BackgroundColor;

      // Only attempt Windows-specific console operations if a real console exists
      if (OperatingSystem.IsWindows() && !Console.IsOutputRedirected)
      {
        try
        {
          originalCursorVisibility = Console.CursorVisible;
        }
        catch
        {
          // Safe fallback for headless environments
          originalCursorVisibility = true;
        }

        try
        {
          originalWindowTitle = Console.Title;
        }
        catch
        {
          // Safe fallback
          originalWindowTitle = string.Empty;
        }
      }
    }

    /// <summary>
    /// Restores the console appearance and state settings previously capture
    /// by <see cref="StoreConsoleSettings"/>.
    /// </summary>
    /// <remarks>
    /// This method resets the console's foreground color, background color,
    /// cursor visibility, and window title(only on Windows) to the values
    /// that were stored earlier in the current application session.
    /// It does not restore settings from previous runs of the application.
    /// </remarks>
    public static void RestoreConsoleSettings()
    {
      SetForegroundColor(originalForegroundColor);
      SetBackgroundColor(originalBackgroundColor);
      SetCursorVisibility(originalCursorVisibility);
      if (OperatingSystem.IsWindows())
      {
        SetWindowTitle(originalWindowTitle);
      }
    }

    /// <summary>
    /// Sets the cursor position to the specified coordinates.
    /// </summary>
    /// <param name="posX">The horizontal position. Must be zero or greater.</param>
    /// <param name="posY">The vertical position. Must be zero or greater.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="posX"/> or <paramref name="posY"/> is negative.
    /// </exception>
    /// <remarks>
    /// This method enforces strict argument validation and will throw an exception
    /// if the provided coordinates are invalid. For scenarios where the input may
    /// be unreliable, such as user-provided values, consider using
    /// <see cref="TrySetCursorPosition(int, int)"/> instead.
    /// </remarks>
    public static void SetCursorPosition(int posX, int posY)
    {
      if (posX < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(posX));
      }

      if (posY < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(posY));
      }

      if (!Console.IsOutputRedirected)
      {
        Console.SetCursorPosition(posX, posY);
      }
    }

    /// <summary>
    /// Attempts to set the cursor position to the specified coordinates.
    /// </summary>
    /// <param name="posX">The horizontal cursor position. Must be zero or greater.</param>
    /// <param name="posY">The vertical cursor position. Must be zero or greater.</param>
    /// <returns>
    /// <c>true</c> if the cursor position was successfully updated; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// This method does not throw exceptions for invalid coordinates. It is intended for
    /// scenarios where the input may be unreliable, such as user-provided values.
    /// </remarks>
    public static bool TrySetCursorPosition(int posX, int posY)
    {
      if (posX < 0 || posY < 0)
      {
        return false;
      }

      try
      {
        Console.SetCursorPosition(posX, posY);
        return true;
      }
      catch
      {
        return false;
      }
    }

    /// <summary>
    /// Sets the console's foreground (text) color to the specified value.
    /// </summary>
    /// <param name="color">
    /// The <see cref="ConsoleColor"/> to apply to subsequent console output.
    /// </param>
    public static void SetForegroundColor(ConsoleColor color)
    {
      Console.ForegroundColor = color;
    }

    /// <summary>
    /// Sets the console's background color to the specified value.
    /// </summary>
    /// <param name="color">
    /// The <see cref="ConsoleColor"/> to apply to subsequent console output.
    /// </param>
    public static void SetBackgroundColor(ConsoleColor color)
    {
      Console.BackgroundColor = color;
    }

    /// <summary>
    /// Moves the cursor to the specified position and sets the console's
    /// foreground (text) color at that location.
    /// </summary>
    /// <param name="posX">The horizontal cursor position.</param>
    /// <param name="posY">The vertical cursor position.</param>
    /// <param name="color">
    /// The <see cref="ConsoleColor"/> to apply to subsequent output at the
    /// specified cursor position.
    /// </param>
    public static void SetForegroundColorAt(int posX, int posY, ConsoleColor color)
    {
      SetCursorPosition(posX, posY);
      Console.ForegroundColor = color;
    }

    /// <summary>
    /// Moves the cursor to the specified position and sets the console's
    /// background color at that location.
    /// </summary>
    /// <param name="posX">The horizontal cursor position.</param>
    /// <param name="posY">The vertical cursor position.</param>
    /// <param name="color">
    /// The <see cref="ConsoleColor"/> to apply to subsequent output at the
    /// specified cursor position.
    /// </param>
    public static void SetBackgroundColorAt(int posX, int posY, ConsoleColor color)
    {
      SetCursorPosition(posX, posY);
      Console.BackgroundColor = color;
    }

    /// <summary>
    /// Attempts to move the cursor to the specified position and set the console's
    /// foreground color at that location.
    /// </summary>
    /// <param name="posX">The horizontal cursor position.</param>
    /// <param name="posY">The vertical cursor position.</param>
    /// <param name="colorValue">
    /// An integer representing a <see cref="ConsoleColor"/> value to apply at the
    /// specified cursor position.
    /// </param>
    /// <returns>
    /// <c>true</c> if both the cursor position and color value are valid and the
    /// foreground color was successfully set; otherwise, <c>false</c>.
    /// </returns>
    public static bool TrySetForegroundColorAt(int posX, int posY, int colorValue)
    {
      if (!TrySetCursorPosition(posX, posY))
      {
        return false;
      }

      if (!Enum.IsDefined(typeof(ConsoleColor), colorValue))
      {
        return false;
      }

      Console.ForegroundColor = (ConsoleColor)colorValue;
      return true;
    }

    /// <summary>
    /// Attempts to move the cursor to the specified position and set the console's
    /// background color at that location.
    /// </summary>
    /// <param name="posX">The horizontal cursor position.</param>
    /// <param name="posY">The vertical cursor position.</param>
    /// <param name="colorValue">
    /// An integer representing a <see cref="ConsoleColor"/> value to apply at the
    /// specified cursor position.
    /// </param>
    /// <returns>
    /// <c>true</c> if both the cursor position and color value are valid and the
    /// background color was successfully set; otherwise, <c>false</c>.
    /// </returns>
    public static bool TrySetBackgroundColorAt(int posX, int posY, int colorValue)
    {
      if (!TrySetCursorPosition(posX, posY))
      {
        return false;
      }

      if (!Enum.IsDefined(typeof(ConsoleColor), colorValue))
      {
        return false;
      }

      Console.BackgroundColor = (ConsoleColor)colorValue;
      return true;
    }

    /// <summary>
    /// Sets the visibility of the console cursor.
    /// </summary>
    /// <param name="visible">
    /// <c>true</c> to make the cursor visible; <c>false</c> to hide it.
    /// </param>
    public static void SetCursorVisibility(bool visible)
    {
      if (!Console.IsOutputRedirected)
      {
        Console.CursorVisible = visible;
      }
    }

    /// <summary>
    /// Attempts to set the visibility of the console cursor.
    /// </summary>
    /// <param name="visible">
    /// <c>true</c> to make the cursor visible; <c>false</c> to hide it.</param>
    /// <returns>
    /// <c>true</c> if the cursor was successfully changed; otherwise,
    /// <c>false</c>.
    /// </returns>
    public static bool TrySetCursorVisibility(bool visible)
    {
      if (!Console.IsOutputRedirected)
      {
        try
        {
          Console.CursorVisible = visible;
          return true;
        }
        catch
        {
          return false;
        }
      }

      return false;
    }

    /// <summary>
    /// Sets the console window title on the current operating system.
    /// </summary>
    /// <param name="title">The title text to apply to the console window.</param>
    /// <remarks>
    /// On Windows systems, this method uses <see cref="Console.Title"/>.
    /// On non-Windows systems, it attempts to set the title using an ANSI escape sequence.
    /// This method does not suppress exceptions; callers are responsible for handling any
    /// errors thrown by the underlying console implementation.</remarks>
    public static void SetWindowTitle(string title)
    {
      if (!Console.IsOutputRedirected)
      {
        if (OperatingSystem.IsWindows())
        {
          Console.Title = title;
        }
        else
        {
          Console.Write($"\u001b]0;{title}\u0007");
        }
      }
    }

    /// <summary>
    /// Attempts to set the console window title on the current operating system.
    /// </summary>
    /// <param name="title">The title text to apply to the console window.</param>
    /// <returns>
    /// <c>true</c> if the window title was successfully updated; otherwise, <c> false</c>.</returns>
    /// <remarks>
    /// On Windows systems, this method uses <see cref="Console.Title"/>.
    /// On non-Windows systems, it attempts to set the title using an ANSI escape sequence.
    /// Any exceptions thrown by the underlying console implementation are suppressed.
    /// </remarks>
    public static bool TrySetWindowTitle(string title)
    {
      if (!Console.IsOutputRedirected)
      {
        try
        {
          if (OperatingSystem.IsWindows())
          {
            Console.Title = title;
          }
          else
          {
            Console.Write($"\u001b]0;{title}\u0007");
          }

          return true;
        }
        catch
        {
          return false;
        }
      }

      return false;
    }
  }
}
