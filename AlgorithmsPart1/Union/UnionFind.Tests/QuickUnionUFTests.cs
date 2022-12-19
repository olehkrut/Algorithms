using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind.Tests
{
    public class QuickUnionUFTests
    {
        private static IEnumerable<(int first, int second)> ThreeConnectedSetsTestData
            => new[]
                {
                    (1, 4), (4, 5),
                    (2, 3), (6, 2), (6, 3), (3, 7)
                };

        [Fact]
        public void ReflexivePropertyIsPreserved()
        {
            // Arrange
            var uf = new QuickUnionUF(2);

            // Act
            var isConnected = uf.Connected(1, 1);

            // Assert
            isConnected.Should().BeTrue();
        }

        [Fact]
        public void SymetricPropertyIsPreserved()
        {
            // Arrange
            var uf = new QuickUnionUF(2);
            uf.Union(0, 1);

            // Act & Assert
            uf.Connected(0, 1).Should().BeTrue();
            uf.Connected(0, 1).Should().Be(uf.Connected(1, 0));
        }

        [Fact]
        public void TransitivePropertyIsPreserved()
        {
            // Arrange
            var uf = new QuickUnionUF(3);
            uf.Union(0, 1);
            uf.Union(1, 2);

            // Act
            var isConnected = uf.Connected(0, 2);

            // Assert
            isConnected.Should().BeTrue();
        }

        [Fact]
        public void EightElementsUFProvided_ThreeConnectedSetsMade_UnionConnectingDotsCorrectly()
        {
            // Arrange
            var uf = new QuickUnionUF(8);

            foreach (var connection in ThreeConnectedSetsTestData)
                uf.Union(connection.first, connection.second);

            // Act
            var numOfConnectedSets = uf.GetNumberOfConnectedSets();

            // Assert
            numOfConnectedSets.Should().Be(3);

            uf.Connected(1, 5).Should().BeTrue();
            uf.Connected(2, 7).Should().BeTrue();
        }
    }
}
