using EzCollections.Lists;
using FluentAssertions;

namespace EzCollections.Tests
{
    public class EzListTests
    {
        [Fact]
        public void Add_NoCapacityIncrease_AddedToTheEnd()
        {
            // Arrange
            var ezList = new EzList<int>(new[] {1, 2, 3 });
            var oldCapacity = ezList.Capacity;

            // Act
            ezList.Add(8);

            // Assert
            ezList.Count.Should().Be(4);
            ezList[3].Should().Be(8);
            ezList.Capacity.Should().Be(oldCapacity);
        }

        [Fact]
        public void Add_CapacityIsIncreased_AddedToTheEnd()
        {
            // Arrange
            var ezList = new EzList<int>(1)
            {
                8
            };
            var oldCapacity = ezList.Capacity;

            // Act
            ezList.Add(88);

            // Arrange
            ezList.Capacity.Should().Be(oldCapacity * 2);
            ezList.Count.Should().Be(2);
            ezList.Should().BeEquivalentTo(new[] { 8, 88 });
        }
    }
}