using FluentAssertions;

namespace Sorting.Tests
{
    public class SortTests
    {
        [Fact]
        public void SelectionSort_OrderedCollectionProvided_CollectionIsStillOrdered()
        {
            // Arrange
            var arr = new int[] { 1, 2, 3 };

            // Act
            SortAlgorithms.SelectionSort(arr);

            // Assert
            arr.Should().BeInAscendingOrder();
        }

        [Fact]
        public void SelectionSort_UnorderedCollectionProvided_CollectionIsOrderedCorrectly()
        {
            // Arrange
            var arr = new int[] { 2, 1, 66, 23, 222, 3, 7, 0, -1 };

            // Act
            SortAlgorithms.SelectionSort(arr);

            // Assert
            arr.Should().BeInAscendingOrder();
        }

        [Fact]
        public void SelectionSort_DescendingOrderCollection_CollectionIsOrderedInAscending()
        {
            // Arrange
            var arr = new int[] { 4, 3, 2, 1, -1 };

            // Act
            SortAlgorithms.SelectionSort(arr);

            // Assert
            arr.Should().BeInAscendingOrder();
        }
    }
}