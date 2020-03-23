using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConvolutionMatrix.Filters
{
    public class EmbossFilter : IFilter
    {
        public string Name { get; set; } = "Emboss";

        public double Factor { get; set; } = 1.0;

        public double Offset { get; set; } = 128.0;

        public double[,] Matrix { get; set; } = new double[,]
        { { 2, 0, 0, },
        { 0,-1, 0, },
        { 0, 0,-1, }, };
    }

    public class Emboss45DegreeFilter : IFilter
    {
        public string Name { get; set; } = "Emboss 45-Degree";

        public double Factor { get; set; } = 1.0;

        public double Offset { get; set; } = 128.0;

        public double[,] Matrix { get; set; } = new double[,]
        { { -1, -1, 0, },
        { -1,  0, 1, },
        {  0,  1, 1, }, };
    }

    public class IntenseEmbossFilter : IFilter
    {
        public string Name { get; set; } = "Intense Emboss";

        public double Factor { get; set; } = 1.0;

        public double Offset { get; set; } = 128.0;

        public double[,] Matrix { get; set; } =
            new double[,] { { -1, -1, -1, -1,  0, },
                            { -1, -1, -1,  0,  1, },
                            { -1, -1,  0,  1,  1, },
                            { -1,  0,  1,  1,  1, },
                            {  0,  1,  1,  1,  1, }, };
    }
}
