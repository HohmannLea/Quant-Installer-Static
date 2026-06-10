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
        public string instrumentName;
        public string baseDirectory;

        public Solution(string instrumentName)
        {
            this.instrumentName = instrumentName;
            this.baseDirectory = $"{Environment.CurrentDirectory}\\Files\\{instrumentName}\\";
            InitializeComponent();
            txtSolutionName.Text = $"Install Method for {instrumentName}";
            LoadMethods();
            LoadDescription();
        }

        private void LoadMethods()
        {
            foreach (var directory in Directory.GetDirectories(baseDirectory))
            {
                string methodName = new DirectoryInfo(directory).Name;
                SolutionTile methodControl = new SolutionTile(instrumentName, methodName);
                Methods.Children.Add(methodControl);
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

    }
}
