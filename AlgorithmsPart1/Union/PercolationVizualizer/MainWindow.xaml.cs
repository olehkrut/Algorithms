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
            var grid = new PercolationGrid(_size);

            while (true)
            {
                var random = new Random();
                var i = random.Next(_size);
                var j = random.Next(_size);

                grid.EnableCell(i, j);

                var cell = _drawingGrid.Children.OfType<Rectangle>().First(r => r.Name == $"box{i}{j}");
                await Dispatcher.InvokeAsync(() => cell.Fill = new SolidColorBrush { Color = Colors.White });

                if (grid.Percolates)
                {
                    MessageBox.Show("Shit is connected");
                    break;
                }

                await Task.Delay(500);
            }
        }
    }
}
