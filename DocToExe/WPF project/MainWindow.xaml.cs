using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace MetaPipingDocumentation
{
    public partial class MainWindow : Window
    {
        private string executablePath;
        private string dataPath;
        private string indexPath;
        public string pageName;

        public MainWindow()
        {
            InitializeComponent();

            executablePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            dataPath = Path.Combine(executablePath, "Data");
            dataPath = Path.Combine(dataPath, "documentation.metapiping.com");
            
            indexPath = Path.Combine(dataPath, "index.html");
            InitializeWebView2();
        }

        private async void InitializeWebView2()
        {
            await WebBrowserControl.EnsureCoreWebView2Async(null);
            
            string localSitePath = "file:///" + indexPath;
            //WebBrowserControl.CoreWebView2.Navigate(localSitePath);
            WebBrowserControl.Source = new Uri(localSitePath);
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            TerminateWebView2Processes();

            DirectoryInfo rootDir = new DirectoryInfo(executablePath);

            // Remove all directories ending by ".webview2"
            var webView2Directories = rootDir.EnumerateDirectories("*", SearchOption.AllDirectories)
                                             .Where(dir => dir.Name.EndsWith(".webview2", StringComparison.OrdinalIgnoreCase));

            foreach (var tempDir in webView2Directories)
            {
                try
                {
                    Directory.Delete(tempDir.FullName, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            // Remove EBWebView if exists
            string TempWebDir = Path.Combine(dataPath, "EBWebView");
            if (Directory.Exists(TempWebDir))
            {
                try
                {
                    Directory.Delete(TempWebDir, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void TerminateWebView2Processes()
        {
            // Terminate all WebView2 processes to release file locks
            var processes = Process.GetProcessesByName("msedgewebview2");
            foreach (var process in processes)
            {
                try
                {
                    process.Kill();
                    process.WaitForExit();
                }
                catch (Exception ex)
                {

                }
            }
        }

        public void ProcessMessage(string message)
        {
            indexPath = Path.Combine(dataPath, message);
            if (File.Exists(indexPath))
            {
                string localSitePath = "file:///" + indexPath;
                //WebBrowserControl.CoreWebView2.Navigate(localSitePath);
                WebBrowserControl.Source = new Uri(localSitePath);
            }
            else
                MessageBox.Show(indexPath + " not found");
        }
    }
}
