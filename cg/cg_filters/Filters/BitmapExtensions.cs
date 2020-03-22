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
    public static class BitmapExtensions
    {
        public static Bitmap Apply(this Bitmap source, IFilter filter)
        {
            BitmapData sourceData = source.LockBits(new Rectangle(0, 0,
                                     source.Width, source.Height),
                                     ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            source.UnlockBits(sourceData);
            int filterWidth = filter.Matrix.GetLength(1);

            int filterOffset = (filterWidth - 1) / 2;
            for (int offsetY = filterOffset; offsetY < source.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX < source.Width - filterOffset; offsetX++)
                {
                    double blue = 0;
                    double green = 0;
                    double red = 0;
                    
                    int byteOffset = offsetY * sourceData.Stride + offsetX * 4;
                    
                    for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                        {

                            int calcOffset = byteOffset + (filterX * 4) + (filterY * sourceData.Stride);

                            blue += (double)(pixelBuffer[calcOffset]) *
                                    filter.Matrix[filterY + filterOffset,
                                                        filterX + filterOffset];

                            green += (double)(pixelBuffer[calcOffset + 1]) *
                                     filter.Matrix[filterY + filterOffset,
                                                        filterX + filterOffset];

                            red += (double)(pixelBuffer[calcOffset + 2]) *
                                   filter.Matrix[filterY + filterOffset,
                                                      filterX + filterOffset];
                        }
                    }

                    blue = filter.Factor * blue + filter.Offset;
                    green = filter.Factor * green + filter.Offset;
                    red = filter.Factor * red + filter.Offset;

                    if (blue > 255)
                        blue = 255;
                    else if (blue < 0)
                        blue = 0;

                    if (green > 255)
                        green = 255;
                    else if (green < 0)
                        green = 0;

                    if (red > 255)
                        red = 255;
                    else if (red < 0)
                        red = 0;

                    resultBuffer[byteOffset] = (byte)(blue);
                    resultBuffer[byteOffset + 1] = (byte)(green);
                    resultBuffer[byteOffset + 2] = (byte)(red);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap result = new Bitmap(source.Width, source.Height);
            BitmapData resultData = result.LockBits(new Rectangle(0, 0,
                                     result.Width, result.Height),
                                     ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            result.UnlockBits(resultData);

            return result;
        }
    }
}
