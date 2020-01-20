using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CacheSimulator
{
    class Memory
    {
        private string Filename { get; }
        private ushort Adress { get; set; }

        BinaryWriter Bin;
        BinaryReader Bout;

        public Memory(string Filename)
        {
            this.Filename = Filename;
            Random Generator = new Random();
            try
            {
                if (!File.Exists(this.Filename))
                {
                    using (Bin = new BinaryWriter(File.Open(this.Filename, FileMode.Create)))
                    {
                        for (int i = 0; i < 400; i++)
                        {
                            var Num = Generator.Next(1000, 9999);
                            Bin.Write(Convert.ToUInt16(Num));
                        }
                    }
                }
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message);
            }
        }

        public ushort[] GetRow(int page = 0, int row = 0)
        {
            using (Bout = new BinaryReader(File.Open(Filename, FileMode.Open)))
            {
                Bout.BaseStream.Position = 2 * (Globals.Rows * page + Globals.Items * row);
                return new ushort[] { Bout.ReadUInt16(), Bout.ReadUInt16(), Bout.ReadUInt16(), Bout.ReadUInt16()};
            }
        }

        public string ToString(int page = 0)
        {
            string Result = "";

            using (Bout = new BinaryReader(File.Open(Filename, FileMode.Open)))
            {
                for (int j = 0; j < Globals.Rows; j++)
                {
                    //Result += $"{page+1},{j+1:D2} | ";
                    for (int k = 0; k < Globals.Items; k++)
                    {
                        Bout.BaseStream.Position = 2 * (Globals.Rows * page + Globals.Items * j + k);
                        Result += $"{Bout.ReadUInt16(), 8}";
                    }
                    Result += "\n";
                }
            }

            return Result;
        }

        public string ToLine(int page = 0, int row = 0)
        {
            string Result = "";

            using (Bout = new BinaryReader(File.Open(Filename, FileMode.Open)))
            {
                for (int i = 0; i < 4; i++)
                {
                    Bout.BaseStream.Position = 2 * (Globals.Rows * page + Globals.Items * row + i);
                    Result += $"{Bout.ReadUInt16(), 8}";
                }
            }
            return Result;
        }
    }
}
