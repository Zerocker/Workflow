using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvolutionMatrix.Filters
{
    public class DummyFilter : IFilter
    {
        public string Name { get; set; } = "Dummy";

        public double Factor { get; set; } = 1.0f;

        public double Offset { get; set; } = 0.0f;

        public double[,] Matrix { get; set; }
    }
}

