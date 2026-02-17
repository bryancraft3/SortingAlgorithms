using Xunit;

namespace SortingAlgorithms.Tests
{
  public class SortAlgorithmsTests
  {
    [Fact]
    public void BubbleSort_SortsArrayCorrectly()
    {
      int[] input = { 5, 3, 8, 1 };
      int[] expected = { 1, 3, 5, 8 };
      int[] result = SortAlgorithms.BubbleSort(input);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void BubbleSort_OnNullArray()
    {
      Assert.Throws<ArgumentNullException>(() => SortAlgorithms.BubbleSort(null));
    }

    [Fact]
    public void BubbleSort_OnEmptyArray()
    {
      int[] input = Array.Empty<int>();
      int[] result = SortAlgorithms.BubbleSort(input);

      Assert.Empty(result);
    }

    [Fact]
    public void BubbleSort_OnOneEntry()
    {
      int[] input = { 74 };
      int[] result = SortAlgorithms.BubbleSort(input);

      Assert.Equal(new int[] { 74 }, result);
    }

    [Fact]
    public void BubbleSort_OnOneNegativeEntry()
    {
      int[] input = { -74 };
      int[] result = SortAlgorithms.BubbleSort(input);

      Assert.Equal(new int[] { -74 }, result);
    }

    [Fact]
    public void BubbleSort_OnTwoSortedEntries()
    {
      int[] input = { 3, 4 };
      int[] expected = { 3, 4 };
      int[] result = SortAlgorithms.BubbleSort(input);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void BubbleSort_OnTwoUnsortedEntries()
    {
      int[] input = { 4, 3 };
      int[] expected = { 3, 4 };
      int[] result = SortAlgorithms.BubbleSort(input);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void BubbleSort_OnTwoSortedNegativeEntries()
    {
      int[] input = { -4, -3 };
      int[] expected = { -4, -3 };
      int[] result = SortAlgorithms.BubbleSort(input);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void BubbleSort_OnTwoUnsortedNegativeEntries()
    {
      int[] input = { -3, -4 };
      int[] expected = { -4, -3 };
      int[] result = SortAlgorithms.BubbleSort(input);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void BubbleSort_OnMixedSignNumbers_SortedCorrectly()
    {
      int[] input = { -22, -7, 0, 378, 1999 };
      int[] expected = { -22, -7, 0, 378, 1999 };
      int[] result = SortAlgorithms.BubbleSort(input);

      Assert.Equal(expected, result);
    }

    [Fact]
    public void BubbleSort_OnMixedSignNumbers_SortedIncorrectly()
    {
      int[] input = { 0, 378, 1999, -7, -22 };
      int[] expected = { -22, -7, 0, 378, 1999 };
      int[] result = SortAlgorithms.BubbleSort(input);

      Assert.Equal(expected, result);
    }
  }
}
