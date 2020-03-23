using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConvolutionMatrix.Filters
{
    public class Sharpen5x5Filter : IFilter
    {
        public string Name { get; set; } =  "Sharpen 5x5";

        public double Factor { get; set; } = 1.0 / 8.0;

        public double Offset { get; set; } = 0.0;

        public double[,] Matrix { get; set; } = new double[,]
        { { -1, -1, -1, -1, -1, },
        { -1,  2,  2,  2, -1, },
        { -1,  2,  8,  2,  1, },
        { -1,  2,  2,  2, -1, },
        { -1, -1, -1, -1, -1, }, };
    }

    public class IntenseSharpenFilter : IFilter
    {
        public string Name { get; set; } = "Intense Sharpen";

        public double Factor { get; set; } = 1.0;

        public double Offset { get; set; } = 0.0;

        public double[,] Matrix { get; set; } = new double[,]
        { { 1,  1,  1, },
        { 1, -7,  1, },
        { 1,  1,  1, }, };
    }
}
