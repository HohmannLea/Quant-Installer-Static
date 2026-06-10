using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Functions functions = new Functions();

        public MainWindow()
        {
            InitializeComponent();

            AppConfig.ReadAppConfig();

            DirectoryInfo BaseDir = new DirectoryInfo(Environment.CurrentDirectory + "\\Files");
            DirectoryInfo[] InstrumentFolder = BaseDir.GetDirectories();

            MainWindowContent.Content = new Install(this);


            //Set Logo
            if (AppConfig.ConfigSettings["logoPath"] != "")
            {
                string imagePath = $"{Environment.CurrentDirectory}\\{AppConfig.ConfigSettings["logoPath"]}";
                if (true)
                {
                    if (File.Exists(imagePath) && IsBitmap(imagePath))
                    {
                        BrukerLogo.Visibility = Visibility.Collapsed;
                        CustomLogo.Visibility = Visibility.Visible;

                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri($"{Environment.CurrentDirectory}\\{AppConfig.ConfigSettings["logoPath"]}", UriKind.RelativeOrAbsolute);
                        bitmap.EndInit();

                        CustomLogo.Source = bitmap;
                    }
                    else
                    {
                        BrukerLogo.Visibility = Visibility.Visible;
                        CustomLogo.Visibility = Visibility.Collapsed;
                    }
                }
            }
            else
            {
                BrukerLogo.Visibility = Visibility.Visible;
                CustomLogo.Visibility = Visibility.Collapsed;
            }


            

            //Set Title Text
            if (AppConfig.ConfigSettings["titleText"] == "")
            {
                TitleText.Content = "Solution Installer";
            }
            else
            {
                TitleText.Content = AppConfig.ConfigSettings["titleText"];
            }

        }

        private void MakeWindowMoveable(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CloseApplication(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnNavInstall_Checked(object sender, RoutedEventArgs e)
        {
            MainWindowContent.Content = new Install(this);
        }

        private void btnNavWebsite_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = "https://www.bruker.com/en/products-and-solutions/elemental-analyzers/xrf-spectrometers/xrf-solutions.html";

                Process.Start(new ProcessStartInfo(url)
                {
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Bruker Website: {ex.Message}");
            }
        }

        private bool IsBitmap(string filePath)
        {
            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    // Attempt to decode the image
                    var decoder = BitmapDecoder.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.None);
                    return decoder.Frames[0] != null;
                }
            }
            catch
            {
                return false;
            }
        }

        private void btnNavWebsite_Checked_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
