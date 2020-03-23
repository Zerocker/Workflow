using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConvolutionMatrix.Filters
{
    public class SoftenFilter : IFilter
    {
        public string Name { get; set; } = "Soften";

        public double Factor { get; set; } = 1.0 / 8.0;

        public double Offset { get; set; } = 0.0;

        public double[,] Matrix { get; set; } = new double[,]
        { { 1, 1, 1, },
        { 1, 1, 1, },
        { 1, 1, 1, }, };
    }
}
