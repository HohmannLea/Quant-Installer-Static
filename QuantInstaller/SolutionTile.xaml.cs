using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

namespace BrukerAXS.QuantInstaller
{
    /// <summary>
    /// Interaction logic for SolutionTile.xaml
    /// </summary>
    public partial class SolutionTile : UserControl
    {
        public string methodName;
        public string instrumentName;
        public string baseDirectory;
        public Functions functions;

        public SolutionTile(string instrumentName, string methodName)
        {
            this.instrumentName = instrumentName;
            this.methodName = methodName;
            this.baseDirectory = $"{Environment.CurrentDirectory}\\Files\\{instrumentName}\\{methodName}\\";
            this.functions = new Functions();
            InitializeComponent();
            txtSolutionName.Text = methodName;
            CheckForIcon();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            functions.InstallSolution(instrumentName, methodName);
        }

        private void CheckForIcon()
        {
            if (File.Exists($"{baseDirectory}\\icon.jpg"))
            {
                string imagePath = $"{baseDirectory}\\icon.jpg";
                BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath));
                TileIcon.Source = bitmapImage;
                TileLogo.Visibility = Visibility.Collapsed;
            }
            else if (File.Exists($"{baseDirectory}\\icon.png"))
            {
                string imagePath = $"{baseDirectory}\\icon.png";
                BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath));
                TileIcon.Source = bitmapImage;
                TileLogo.Visibility = Visibility.Collapsed;
            }
            else
            {
                TileLogo.Visibility = Visibility.Visible;
                TileIcon.Visibility = Visibility.Collapsed;
            }
        }
    }
}
