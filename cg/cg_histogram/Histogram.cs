using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    public enum Channel
    {
        Red = 0, Green, Blue, Mixed
    }

    public class Histogram
    {
        public static int Width { get; } = 255;

        public static int Height { get; set; } = 100;

        public static Dictionary<double, double> CountByChannel(Bitmap bmp, Channel channel)
        {
            var occurences = new Dictionary<double, double>();
            for (int i = 0; i < 256; i++)
            {
                occurences.Add(i, 0);
            }

            for (int w = 0; w < bmp.Width; w++)
            {
                for (int h = 0; h < bmp.Height; h++)
                {
                    var rgb = bmp.GetPixel(w, h);

                    double key = 0.0;
                    switch (channel)
                    {
                        case Channel.Red:
                            key = (double)rgb.R;
                            break;
                        case Channel.Green:
                            key = (double)rgb.G;
                            break;
                        case Channel.Blue:
                            key = (double)rgb.B;
                            break;
                    }

                    if (occurences.ContainsKey(key))
                        occurences[key] += 1;
                    else
                        occurences.Add((double)w, 0);
                }
            }

            return occurences;
        }

        public static Dictionary<double, double> CountAsWhole(Bitmap bmp)
        {
            var red = CountByChannel(bmp, Channel.Red);
            var green = CountByChannel(bmp, Channel.Green);
            var blue = CountByChannel(bmp, Channel.Blue);
            return CountAsWhole(red, green, blue);
        }

        public static Dictionary<double, double> CountAsWhole(Dictionary<double, double> a, Dictionary<double, double> b, Dictionary<double, double> c)
        {
            var result = new Dictionary<double, double>();
            for (int i = 0; i < 256; i++)
            {
                var avg = (a[i] + b[i] + c[i]) / 3;
                result.Add(i, avg);
            }
            return result;
        }

        public static List<double> CountIndices(Bitmap bmp, Channel channel)
        {
            var pixels = new List<double>();
            for (int w = 0; w < bmp.Width; w++)
            {
                for (int h = 0; h < bmp.Height; h++)
                {
                    var rgb = bmp.GetPixel(w, h);
                    double key = 0.0;
                    switch (channel)
                    {
                        case Channel.Red:
                            key = (double)rgb.R;
                            break;
                        case Channel.Green:
                            key = (double)rgb.G;
                            break;
                        case Channel.Blue:
                            key = (double)rgb.B;
                            break;
                    }

                    pixels.Add(key);
                }
            }

            return pixels;
        }

        public static Bitmap Create(Dictionary<double, double> channel, Color color)
        {
            double maxValue = 0.0;
            foreach (var item in channel)
                maxValue = (item.Value > maxValue) ? item.Value : maxValue;

            var resultBmp = new Bitmap(Width, Height);
            for (int w = 0; w < Width; w++)
                for (int h = 0; h < Height; h++)
                    resultBmp.SetPixel(w, h, color);

            int cc = 0;
            for (double i = 0; i < Width; i++)
            {
                if (channel.ContainsKey(i))
                {
                    int height = Convert.ToInt32((channel[i] / maxValue) * (double)Height);
                    height = height > 199 ? 199 : height;
                    for (int ck = (Height - 1) - height; ck >= 0; ck--)
                    {
                        resultBmp.SetPixel(cc, ck, Color.FromArgb(255, 16, 16, 16));
                    }
                }
                else
                    continue;

                cc++;
            }

            return resultBmp;
        }

        public static Dictionary<double, double> BuildCast(Bitmap customBmp)
        {
            var noise = new Random();
            var result = new Dictionary<double, double>();
            for (int i = 0; i < 256; i++)
            {
                result.Add(i, noise.NextDouble());
            }

            for (int w = 0; w < customBmp.Width; w++)
            {
                for (int h = 0; h < customBmp.Height; h++)
                {
                    if (customBmp.GetPixel(w, h) != Color.FromArgb(255, 0, 0, 0))
                    {
                        //var ratio = (double)h / (double)customBmp.Height;
                        //result[(double)w] = 1.0 - ratio;

                        result[(double)w] = customBmp.Height - h;
                        break;
                    }
                }
            }
            return result;
        }

        private static List<double> Linear(List<double> x, List<double> xp, List<double> fp)
        {
            if (xp.Count != fp.Count)
            {
                throw new Exception("X and Y must be the same length");
            }
            if (xp.Count == 1)
            {
                throw new Exception("X must contain more than one value");
            }

            double[] dx = new double[xp.Count - 1];
            double[] dy = new double[xp.Count - 1];
            double[] slope = new double[xp.Count - 1];
            double[] intercept = new double[xp.Count - 1];

            for (int i = 0; i < xp.Count - 1; i++)
            {
                dx[i] = xp[i + 1] - xp[i];
                if (dx[i] == 0 || dx[i] < 0)
                {
                    throw new Exception("X must be montotonic or sorted!");
                }

                dy[i] = fp[i + 1] - fp[i];
                slope[i] = dy[i] / dx[i];
                intercept[i] = fp[i] - xp[i] * slope[i];
            }

            // Perform the interpolation here
            double[] yi = new double[x.Count];
            for (int i = 0; i < x.Count; i++)
            {
                if ((x[i] > xp[xp.Count - 1]) || (x[i] < xp[0]))
                {
                    yi[i] = 255;
                }
                else
                {
                    int loc = Array.BinarySearch(xp.ToArray(), x[i]);
                    if (loc < -1)
                    {
                        loc = -loc - 2;
                        yi[i] = slope[loc] * x[i] + intercept[loc];
                    }
                    else
                    {
                        yi[i] = fp[loc];
                    }
                }
            }

            return yi.ToList();
        }

        public static double[,] MatchCDF(Bitmap image, Dictionary<double, double> template, Channel channel)
        {
            var source = CountByChannel(image, channel);
            var srcPixels = CountIndices(image, channel);

            var total = image.Width * image.Height;
            var srcQuantiles = source.Values.CumulativeSum().Select(d => d / total).ToList();
            var tmpQuantiles = template.Values.CumulativeSum().Select(d => d / total).ToList();

            var tmpValues = template.Keys.ToList();
            var interpValues = Linear(srcQuantiles, tmpQuantiles, tmpValues);

            var matching = new List<double>();
            foreach (var idx in srcPixels)
            {
                matching.Add(interpValues[(int)idx]);
            }

            var result = new double[image.Width, image.Height];
            for (int i = 0; i < image.Width; i++)
                for (int j = 0; j < image.Height; j++)
                    result[i, j] = matching[i * image.Height + j];

            return result;
        }

        public static void ApplyChannel(Bitmap image, Channel channel, double[,] newChannel)
        {
            if (newChannel.GetLength(0) != image.Width || newChannel.GetLength(1) != image.Height)
                throw new Exception("Сan't apply a new channel: the dimensions don't match");

            for (int w = 0; w < image.Width; w++)
            {
                for (int h = 0; h < image.Height; h++)
                {
                    double value = newChannel[w, h];
                    Color old_ = image.GetPixel(w, h);
                    Color new_ = old_;

                    switch (channel)
                    {
                        case Channel.Red:
                            new_ = Color.FromArgb(old_.A, (int)value, old_.G, old_.B);
                            break;
                        case Channel.Green:
                            new_ = Color.FromArgb(old_.A, old_.R, (int)value, old_.B);
                            break;
                        case Channel.Blue:
                            new_ = Color.FromArgb(old_.A, old_.R, old_.G, (int)value);
                            break;
                    }

                    image.SetPixel(w, h, new_);
                }
            }

            return;
        }

        public static Bitmap DrawChannel(double[,] newData, Channel channel)
        {
            var bmp = new Bitmap(newData.GetLength(0), newData.GetLength(1));

            for (int w = 0; w < newData.GetLength(0); w++)
            {
                for (int h = 0; h < newData.GetLength(1); h++)
                {
                    switch (channel)
                    {
                        case Channel.Red:
                            bmp.SetPixel(w, h, Color.FromArgb(255, (int)newData[w, h], 0, 0));
                            break;
                        case Channel.Green:
                            bmp.SetPixel(w, h, Color.FromArgb(255, 0, (int)newData[w, h], 0));
                            break;
                        case Channel.Blue:
                            bmp.SetPixel(w, h, Color.FromArgb(255, 0, 0, (int)newData[w, h]));
                            break;
                    }
                }
            }

            return bmp;
        }
    }

    public static class Extensions
    {
        public static IEnumerable<double> CumulativeSum(this IEnumerable<double> sequence)
        {
            double sum = 0;
            foreach (var item in sequence)
            {
                sum += item;
                yield return sum;
            }
        }

        public static void RemoveHeadTail(this List<double> sequence)
        {
            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i] == 0)
                {
                    sequence.RemoveAt(i);
                    i--;
                }
                else
                {
                    sequence[i] = 0;
                    break;
                }
            }

            for (int i = sequence.Count-1; i >= 0; i--)
            {
                if (sequence[i] == 1)
                {
                    sequence.RemoveAt(i);
                }
                else
                {
                    sequence[i] = 1;
                    break;
                } 
            }
        }
    }
}
