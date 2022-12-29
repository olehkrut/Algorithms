using EzCollections.Lists;
using FluentAssertions;
using Newtonsoft.Json.Linq;

namespace EzCollections.Tests
{
    public class EzListTests
    {
        [Fact]
        public void Add_NoCapacityIncrease_AddedToTheEnd()
        {
            // Arrange
            var ezList = new EzList<int> { 1, 2, 3 };
            var oldCapacity = ezList.Capacity;
            var roleModel = new List<int>(ezList);
            roleModel.Add(8);

            // Act
            ezList.Add(8);

            // Assert
            ezList.Count.Should().Be(4);
            ezList.Capacity.Should().Be(oldCapacity);
            ezList.Should().BeEquivalentTo(roleModel);
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

        [Theory]
        [InlineData(8, 0)]
        [InlineData(88, 1)]
        [InlineData(888, 2)]
        [InlineData(8888888, -1)]
        public void IndexOf_SomeElementIsProvided_ExpectedIndexReturned(int element, int expected)
        {
            // Arrange
            var ezList = new EzList<int> { 8, 88, 888 };

            // Act
            var actual = ezList.IndexOf(element);

            // Assert
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(0, 8)]
        [InlineData(1, 8)]
        [InlineData(2, 8)]
        public void Insert_CapacityIsNotIncreased_ElementInserted(int position, int value)
        {
            // Arrange
            var ezList = new EzList<int> { 1, 2, 3 };
            var oldCapacity = ezList.Capacity;
            var roleModel = new List<int>(ezList);
            roleModel.Insert(position, value);

            // Act
            ezList.Insert(position, value);

            // Assert
            ezList.Capacity.Should().Be(oldCapacity);
            ezList.Should().BeEquivalentTo(roleModel);
        }

        [Theory]
        [InlineData(0, 8)]
        [InlineData(1, 8)]
        [InlineData(2, 8)]
        public void Insert_CapacityIsIncreased_ElementInserted(int position, int value)
        {
            // Arrange
            var ezList = new EzList<int>(3) { 1, 2, 3 };
            var oldCapacity = ezList.Capacity;
            var roleModel = new List<int>(ezList);
            roleModel.Insert(position, value);

            // Act
            ezList.Insert(position, value);

            // Assert
            ezList.Capacity.Should().Be(oldCapacity * 2);
            ezList.Should().BeEquivalentTo(roleModel);
        }
    }
}