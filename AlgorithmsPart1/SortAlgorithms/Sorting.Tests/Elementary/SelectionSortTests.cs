using FluentAssertions;
using Sorting.Elementary;

namespace Sorting.Tests.Elementary
{
    public class SelectionSortTests
    {
        [Fact]
        public void Sort_OrderedCollectionProvided_CollectionIsStillOrdered()
        {
            // Arrange
            var arr = new int[] { 1, 2, 3 };
            SelectionSort.Sort(arr);

            // Assert
            arr.Should().BeInAscendingOrder();
        }

        [Fact]
        public void Sort_UnorderedCollectionProvided_CollectionIsOrderedCorrectly()
        {
            // Arrange
            var arr = new int[] { 2, 1, 66, 23, 222, 3, 7, 0, -1 };
            SelectionSort.Sort(arr);

            // Assert
            arr.Should().BeInAscendingOrder();
        }

        [Fact]
        public void Sort_DescendingOrderCollection_CollectionIsOrderedInAscending()
        {
            // Arrange
            var arr = new int[] { 4, 3, 2, 1, -1 };
            SelectionSort.Sort(arr);

            // Assert
            arr.Should().BeInAscendingOrder();
        }
    }
}