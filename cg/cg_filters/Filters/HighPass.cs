using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConvolutionMatrix.Filters
{
    public class HighPass3x3Filter : IFilter
    {
        public string Name { get; set; } = "HighPass 3x3";

        public double Factor { get; set; } = 1.0 / 16.0;

        public double Offset { get; set; } = 128.0;

        public double[,] Matrix { get; set; } = new double[,] 
        { { -1, -2, -1, },
        { -2, 12, -2, },
        { -1, -2, -1, }, };
    }
}
