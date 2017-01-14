using Microsoft.VisualStudio.TestTools.UnitTesting;
using PipExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipExtensions.Tests
{
    [TestClass()]
    public class MatrixExtensionsTests
    {
        [TestMethod()]
        public void SwapRawsTest()
        {
            var matrix = new[,] {{1, 0, 1}, {1, 0, 0}, {0, 1, 0}};
            var ret = matrix.SwapRaws(1, 2);
            var ans = new[,] {{1, 0, 1}, {0, 1, 0}, {1, 0, 0}};
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    Assert.AreEqual(ret[i, j], ans[i, j]);
                }
            }
        }

        [TestMethod()]
        public void SwapColsTest()
        {
            var matrix = new[,] {{1, 0, 1}, {1, 0, 0}, {0, 1, 0}};
            var ret = matrix.SwapCols(0, 1);
            var ans = new[,] {{0, 1, 1}, {0, 1, 0}, {1, 0, 0}};
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    Assert.AreEqual(ret[i, j], ans[i, j]);
                }
            }
        }

        [TestMethod()]
        public void OrderRawsTest()
        {
            var matrix = new[,] {{1, 0, 1}, {1, 0, 0}, {0, 1, 0}};
            var ret = matrix.OrderRaws(new[] {0, 2, 1});
            var ans = new[,] {{1, 0, 1}, {0, 1, 0}, {1, 0, 0}};
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    Assert.AreEqual(ret[i, j], ans[i, j]);
                }
            }
        }

        [TestMethod()]
        public void OrderColsTest()
        {
            var matrix = new[,] {{1, 0, 1}, {1, 0, 0}, {0, 1, 0}};
            var ret = matrix.OrderCols(new[] {1, 0, 2});
            var ans = new[,] {{0, 1, 1}, {0, 1, 0}, {1, 0, 0}};
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    Assert.AreEqual(ret[i, j], ans[i, j]);
                }
            }
        }

        [TestMethod()]
        public void MulTest()
        {
            var a = new double[,] {{1, 2}, {3, 4}};
            var b = new double[,] {{0, 1}, {2, 3}};
            var c = new double[,] {{4, 7}, {8, 15}};
            var d = a.Mul(b);
            for (var i = 0; i < 4; i++)
            {
                Assert.AreEqual(c[i/2, i%2], d[i/2, i%2]);
            }
        }

        [TestMethod()]
        public void InverseTest()
        {
            var a = new double[,] {{1, 2}, {3, 4}};
            var b = a.Mul(a.Inverse());
            var c = new double[,] {{1, 0}, {0, 1}};
            for (var i = 0; i < 4; i++)
            {
                Assert.AreEqual(b[i/2, i%2], c[i/2, i%2], 1e-6);
            }
        }

        [TestMethod()]
        public void PseudoInverseTest()
        {
            var a = new double[,] {{1, 2, 3}, {4, 5, 6}};
            var b = a.Mul(a.PseudoInverse());
            var c = new double[,] {{1, 0}, {0, 1}};
            for (var i = 0; i < 4; i++)
            {
                Assert.AreEqual(b[i/2, i%2], c[i/2, i%2], 1e-6);
            }
            var d = new double[,] {{1, 2}, {3, 4}, {5, 6}};
            var e = d.PseudoInverse().Mul(d);
            for (var i = 0; i < 4; i++)
            {
                Assert.AreEqual(e[i/2, i%2], c[i/2, i%2], 1e-6);
            }
        }

        [TestMethod()]
        public void PrintTest()
        {
            var d = new double[,] {{1, 2}, {3, 4}, {5, 6}};
            d.Print();
        }
    }
}