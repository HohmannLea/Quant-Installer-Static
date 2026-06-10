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
        public string solutionName;
        public string baseDirectory;
        public MainWindow mainWindow;

        public SolutionTile(string solutionName, MainWindow mainWindow)
        {
            this.solutionName = solutionName;
            this.baseDirectory = $"{Environment.CurrentDirectory}\\Files\\{solutionName}\\";
            this.mainWindow = mainWindow;
            InitializeComponent();
            txtSolutionName.Text = solutionName;
            CheckForIcon();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainWindowContent.Content = new Solution(solutionName);
        }

        private void CheckForIcon()
        {
            if (File.Exists($"{Environment.CurrentDirectory}\\Files\\{solutionName}\\icon.jpg"))
            {
                string imagePath = $"{Environment.CurrentDirectory}\\Files\\{solutionName}\\icon.jpg";
                BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath));
                TileIcon.Source = bitmapImage;
                TileLogo.Visibility = Visibility.Collapsed;
            }
            else if (File.Exists($"{Environment.CurrentDirectory}\\Files\\{solutionName}\\icon.png"))
            {
                string imagePath = $"{Environment.CurrentDirectory}\\Files\\{solutionName}\\icon.png";
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
