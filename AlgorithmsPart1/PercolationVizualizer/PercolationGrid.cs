using System;
using System.Windows.Controls;
using UnionFind;

namespace PercolationVizualizer
{
    internal class CellState
    {
        public CellState(int i, int j, bool isEnabled)
        {
            I = i;
            J = j;
            IsEnabled = isEnabled;
        }

        public int I { get; }
        public int J { get; }
        public bool IsEnabled { get; private set; }

        public CellState Top { get; set; }
        public CellState Right { get; set; }
        public CellState Bottom { get; set; }
        public CellState Left { get; set; }

        public void Enable()
            => IsEnabled = true;
    }

    internal class PercolationGrid
    {
        private readonly QuickUnionUF _uf;
        private readonly CellState[,] _grid;

        public PercolationGrid(int size)
        {
            Size = size;
            VirtualTopRoot = new CellState(-1, Size - 1, true);
            VirtualBottomRoot = new CellState(Size, Size, true);

            _uf = new QuickUnionUF(size * size + 2);
            _grid = new CellState[Size, Size];

            InitGridWithRelations(size);

        }

        private void InitGridWithRelations(int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; ++j)
                {
                    _grid[i, j] = new CellState(i, j, false);

                    if (i == 0)
                    {
                        _grid[i, j].Top = VirtualTopRoot;
                    }
                    else if (i == size - 1)
                    {
                        _grid[i, j].Bottom = VirtualBottomRoot;
                    }

                    if (j > 0)
                    {
                        _grid[i, j - 1].Right = _grid[i, j];
                        _grid[i, j].Left = _grid[i, j - 1];
                    }

                    if (i > 0)
                    {
                        _grid[i - 1, j].Bottom = _grid[i, j];
                        _grid[i, j].Top = _grid[i - 1, j];
                    }
                }
            }
        }

        public int Size { get; }
        public CellState VirtualTopRoot { get; }
        public int VirtualTopPosition => 0;
        public CellState VirtualBottomRoot { get; }
        public int VirtualBottomPosition => _uf.Count - 1;

        public bool Percolates => _uf.Connected(0, _uf.Count - 1);

        public void EnableCell(int i, int j)
        {
            var currentCell = _grid[i, j];
            currentCell.Enable();

            if (i == 0)
                _uf.Union(VirtualTopPosition, ToOneDimension(i, j));

            if (i == Size - 1)
                _uf.Union(VirtualBottomPosition, ToOneDimension(i, j));

            if (currentCell.Top.IsEnabled)
            {
                _uf.Union(
                    ToOneDimension(currentCell.I, currentCell.J),
                    ToOneDimension(i - 1, j));
            }

            if (currentCell.Bottom.IsEnabled)
            {
                _uf.Union(
                    ToOneDimension(currentCell.I, currentCell.J),
                    ToOneDimension(i + 1, j));
            }

            if (currentCell.Left?.IsEnabled ?? false)
            {
                _uf.Union(
                    ToOneDimension(currentCell.I, currentCell.J),
                    ToOneDimension(currentCell.I, currentCell.J - 1));
            }

            if (currentCell.Right?.IsEnabled ?? false)
            {
                _uf.Union(
                    ToOneDimension(currentCell.I, currentCell.J),
                    ToOneDimension(currentCell.I, currentCell.J + 1));
            }

        }

        int ToOneDimension(int i, int j)
        {
            if (i == -1)
                return 0;

            if (i == Size)
                return Size * Size + 1;

            return i * Size + j + 1; // + 1 - virtualTop element
        }
    }
}
