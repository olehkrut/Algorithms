namespace ConvexHull
{
    public class YCoordinateComparer : IComparer<Point>
    {
        public int Compare(Point x, Point y)
            => Comparer<double>.Default.Compare(x.Y, y.Y);
    }

    public class PolarAngleComparer : IComparer<Point>
    {
        private readonly Point _origin;

        public PolarAngleComparer(Point? origin = null)
        {
            _origin = origin ?? new Point(0, 0);
        }

        public int Compare(Point a, Point b)
        {
            var angleToA = Math.Atan2(a.Y - _origin.Y, a.X - _origin.X);
            var angleToB = Math.Atan2(b.Y - _origin.Y, b.X - _origin.X);

            return Comparer<double>.Default.Compare(angleToA, angleToB);
        }
    }

    public static class PointComparer
    {
        public static int CompareByY(Point a, Point b)
            => Comparer<double>.Default.Compare(a.Y, b.Y);

        //public static int CompareByPolarAngle(Point a, Point b)
        //{

        //}

    }
}
