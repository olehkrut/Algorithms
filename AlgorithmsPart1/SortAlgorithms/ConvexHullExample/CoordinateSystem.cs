using EzCollections.Stacks;
using Sorting.Elementary;
using System.Collections;

namespace ConvexHull
{
    public record Point(double X, double Y);

    public class CoordinateSystem : IEnumerable<Point>
    {
        private readonly List<Point> _points;

        public CoordinateSystem()
        {
            _points = new List<Point>();
        }

        public CoordinateSystem(IEnumerable<Point> points)
        {
            _points = new List<Point>(points);
        }

        public void Add(Point point)
            => _points.Add(point);

        public IReadOnlyCollection<Point> CalculateConvexHull()
        {
            var hull = new ListBasedStack<Point>();
            var workingSet = _points.ToList();

            InsertionSort.Sort(workingSet, new YCoordinateComparer());
            InsertionSort.Sort(workingSet, new PolarAngleComparer(workingSet[0]));

            hull.Push(workingSet[0]);
            hull.Push(workingSet[1]);

            for (int i = 2; i < workingSet.Count; i++)
            {
                var top = hull.Pop();
                while (!GeometryHelper.IsCounterClockWiseTurn(hull.Top, top, workingSet[i]))
                {
                    top = hull.Pop();
                }

                hull.Push(top);
                hull.Push(workingSet[i]);
            }

            return hull.ToArray();
        }

        public IEnumerator<Point> GetEnumerator()
            => _points.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
