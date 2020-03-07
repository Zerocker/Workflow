using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lab.Schemes;

namespace Lab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Rgb RGB { get; set; }
        
        public Hsv HSV { get; set; }
        
        public Cmyk CMY { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            RGB = new Rgb(0, 0, 0);
            HSV = new Hsv(0, 0, 0);
            CMY = new Cmyk(0, 0, 0, 0);

            Change_RGB();
            Change_HSV();
            Change_CMYK();
        }

        private void Window_Render(object sender, EventArgs e)
        {

        }

        private void Rect_Pressed(object sender, MouseButtonEventArgs e)
        {
        }

        private void RGB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Console.WriteLine(RGB.ToString());
            Change_RGB();
        }

        private void HSV_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Console.WriteLine(HSV.ToString());
            Change_HSV();
        }

        private void CMYK_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Console.WriteLine(CMY.ToString());
            Change_CMYK();
        }

        private void Change_RGB()
        {
            RGBRect.Color = RGB.ToColor();
            RgbLabel.Text = RGB.ToString();
        }

        private void Change_CMYK()
        {
            var toColor = CMY.ToRgb();
            CmykRect.Color = toColor.ToColor();
            CmykLabel.Text = toColor.ToString();
        }
        
        private void Change_HSV()
        {
            var toColor = HSV.ToRgb();
            HsvRect.Color = toColor.ToColor();
            HsvLabel.Text = toColor.ToString();
        }

        private Color[] GetDefaultPalette()
        {
            return new[]
            {
                Color.FromRgb(190, 38, 51),
                Color.FromRgb(224, 111, 139),
                Color.FromRgb(73, 60, 43),
                Color.FromRgb(164, 100, 34),
                Color.FromRgb(235, 137, 49),
                Color.FromRgb(247, 226, 107),
                Color.FromRgb(47, 72, 78),
                Color.FromRgb(68, 137, 26),
                Color.FromRgb(163, 206, 39),
                Color.FromRgb(27, 38, 50),
                Color.FromRgb(0, 87, 132),
                Color.FromRgb(49, 162, 242),
                Color.FromRgb(178, 220, 239)
            };
        }

        private void ChangeColors()
        {
            
        }
    }
}
