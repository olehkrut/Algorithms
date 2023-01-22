namespace ConvexHull.Tests
{
    public class CoordinateSystemTests
    {
        [Fact]
        public void CalculateConvexHull_AllFivePointsCreateConvexHull_ReturnsAllFivePoints()
        {
            // Arrange
            var system = new CoordinateSystem()
            {
                new Point(8, 1),
                new Point(5, 4),
                new Point(2, 3),
                new Point(3, 8),
                new Point(-1, 0),
                new Point(4, 2)
            };

            var comparer = new PolarAngleComparer(new Point(-1, 0));
            var result = comparer.Compare(new Point(5, 4), new Point(3, 8));

            // Act
            var convexHull = system.CalculateConvexHull();

            // Assert
        }
    }
}