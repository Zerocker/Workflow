using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConvolutionMatrix.Filters;

namespace ConvolutionMatrix
{
    public partial class MainForm : Form
    {
        Bitmap originalBmp;
        Bitmap editedBmp;

        int matrixSize;

        List<IFilter> Filters = new List<IFilter>()
        {
            new HighPass3x3Filter(),
            new Blur3x3Filter(),
            new Gaussian5x5BlurFilter(),
            new Sharpen5x5Filter(),
            new IntenseSharpenFilter(),
            new EmbossFilter(),
            new Emboss45DegreeFilter(),
            new IntenseEmbossFilter(),
            new SoftenFilter()
        };

        public MainForm()
        {
            InitializeComponent();

            matrixSizes.DataSource = new List<int> { 1, 3, 5, 7 };

            matrixGridView.RowHeadersVisible = false;
            matrixGridView.ColumnHeadersVisible = false;
            matrixGridView.AllowUserToAddRows = false;

            presetsBox.DataSource = Filters;
            presetsBox.DisplayMember = "Name";

            closeToolStripMenuItem.Click += CheckFilterGroup;

            FilterEnabled();
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "bmp files (*.bmp)|*.bmp";
                dlg.InitialDirectory = Path.GetDirectoryName(Application.StartupPath);

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    originalBmp = new Bitmap(dlg.FileName);
                    editedBmp = new Bitmap(dlg.FileName);

                    originalPictureBox.LoadAsync(dlg.FileName);
                    originalPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    editedPictureBox.LoadAsync(dlg.FileName);
                    editedPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }

                FilterEnabled();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CheckFilterGroup(object sender, EventArgs e)
        {
            FilterEnabled();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            originalPictureBox.Image = null;
            editedPictureBox.Image = null;
        }

        private void FilterEnabled()
        {
            filterGroup.Enabled = (originalPictureBox.Image != null);
            editedPictureBox.Enabled = filterGroup.Enabled;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb = sender as ComboBox;
            matrixSize = (int)cmb.SelectedItem;

            matrixGridView.RowCount = matrixSize;
            matrixGridView.ColumnCount = matrixSize;
        }

        private void presetsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb = sender as ComboBox;
            var currentFilter = Filters[cmb.SelectedIndex];

            WriteDataGrid(currentFilter.Matrix);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IFilter filter;
            
            try
            {
                if (presetsBox.Text == "Custom")
                {
                    filter = new DummyFilter() { Matrix = ReadDataGrid() };
                }
                else
                {
                    filter = (IFilter)presetsBox.SelectedItem;
                }
                
                editedPictureBox.Image = originalBmp.Apply(filter);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            editedPictureBox.Image = originalBmp;
        }

        private double[,] ReadDataGrid()
        {
            var array = new double[matrixGridView.RowCount, matrixGridView.ColumnCount];
            foreach (DataGridViewRow i in matrixGridView.Rows)
            {
                foreach (DataGridViewCell j in i.Cells)
                {
                    string val = j.Value.ToString();
                    double dval = double.Parse(val, CultureInfo.InvariantCulture);
                    array[j.RowIndex, j.ColumnIndex] = dval;
                }
            }

            return array;
        }

        private void WriteDataGrid(double[,] data)
        {
            matrixGridView.Rows.Clear();

            int height = data.GetLength(0);
            int width = data.GetLength(1);

            matrixGridView.ColumnCount = width;

            for (int r = 0; r < height; r++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(matrixGridView);

                for (int c = 0; c < width; c++)
                {
                    row.Cells[c].Value = data[r, c];
                }

                matrixGridView.Rows.Add(row);
            }

            matrixSizes.Text = width.ToString();
            matrixGridView.Update();
            matrixGridView.Refresh();
        }

        private void matrixGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            presetsBox.Text = "Custom";
        }
    }
}
