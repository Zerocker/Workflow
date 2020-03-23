using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConvolutionMatrix.Filters
{
    public interface IFilter
    {
        double[,] Matrix { get; set; }

        double Factor { get; set; }

        double Offset { get; set; }

        string Name { get; set; }
    }
}
