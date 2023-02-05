using FluentAssertions;
using Sorting.Complex;

namespace Sorting.Tests.Complex
{
    public class MergeSortTests
    {
        [Fact]
        public void Merge_TwoSortedArraysProvided_MergeThemCorrectly()
        {
            // Arrange
            var firstSorted = new[] { 1, 2, 3 };
            var secondSorted = new[] { 1, 5, 8 };
            var result = firstSorted.Concat(secondSorted).ToArray();
            var auxiliry = new int[result.Length];

            // Act
            MergeSort.Merge(result, auxiliry, 0, 2, 5, Comparer<int>.Default.Compare);

            // Assert
            result.Should().BeInAscendingOrder();
        }

        [Fact]
        public void Sort_RandomUnsortedArrayProvided_SortsPerfectly()
        {
            // Arrange
            var unsorted = Enumerable.Range(1, 10).Select(i => new Random().Next(0, 11)).ToList();

            // Act
            MergeSort.Sort(unsorted);

            // Assert
            unsorted.Should().BeInAscendingOrder();
        }
    }
}
