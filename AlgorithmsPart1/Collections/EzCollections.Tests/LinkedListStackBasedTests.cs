using EzCollections.Stacks;
using FluentAssertions;

namespace EzCollections.Tests
{
    public class LinkedListBasedStackTests
    {
        [Fact]
        public void Push_ElementProvided_PushOnTheTop()
        {
            // Arrange
            var stack = new LinkedListBasedStack<int>();
            stack.Push(0);

            // Act
            stack.Push(1);

            // Assert
            stack.Top.Should().Be(1);
            stack.IsEmpty.Should().BeFalse();
        }

        [Fact]
        public void Top_StackIsEmpty_ThrowsException()
        {
            // Arrange
            var stack = new LinkedListBasedStack<int>();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => stack.Top);
        }

        [Fact]
        public void Pop_StackIsEmpty_ThrowsException()
        {
            // Arrange
            var stack = new LinkedListBasedStack<int>();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void Pop_StackHasTwoElements_TopOneIsRemoved()
        {
            // Arrange
            var stack = new LinkedListBasedStack<int>();
            stack.Push(1);
            stack.Push(2);

            // Act
            var poped = stack.Pop();

            // Assert
            poped.Should().Be(2);
            stack.Top.Should().Be(1);
            stack.IsEmpty.Should().BeFalse();
        }

        [Fact]
        public void Enumerator_StackNotEmpty_EnumeratesInReverseOrder()
        {
            // Arrange
            var stack = new ListBasedStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Act
            var enumerable = stack.AsEnumerable();

            // Assert
            enumerable.Should().BeEquivalentTo(new[] { 3, 2, 1 });
        }
    }
}
