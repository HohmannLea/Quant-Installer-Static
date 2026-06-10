using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
    /// Interaction logic for Solution.xaml
    /// </summary>
    public partial class Solution : Page
    {
        public string solutionName;
        public string baseDirectory;
        public Functions functions;

        public Solution(string solutionName)
        {
            this.solutionName = solutionName;
            this.baseDirectory = $"{Environment.CurrentDirectory}\\Files\\{solutionName}\\";
            this.functions = new Functions();
            InitializeComponent();
            txtSolutionName.Text = $"Install {solutionName}";
            LoadInstruments();
            LoadDescription();
        }

        private void LoadInstruments()
        {
            foreach (var directory in Directory.GetDirectories(baseDirectory))
            {
                string instrumentName = new DirectoryInfo(directory).Name;
                Instruments.Items.Add(instrumentName);
                bool breakpoint = true;
            }
        }

        private void LoadDescription()
        {
            if (File.Exists($"{baseDirectory}\\Description.txt"))
            {
                string[] description = File.ReadAllLines($"{baseDirectory}\\Description.txt");
                foreach (string line in description)
                {
                    txtDescription.Text += $"{line}\n\n";
                }
                
            }
        }

        private void btnInstall_Click(object sender, RoutedEventArgs e)
        {
            string instrumentName = Instruments.SelectedItem.ToString();

            if (Instruments.SelectedIndex > 0)
            {
                functions.InstallSolution(solutionName, instrumentName);
            }
            else
            {
                MessageBox.Show("You need to select an instrument first","Select Instrument",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
