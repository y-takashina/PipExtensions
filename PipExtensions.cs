using System;
using System.Collections.Generic;
using System.Linq;

namespace PipExtensions
{
    public static class PipExtensions
    {
        public static double StandardDeviation(this IEnumerable<double> values)
        {
            var array = values as double[] ?? values.ToArray();
            if (!array.Any()) return 0;
            var avg = array.Average();
            var sum = array.Sum(x => Math.Pow(x - avg, 2));
            return Math.Sqrt(sum/array.Length);
        }

        public static double Entropy(this IEnumerable<double> probabilities)
        {
            return probabilities.Where(p => Math.Abs(p) > 1e-300).Sum(p => -p*Math.Log(p, 2));
        }

        public static double Entropy<T>(this IEnumerable<T> series)
        {
            var array = series.ToArray();
            var points = array.Distinct().ToArray();
            var probabilities = points.Select(v1 => (double) array.Count(v2 => Equals(v1, v2))/array.Length);
            return probabilities.Entropy();
        }

        public static double JointEntropy(IEnumerable<int> series1, IEnumerable<int> series2)
        {
            return series1.Zip(series2, Tuple.Create).Entropy();
        }

        public static double MutualInformation(int[] series1, int[] series2)
        {
            return series1.Entropy() + series2.Entropy() - JointEntropy(series1, series2);
        }

        public static double Erf(double x)
        {
            const double a1 = 0.254829592;
            const double a2 = -0.284496736;
            const double a3 = 1.421413741;
            const double a4 = -1.453152027;
            const double a5 = 1.061405429;
            const double p = 0.3275911;

            var sign = Math.Sign(x);
            x = Math.Abs(x);

            var t = 1.0/(1.0 + p*x);
            var y = 1.0 - ((((a5*t + a4)*t + a3)*t + a2)*t + a1)*t*Math.Exp(-x*x);

            return sign*y;
        }

        public static double Erfc(double x)
        {
            return 1 - Erf(x);
        }

        public static double QFunction(double x, double mean, double standardDeviation)
        {
            if (x < mean) x = 2*mean - x;
            var z = (x - mean)/standardDeviation;
            return Erfc(z/Math.Sqrt(2))/2;
        }
    }
}