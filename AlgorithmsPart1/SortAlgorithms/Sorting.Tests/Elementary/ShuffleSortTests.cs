using FluentAssertions;
using Sorting.Elementary;

namespace Sorting.Tests.Elementary
{
    public class ShuffleSortTests
    {
        [Fact]
        public void Sort_OrderedCollectionProvided_CollectionIsShuffled()
        {
            // Arrange
            var arr = Enumerable.Range(0, 100).ToArray();
            ShuffleSort.Shuffle(arr);

            // Assert
            arr.Should().NotBeInAscendingOrder();
            arr.Should().NotBeInDescendingOrder();
        }
    }
}
