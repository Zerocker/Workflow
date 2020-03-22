using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConvolutionMatrix.Filters
{
    public class Blur3x3Filter : IFilter
    {
        public string Name { get; set; } = "Blur 3x3";

        public double Factor { get; set; } = 1.0d;

        public double Offset { get; set; } = 0.0;

        public double[,] Matrix { get; set; } = new double[,] 
        { { 0.0, 0.2, 0.0, }, 
        { 0.2, 0.2, 0.2, }, 
        { 0.0, 0.2, 0.2, }, };
    }

    public class Gaussian5x5BlurFilter : IFilter
    {
        public string Name { get; set; } = "Gaussian Blur 5x5";

        public double Factor { get; set; } = 1.0 / 159.0;

        public double Offset { get; set; } = 0.0;

        public double[,] Matrix { get; set; } = new double[,] 
        { { 2, 04, 05, 04, 2 }, 
        { 4, 09, 12, 09, 4 }, 
        { 5, 12, 15, 12, 5 },
        { 4, 09, 12, 09, 4 },
        { 2, 04, 05, 04, 2 }, };
    }
}
