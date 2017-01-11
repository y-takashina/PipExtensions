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
        }

        [TestMethod()]
        public void OrderColsTest()
        {
        }
    }
}