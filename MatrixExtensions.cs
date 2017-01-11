using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipExtensions
{
    public static class MatrixExtensions
    {
        public static T[,] SwapRaws<T>(this T[,] self, int r1, int r2) where T : struct
        {
            var raws = self.GetLength(0);
            var cols = self.GetLength(1);
            if (r1 > raws || r2 > raws) throw new IndexOutOfRangeException();
            for (var i = 0; i < cols; i++)
            {
                var tmp = self[r1, i];
                self[r1, i] = self[r2, i];
                self[r2, i] = tmp;
            }
            return self;
        }

        public static T[,] SwapCols<T>(this T[,] self, int c1, int c2) where T : struct
        {
            var raws = self.GetLength(0);
            var cols = self.GetLength(1);
            if (c1 > cols || c2 > cols) throw new IndexOutOfRangeException();
            for (var i = 0; i < raws; i++)
            {
                var tmp = self[i, c1];
                self[i, c1] = self[i, c2];
                self[i, c2] = tmp;
            }
            return self;
        }

        public static T[,] OrderRaws<T>(this T[,] self, int[] order) where T : struct
        {
            var raws = self.GetLength(0);
            var cols = self.GetLength(1);
            if (raws != order.Length) throw new IndexOutOfRangeException();
            var matrix = new T[raws, cols];
            for (var i = 0; i < raws; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    matrix[i, j] = self[order[i], j];
                }
            }
            return matrix;
        }

        public static T[,] OrderCols<T>(this T[,] self, int[] order) where T : struct
        {
            var raws = self.GetLength(0);
            var cols = self.GetLength(1);
            if (cols != order.Length) throw new IndexOutOfRangeException();
            var matrix = new T[raws, cols];
            for (var i = 0; i < raws; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    matrix[i, j] = self[i, order[j]];
                }
            }
            return matrix;
        }
    }
}