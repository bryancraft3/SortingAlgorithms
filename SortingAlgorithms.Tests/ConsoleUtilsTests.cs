using Xunit;

namespace SortingAlgorithms.Tests
{
  public class ConsoleUtilsTests
  {
    [Fact]
    public void SetCursorPosition_NegativeXCoordinate_Throws()
    {
      Assert.Throws<ArgumentOutOfRangeException>(() => ConsoleUtils.SetCursorPosition(-1, 0));
    }

    [Fact]
    public void SetCursorPosition_NegativeYCoordinate_Throws()
    {
      Assert.Throws<ArgumentOutOfRangeException>(() => ConsoleUtils.SetCursorPosition(0, -1));
    }

    [Fact]
    public void SetCursorPosition_BothCoordinatesNegative_Throws()
    {
      Assert.Throws<ArgumentOutOfRangeException>(() => ConsoleUtils.SetCursorPosition(-1, -1));
    }

    [Fact]
    public void TrySetCursorPosition_NegativeXCoordinate_ReturnsFalse()
    {
      bool result = ConsoleUtils.TrySetCursorPosition(-1, 0);

      Assert.False(result);
    }

    [Fact]
    public void TrySetCursorPosition_NegativeYCoordinate_ReturnsFalse()
    {
      bool result = ConsoleUtils.TrySetCursorPosition(0, -1);

      Assert.False(result);
    }

    [Fact]
    public void TrySetCursorPosition_BothCoordinatesNegative_ReturnsFalse()
    {
      bool result = ConsoleUtils.TrySetCursorPosition(-1, -1);

      Assert.False(result);
    }

    [Fact]
    public void TrySetCursorPosition_ValidCoordinates_DoesNotThrow()
    {
      var exception = Record.Exception(() => ConsoleUtils.TrySetCursorPosition(0, 0));
      Assert.Null(exception);
    }
  }
}
