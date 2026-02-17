using Xunit;

namespace SortingAlgorithms.Tests
{
  public class ShapeRendererTests
  {
    [Fact]
    public void DrawRectangle_NegativeXCoordinate_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawRectangle(-1, 0, 0, 0, (ConsoleColor)7));
    }

    [Fact]
    public void DrawRectangle_NegativeYCoordinate_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawRectangle(0, -1, 0, 0, (ConsoleColor)7));
    }

    [Fact]
    public void DrawRectangle_BothCoordinatesNegative_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawRectangle(0, -1, 0, 0, (ConsoleColor)7));
    }

    [Fact]
    public void DrawRectangle_XCoordinateExceedsUpperLimit_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawRectangle(80, 0, 0, 0, (ConsoleColor)7));
    }

    [Fact]
    public void DrawRectangle_YCoordinateExceedsUpperLimit_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawRectangle(0, 25, 0, 0, (ConsoleColor)7));
    }

    [Fact]
    public void DrawRectangle_RectangleWidthExceedsWindowSize_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawRectangle(79, 0, 1, 0, (ConsoleColor)7));
    }

    [Fact]
    public void DrawRectangle_RectangleHeightExceedsWindowSize_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawRectangle(0, 24, 0, 1, (ConsoleColor)7));
    }

    [Fact]
    public void DrawRectangle_NegativeWidth_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawRectangle(0, 0, -1, 0, (ConsoleColor)7));
    }

    [Fact]
    public void DrawRectangle_NegativeHeight_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawRectangle(0, 0, 0, -1, (ConsoleColor)7));
    }

    [Fact]
    public void DrawRectangle_InvalidColor_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawRectangle(0, 0, 0, 0, (ConsoleColor)16));
    }

    [Fact]
    public void DrawFilledRectangle_NegativeXCoordinate_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawRectangle(-1, 0, 0, 0, (ConsoleColor)7));
    }

    [Fact]
    public void DrawFilledRectangle_NegativeYCoordinate_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawRectangle(0, -1, 0, 0, (ConsoleColor)7));
    }

    [Fact]
    public void DrawFilledRectangle_BothCoordinatesNegative_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawRectangle(-1, -1, 0, 0, (ConsoleColor)7));
    }

    [Fact]
    public void DrawFilledRectangle_NegativeWidth_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawRectangle(0, 0, -1, 0, (ConsoleColor)7));
    }

    [Fact]
    public void DrawFilledRectangle_NegativeHeight_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawRectangle(0, 0, 0, -1, (ConsoleColor)7));
    }

    [Fact]
    public void DrawFilledRectangle_InvalidColor_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawRectangle(0, 0, 0, 0, (ConsoleColor)16));
    }

    [Fact]
    public void DrawVerticalBar_NegativeXCoordinate_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawVerticalBar(-1, 0, 0, (ConsoleColor)7));
    }

    [Fact]
    public void DrawVerticalBar_NegativeYCoordinate_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawVerticalBar(0, -1, 0, (ConsoleColor)7));
    }

    [Fact]
    public void DrawVerticalBar_BothCoordinatesNegative_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawVerticalBar(-1, -1, 0, (ConsoleColor)7));
    }

    [Fact]
    public void DrawVerticalBar_NegativeHeight_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawVerticalBar(0, 0, -1, (ConsoleColor)7));
    }

    [Fact]
    public void DrawVerticalBar_InvalidColor_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawVerticalBar(0, 0, 0, (ConsoleColor)16));
    }

    [Fact]
    public void DrawHorizontalBar_NegativeXCoordinate_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawHorizontalBar(-1, 0, 0, (ConsoleColor)7));
    }

    [Fact]
    public void DrawHorizontalBar_NegativeYCoordinate_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawHorizontalBar(0, -1, 0, (ConsoleColor)7));
    }

    [Fact]
    public void DrawHorizontalBar_BothCoordinatesNegative_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawHorizontalBar(-1, -1, 0, (ConsoleColor)7));
    }

    [Fact]
    public void DrawHorizontalBar_NegativeLength_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawHorizontalBar(0, 0, -1, (ConsoleColor)7));
    }

    [Fact]
    public void DrawHorizontalBar_InvalidColor_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawHorizontalBar(0, 0, 0, (ConsoleColor)16));
    }

    [Fact]
    public void DrawVerticalBarDiagram_NegativeXCoordinate_Throws()
    {
      int[] array = new int[1];
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawVerticalBarDiagram(-1, 0, 1, 1, array, (ConsoleColor)7));
    }

    [Fact]
    public void DrawVerticalBarDiagram_NegativeYCoordinate_Throws()
    {
      int[] array = new int[1];
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawVerticalBarDiagram(0, -1, 1, 1, array, (ConsoleColor)7));
    }

    [Fact]
    public void DrawVerticalBarDiagram_BothCoordinatesNegative_Throws()
    {
      int[] array = new int[1];
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawVerticalBarDiagram(-1, -1, 1, 1, array, (ConsoleColor)7));
    }

    [Fact]
    public void DrawVerticalBarDiagram_InvalidHeight_Throws()
    {
      int[] array = new int[1];
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawVerticalBarDiagram(0, 0, -1, 1, array, (ConsoleColor)7));
    }

    [Fact]
    public void DrawVerticalBarDiagram_InvalidBarWidth_Throws()
    {
      int[] array = new int[1];
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawVerticalBarDiagram(0, 0, 1, 0, array, (ConsoleColor)7));
    }

    [Fact]
    public void DrawVerticalBarDiagram_InvalidColor_Throws()
    {
      int[] array = new int[1];
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentOutOfRangeException>(() => sRenderer.DrawVerticalBarDiagram(0, 0, 1, 1, array, (ConsoleColor)16));
    }

    [Fact]
    public void DrawVerticalBarDiagram_NullArray_Throws()
    {
      ShapeRenderer sRenderer = new ShapeRenderer();
      Assert.Throws<ArgumentNullException>(() => sRenderer.DrawVerticalBarDiagram(0, 0, 1, 1, null, (ConsoleColor)7));
    }

    [Fact]
    public void DrawVerticalBarDiagram_EmptyArray_DoesNotThrow()
    {
      int[] array = Array.Empty<int>();
      ShapeRenderer sRenderer = new ShapeRenderer();
      var exception = Record.Exception(() => sRenderer.DrawVerticalBarDiagram(0, 0, 1, 1, array, (ConsoleColor)7));
      Assert.Null(exception);
    }
  }
}
