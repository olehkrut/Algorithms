namespace ConvexHull
{
    public static class GeometryHelper
    {
        /// <summary>
        /// When area of triangle described by given points is positive - then it's CounterClockWise turn.
        /// </summary>
        public static bool IsCounterClockWiseTurn(Point a, Point b, Point c)
            => FindTriangleArea(a, b, c) > 0;

        /// <summary>
        /// It finds area of based on vectors and finding a determinant of given matrix:
        /// |a.X, a.Y, 1|
        /// |b.X, b.Y, 1|
        /// |c.X, c.Y, 1|
        /// </summary>
        public static double FindTriangleArea(Point a, Point b, Point c)
            => (b.X - a.X * c.Y - a.Y) - (b.Y - a.Y * c.X - a.X);
    }
}
