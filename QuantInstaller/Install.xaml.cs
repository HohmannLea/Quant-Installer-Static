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
    /// Interaction logic for Install.xaml
    /// </summary>
    public partial class Install : Page
    {
        public string baseDirectory = $"{Environment.CurrentDirectory}\\Files";
        public MainWindow mainWindow;

        public Install(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
            LoadInstruments();
        }

        private void LoadInstruments()
        {
            foreach (var directory in Directory.GetDirectories(baseDirectory))
            {
                string instrumentName = new DirectoryInfo(directory).Name;
                Instruments.Items.Add(instrumentName);
            }
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            if (Instruments.SelectedIndex > 0)
            {
                string instrumentName = Instruments.SelectedItem.ToString();
                mainWindow.MainWindowContent.Content = new Solution(instrumentName);
            }
            else
            {
                MessageBox.Show("You need to select an instrument first", "Select Instrument", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
