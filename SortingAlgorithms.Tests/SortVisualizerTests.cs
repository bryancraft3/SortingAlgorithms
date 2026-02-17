using Xunit;

namespace SortingAlgorithms.Tests
{
  public class SortVisualizerTests
  {
    [Fact]
    public void BubbleSortAnimationWithAxisLabels_OnNullArray()
    {
      Assert.Throws<ArgumentNullException>(() => SortVisualizer.BubbleSortAnimationWithAxisLabels(null, 1, false, (ConsoleColor)7));
    }

    [Fact]
    public void BubbleSortAnimationWithAxisLabels_OnEmptyArray()
    {
      int[] input = Array.Empty<int>();
      Assert.Throws<ArgumentException>(() => SortVisualizer.BubbleSortAnimationWithAxisLabels(input, 1, false, (ConsoleColor)7));
    }

    [Fact]
    public void BubbleSortAnimationWithAxisLabels_OnOutOfBoundsParameterSpeed_UpperLimit()
    {
      int[] input = new int[] { 0 };
      Assert.Throws<ArgumentOutOfRangeException>(() => SortVisualizer.BubbleSortAnimationWithAxisLabels(input, 1001, false, (ConsoleColor)7));
    }

    [Fact]
    public void BubbleSortAnimationWithAxisLabels_OnOutOfBoundsParameterSpeed_LowerLimit()
    {
      int[] input = new int[] { 0 };
      Assert.Throws<ArgumentOutOfRangeException>(() => SortVisualizer.BubbleSortAnimationWithAxisLabels(input, 0, false, (ConsoleColor)7));
    }

    [Fact]
    public void BubbleSortAnimationWithAxisLabels_OnValidParameterSpeed_UpperLimit()
    {
      int[] input = new int[] { 0 };
      var exception = Record.Exception(() => SortVisualizer.BubbleSortAnimationWithAxisLabels(input, 1000, false, (ConsoleColor)7));
      Assert.IsNotType<ArgumentOutOfRangeException>(exception);
    }

    [Fact]
    public void BubbleSortAnimationWithAxisLabels_OnValidParameterSpeed_LowerLimit()
    {
      int[] input = new int[] { 0 };
      var exception = Record.Exception(() => SortVisualizer.BubbleSortAnimationWithAxisLabels(input, 1, false, (ConsoleColor)7));
      Assert.IsNotType<ArgumentOutOfRangeException>(exception);
    }

    [Fact]
    public void BubbleSortAnimationWithAxisLabels_OnValidParameterColor()
    {
      int[] input = new int[] { 0 };
      var exception = Record.Exception(() => SortVisualizer.BubbleSortAnimationWithAxisLabels(input, 1000, false, (ConsoleColor)7));
      Assert.IsNotType<ArgumentOutOfRangeException>(exception);
    }

    [Fact]
    public void BubbleSortAnimationWithAxisLabels_OnOutOfBoundsParameterColor()
    {
      int[] input = new int[] { 0 };
      Assert.Throws<ArgumentOutOfRangeException>(() => SortVisualizer.BubbleSortAnimationWithAxisLabels(input, 1000, false, (ConsoleColor)16));
    }
  }
}
