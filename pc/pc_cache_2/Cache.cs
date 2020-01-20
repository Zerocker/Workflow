using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheSimulator
{
    class Cache
    {
        public ushort[,] Values { get; }
        public int[] Tags { get; set; }

        public Cache()
        {
            Values = new ushort[Globals.Rows, Globals.Items];
            Tags = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };


            for (int i = 0; i < Globals.Rows; i++)
            {
                for (int j = 0; j < Globals.Items; j++)
                {
                    Values[i, j] = 1111;
                }
            }
        }

        public void Set(ushort[] Row, int PageIndex, int RowIndex)
        {
            for (int i = 0; i < Globals.Items; i++)
            {
                Values[RowIndex, i] = Row[i];
            }

            Tags[RowIndex] = PageIndex;
        }

        public string DisplayTags()
        {
            string Output = "";

            foreach (var value in Tags)
            {
                Output += $"{value + 1}\n";
            }

            return Output;
        }


        public string Display(int row = -1)
        {
            string Output = "";
            switch (row)
            {
                case -1:
                    for (int i = 0; i < Globals.Rows; i++)
                    {
                        for (int j = 0; j < Globals.Items; j++)
                        {
                            Output += $"{Values[i, j],6}";
                        }
                        Output += "\n";
                    }
                    break;

                default:
                    Output = $"[ {Values[row, 0]}, {Values[row, 1]}, " +
                             $"{Values[row, 2]}, {Values[row, 3]}]";
                    break;
            }
            return Output;
        }
    }
}
