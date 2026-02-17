// -------------------------------------------------------------------------
// <copyright file="SortAlgorithms.cs" company="Bryan Franke">
// Copyright (c) Bryan Franke. All rights reserved.
// </copyright>
// <summary>
// Provides methods for sorting arrays using various sorting algorithms.
// </summary>
// -------------------------------------------------------------------------
namespace SortingAlgorithms
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public class SortAlgorithms
  {
    /// <summary>
    /// Performs a Bubble Sort on the provided integer array and returns a new,
    /// sorted array in ascending order. The original array is not modified.
    /// </summary>
    /// <param name="array_int">
    /// The input array to be sorted. Its contents are cloned before sorting,
    /// ensuring that the original array remains unchanged.
    /// </param>
    /// <returns>
    /// A new integer array containing the sorted values of the input array
    /// in ascending order.
    /// </returns>
    /// <remarks>
    /// This implementation uses the classic Bubble Sort algorithm, which repeatedly
    /// iterates through the array, swapping adjacent elements that are out of order.
    /// The algorithm stops early if a full pass completes without any swaps,
    /// indicating that the array is already sorted.
    ///
    /// Time complexity: O(n²) in the worst and average case.
    /// Space complexity: O(n) due to cloning the input array.
    /// </remarks>
    public static int[] BubbleSort(int[]? array_int)
    {
      if (array_int == null)
      {
        throw new ArgumentNullException(nameof(array_int));
      }

      if (array_int.Length <= 1)
      {
        return array_int;
      }

      int[] new_array_int = (int[])array_int.Clone();
      int count = new_array_int.Length;
      bool swapped = true;

      while (swapped == true)
      {
        swapped = false;
        for (int i = 1; i <= count - 1; ++i)
        {
          if (new_array_int[i - 1] > new_array_int[i])
          {
            int temp = new_array_int[i - 1];
            new_array_int[i - 1] = new_array_int[i];
            new_array_int[i] = temp;
            swapped = true;
          }
        }

        count -= 1;
      }

      return new_array_int;
    }
  }
}
