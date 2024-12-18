using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MetaPipingDocumentation
{
    public partial class App : Application
    {
        private TcpListener tcpListener;
        private MainWindow mainWindow;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            StartServer();

            string arg = "index.html";

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length == 2)
                arg = args[1];

            mainWindow = new MainWindow();
            mainWindow.ProcessMessage(arg);
            mainWindow.Show();
        }

        private void StartServer()
        {
            tcpListener = new TcpListener(IPAddress.Loopback, 12345);
            tcpListener.Start();

            Task.Run(async () =>
            {
                while (true)
                {
                    TcpClient client = await tcpListener.AcceptTcpClientAsync();
                    _ = HandleClient(client);
                }
            });
        }

        private async Task HandleClient(TcpClient client)
        {
            using (NetworkStream stream = client.GetStream())
            {
                byte[] buffer = new byte[1024];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                ProcessMessage(message);
            }

            client.Close();
        }

        private void ProcessMessage(string message)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (mainWindow != null)
                    mainWindow.ProcessMessage(message);
            });
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            if (tcpListener != null)
                tcpListener.Stop();
        }
    }
}
