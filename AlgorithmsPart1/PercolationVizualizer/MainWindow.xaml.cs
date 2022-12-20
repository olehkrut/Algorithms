using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using UnionFind;

namespace PercolationVizualizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Grid _drawingGrid;
        private int _size;
        private List<(int i, int j)> _enabledCells = new List<(int i, int j)>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BuildGrid(int size)
        {
            _drawingGrid = new Grid();
            _drawingGrid.HorizontalAlignment = HorizontalAlignment.Left;
            _drawingGrid.VerticalAlignment = VerticalAlignment.Top;
            _drawingGrid.ShowGridLines = true;

            for(int i = 0; i < size; ++i)
            {
                _drawingGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star)});
                _drawingGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var rect = new Rectangle()
                    {
                        Fill = new SolidColorBrush() { Color = Colors.Black },
                        Stretch = Stretch.Fill,
                        Height = 1000000,
                        Width = 1000000,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        Name = $"box{i}{j}",
                    };

                    Grid.SetRow(rect, i);
                    Grid.SetColumn(rect, j);
                    _drawingGrid.Children.Add(rect);
                }
            }

            Grid.SetColumn(_drawingGrid, 1);
            Grid.SetRow(_drawingGrid, 0);
            MainGrid.Children.Add(_drawingGrid);
            MainGrid.UpdateLayout();
        }

        private async void Start_Click(object sender, RoutedEventArgs e)
        {
            if (_drawingGrid != null)
                MainGrid.Children.Remove(_drawingGrid);

            _size = int.Parse(txtGridSize.Text);

            BuildGrid(_size);

            await LetsStartTheShow();
        }

        private async Task LetsStartTheShow()
        {
            const int extraTwoRoots = 2;
            var uf = new QuickUnionUF(_size * _size + extraTwoRoots);

            while (true)
            {
                var random = new Random();
                var i = random.Next(_size);
                var j = random.Next(_size);

                RecordInUnion(uf, i, j);

                var cell = _drawingGrid.Children.OfType<Rectangle>().First(r => r.Name == $"box{i}{j}");
                await Dispatcher.InvokeAsync(() => cell.Fill = new SolidColorBrush { Color = Colors.White });

                if (uf.Connected(0, _size * _size + 1))
                {
                    MessageBox.Show("Shit is connected");
                    break;
                }

                await Task.Delay(500);
            }
        }

        private void RecordInUnion(QuickUnionUF uf, int i, int j)
        {
            _enabledCells.Add((i, j));
            int maxIndex = _size - 1;

            if (i == 0)
                uf.Union(ToOneDimension(i, j), 0);

            if (i == maxIndex)
                uf.Union(ToOneDimension(i, j), _size * _size + 1);

            // add adjacent connection(left, top, right, bottom)
            if (_enabledCells.Contains((Math.Max(Math.Min(maxIndex, i - 1), 0), j)))
                uf.Union(ToOneDimension(i, j), ToOneDimension(Math.Min(maxIndex, i - 1), j));

            if (_enabledCells.Contains((Math.Min(maxIndex, i + 1), j)))
                uf.Union(ToOneDimension(i, j), ToOneDimension(Math.Min(maxIndex, i + 1), j));

            if (_enabledCells.Contains((i, Math.Max(Math.Min(maxIndex, j - 1), 0))))
                uf.Union(ToOneDimension(i, j), ToOneDimension(i, Math.Min(maxIndex, j - 1)));

            if (_enabledCells.Contains((i, Math.Min(maxIndex, j + 1))))
                uf.Union(ToOneDimension(i, j), ToOneDimension(i, Math.Min(maxIndex, j + 1)));

            int ToOneDimension(int i, int j)
                => Math.Max(i, 0) * _size + Math.Max(j, 0) + 1; // + 1 - taking into account first Root
        }
    }
}
