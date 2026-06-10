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
            LoadSolutions();            
        }

        private void LoadSolutions()
        {
            foreach (var directory in Directory.GetDirectories(baseDirectory))
            {
                string solutionName = new DirectoryInfo(directory).Name;
                SolutionTile solutionControl = new SolutionTile(solutionName, mainWindow);
                Solutions.Children.Add(solutionControl);

                bool breakpoint = true;
            }
        }
    }
}
