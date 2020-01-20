using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace CacheSimulator
{
    public partial class Window : Form
    {
        Memory Memory;
        Cache Cache;
        int PageIndex, RowIndex, ItemIndex;

        public Window()
        {
            InitializeComponent();

            Memory = new Memory("Memory.bin");
            Cache = new Cache();

            PageSelectBox.SelectedIndexChanged += DisplayPage;
        }

        private void Window_Load(object sender, EventArgs e)
        {
            MemoryUIBox.Text = Memory.ToString();
            CacheUIBox.Text = Cache.Display();
            TagUIBox.Text = Cache.DisplayTags();
        }

        private void DisplayPage(object sender, EventArgs e)
        {
            var PageNumber = Convert.ToUInt16(PageSelectBox.SelectedItem.ToString());
            MemoryUIBox.Text = Memory.ToString(PageNumber - 1);
        }

        private void SetButton_Click(object sender, EventArgs e)
        {
            PageIndex =  Convert.ToInt32(PageSelect.Text) - 1;
            RowIndex =   Convert.ToInt32(RowSelect.Text) - 1;
            ItemIndex =  Convert.ToInt32(ItemSelect.Text) - 1;
            var CompareTag = Cache.Tags[RowIndex];

            if (CompareTag != PageIndex)
            {

                var Watch = Stopwatch.StartNew();

                ushort[] TempRow = Memory.GetRow(PageIndex, RowIndex);

                Cache.Set(TempRow, PageIndex, RowIndex);

                Watch.Stop();

                DebugLog.Text = $"Loaded from Memory: {Cache.Values[RowIndex, ItemIndex]} " +
                                $"from {Cache.Display(RowIndex)}, elapsed in {Watch.ElapsedTicks} ticks";
            }
            else
            {
                var Watch = Stopwatch.StartNew();

                DebugLog.Text = $"Found in Cache: {Cache.Values[RowIndex, ItemIndex]} " +
                                $"from {Cache.Display(RowIndex)}, elapsed in {Watch.ElapsedTicks} ticks";

                Watch.Stop();
            }

            CacheUIBox.Text = Cache.Display();
            TagUIBox.Text = Cache.DisplayTags();
        }
    }
}
