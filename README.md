##Static Quant Installer
The static Quant Installer uses the original Installer logic, where all necessary method files are stored in the Installer itself. 

##Contents of the folder
QuantInstaller: Current version of the Static Quant Installer source code
OriginalQuantInstaller: Original version by Colin, which has the method tiles first and then the instrument selection. Note: Only Tiger instruments are possible
Example Build: Executable build of the current version with example PETRO files that can be downloaded and used for methods

##Folder naming
Instrument folders (first level in current installer, second level in original) that contain "Series 1" or "Series 2" use the SOCABIM/Spectra + file path for installation. 
In the current version, "Puma" and "Jaguar" in the instrument name also triggers the use of SOCABIM/Spectra + filepath.
"Series 3" in the instrument folder name triggers the use of the Spectra.Elements / BrukerAXS file path.
