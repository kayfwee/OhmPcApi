using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using OhmPcApi.Services;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using OhmPcApi.Common;

namespace OhmPcApi
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var window = new MainWindow();
            LogService.Initialise(window);
            ConfigService.InitialiseConfig();

            var port = string.IsNullOrEmpty(ConfigService.Config.Port) ? Globals.DEFAULT_PORT : ConfigService.Config.Port;
            var autoDetectedLocalIp = GetLocalIPAddress();
            var manualIp = ConfigService.Config.ManualIpOverride;

            StartOptions options = new StartOptions();
            options.Urls.Add("http://localhost:" + port + "/");
            options.Urls.Add("http://" + autoDetectedLocalIp + ":" + port + "/");
            if (!string.IsNullOrEmpty(manualIp))
            {
                options.Urls.Add("http://" + manualIp + ":" + port + "/");
            }

            try
            {
                // Start OWIN host 
                using (WebApp.Start<Startup>(options))
                {
                    LogService.Log("Web API started.");
                    window.lblServerStatus.Text = "Running";
                    window.lblServerStatus.ForeColor = Color.DarkGreen;
                    window.lblServerPort.Text = port;
                    window.lblServerIp.Text = autoDetectedLocalIp;

                    Application.Run(window);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to start the API server:\n" + ex.Message + "\n" + ex.StackTrace, "OHM Mini Server");
            }
        }

        public static string GetLocalIPAddress()
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                var addr = ni.GetIPProperties().GatewayAddresses.FirstOrDefault();
                if (addr != null && !addr.Address.ToString().Equals("0.0.0.0"))
                {
                    if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                    {
                        foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                return ip.Address.ToString();
                            }
                        }
                    }
                }
            }
            throw new Exception("Failed to obtain a valid local network address.");
        }
    }
}
