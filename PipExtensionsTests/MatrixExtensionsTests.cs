﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var matrix = new[,] {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}};
            var ret = matrix.SwapRaws(1, 2);
            var ans = new[,] {{1, 2, 3}, {7, 8, 9}, {4, 5, 6}};
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
            var matrix = new[,] {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}};
            var ret = matrix.SwapCols(1, 2);
            var ans = new[,] {{1, 3, 2}, {4, 6, 5}, {7, 9, 8}};
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
            var matrix = new[,] {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}};
            var ret = matrix.OrderRaws(new[] {0, 2, 1});
            var ans = new[,] {{1, 2, 3}, {7, 8, 9}, {4, 5, 6}};
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
            var matrix = new[,] {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}};
            var ret = matrix.OrderCols(new[] {0, 2, 1});
            var ans = new[,] {{1, 3, 2}, {4, 6, 5}, {7, 9, 8}};
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    Assert.AreEqual(ret[i, j], ans[i, j]);
                }
            }
        }

        [TestMethod()]
        public void MulTest1()
        {
            var a = new double[,] {{1, 2}, {3, 4}};
            var b = new double[] {1, 2};
            var c = new double[] {5, 11};
            var d = a.Mul(b);
            for (var i = 0; i < 2; i++)
            {
                Assert.AreEqual(c[i], d[i]);
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
            var unit = new double[,] {{1, 0}, {0, 1}};
            // m < n なら右逆元
            var a = new double[,] {{1, 2, 3}, {4, 5, 6}};
            var b = a.Mul(a.PseudoInverse());
            for (var i = 0; i < 4; i++)
            {
                Assert.AreEqual(b[i/2, i%2], unit[i/2, i%2], 1e-6);
            }
            // m > n なら左逆元
            var c = new double[,] {{1, 2}, {3, 4}, {5, 6}};
            var d = c.PseudoInverse().Mul(c);
            for (var i = 0; i < 4; i++)
            {
                Assert.AreEqual(d[i/2, i%2], unit[i/2, i%2], 1e-6);
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