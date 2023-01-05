using EzCollections.Queues;
using FluentAssertions;

namespace EzCollections.Tests
{
    public class LinkedListBasedQueueTests
    {
        [Fact]
        public void Queue_ElementProvided_ElementQueued()
        {
            // Arrange
            var queue = new LinkedListBasedQueue<int>();

            // Act
            queue.Enqueue(8);

            // Assert
            queue.IsEmpty.Should().BeFalse();
            queue.First.Should().Be(8);
            queue.Last.Should().Be(8);
            queue.Should().HaveCount(1);
        }

        [Fact]
        public void Queue_NotEmptyQueue_CorrectOrderIsPreserved()
        {
            // Arrange
            var queue = new LinkedListBasedQueue<int>();
            queue.Enqueue(8);
            queue.Enqueue(88);

            // Act
            queue.Enqueue(888);

            // Assert
            queue.First.Should().Be(8);
            queue.Last.Should().Be(888);
            queue.Should().HaveCount(3);
            queue.Should().BeEquivalentTo(new int[] { 8, 88, 888 });
        }

        [Fact]
        public void Dequeue_QueueIsEmpty_ThrowsInvalidOperation()
        {
            // Arrange
            var queue = new LinkedListBasedQueue<int>();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Fact]
        public void Dequeue_OneElementExist_QueueBecomesEmpty()
        {
            // Arrange
            var queue = new LinkedListBasedQueue<int>();
            queue.Enqueue(8);

            // Act
            var actual = queue.Dequeue();

            // Assert
            actual.Should().Be(8);
            queue.IsEmpty.Should().BeTrue();
            queue.Should().HaveCount(0);
            ((Func<int>)(() => queue.First)).Should().Throw<InvalidOperationException>();
            ((Func<int>)(() => queue.Last)).Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Dequeue_SomeElementsExist_CloseToRealUseSimulation()
        {
            // Arrange
            var queue = new LinkedListBasedQueue<int>();
            var roleModel = new Queue<int>();
            var random = new Random();

            // Act
            foreach (var i in Enumerable.Range(0, 10))
            {
                queue.Enqueue(i);
                roleModel.Enqueue(i);

                if (random.Next(1) == 1)
                    queue.Dequeue().Should().Be(roleModel.Dequeue());
            }

            // Assert
            queue.Should().BeEquivalentTo(roleModel.AsEnumerable());
        }
    }
}
