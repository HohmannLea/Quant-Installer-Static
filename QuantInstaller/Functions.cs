using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BrukerAXS.QuantInstaller
{
    public class Functions
    {
        public void InstallSolution(string instrument, string method)
        {
            //MessageBox.Show($"Method Name: {method}, Instrument Name: {instrument}");

            string sourceFolder = $"{Environment.CurrentDirectory}\\Files\\{instrument}\\{method}";
            string targetFolder;
            string logFileFolder;
            string logFileEntry;

            string sourceManualsFolder = $"{Environment.CurrentDirectory}\\Manuals\\{instrument}";
            string targetManualsFolder = "c:\\ProgramData\\Bruker AXS Solution Manuals";
            string sourceHtmlFolder = $"{Environment.CurrentDirectory}\\HTML Manuals\\{instrument}";
            string targetHTMLfolder = "c:\\ProgramData\\Bruker AXS Manuals";

            //Determine the path to install the solution files.
            if (instrument.Contains("Series 1") || instrument.Contains("series 1") || instrument.Contains("Series 2") || instrument.Contains("series 2"))
            {
                targetFolder = Registry.GetValue("HKEY_CURRENT_USER\\Software\\SOCABIM\\Spectra Plus", "Spectra Plus Path", null).ToString();
                logFileFolder = Registry.GetValue("HKEY_CURRENT_USER\\Software\\SOCABIM\\Spectra Plus", "Spectra Plus Path", null).ToString();

                if (targetFolder == null)
                {
                    MessageBox.Show("The registry key for SPECTRA PLUS PATH does not exist. Please check your Spectra Plus installation. Please restart this installer when the problem is fixed.", "Registry Key Error");
                    return;
                }
            }
            else
            {
                targetFolder = "C:\\ProgramData\\Bruker AXS";
                logFileFolder = "C:\\ProgramData\\Bruker AXS";
            }

            if (Directory.Exists(targetFolder))
            {
                logFileEntry = $"-------------------------------------------------------------------\n";
                logFileEntry += $"{DateTime.Now}\n";
                logFileEntry += $"{method} for {instrument} installed \n";
                logFileEntry += $"-------------------------------------------------------------------\n";

                DirectoryCopy(sourceFolder, targetFolder, true);

                if (Directory.Exists(sourceManualsFolder))
                {
                    DirectoryCopy(sourceManualsFolder, targetManualsFolder + "\\", false);
                }

                if (Directory.Exists(sourceHtmlFolder))
                {
                    DirectoryCopy(sourceHtmlFolder, targetHTMLfolder + "\\", false);
                }

                writeLogFile(logFileFolder, logFileEntry);

                MessageBox.Show($"{method} for {instrument} has been installed.", "Finished", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"The target folder {targetFolder} does not exist on this computer. Please check your software installation and then restart this installer.","Cannot find target folder",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
        }

        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo sourceDir = new DirectoryInfo(sourceDirName);
            DirectoryInfo targetDir = new DirectoryInfo(destDirName);

            if (!sourceDir.Exists)
            {
                throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirName);
            }

            DirectoryInfo[] dirs = sourceDir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = sourceDir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, true);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        private void writeLogFile(string logFileDir, string logFileText)
        {
            string logFilePath = logFileDir + "QUANTs Installed.txt";

            try
            {
                File.AppendAllText(logFilePath, logFileText);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot write log file.\n{ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
