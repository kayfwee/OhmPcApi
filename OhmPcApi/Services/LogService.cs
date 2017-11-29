using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmPcApi.Services
{
    /// <summary>
    /// Static class to allow anything to output to the log window.
    /// Should be initialised at the very beginning of the application.
    /// </summary>
    public static class LogService
    {
        private static MainWindow mainWindow;
        delegate void LogCallBack(string log);

        public static void Initialise(MainWindow window)
        {
            mainWindow = window;
        }

        public static void Log(string log)
        {
            if (mainWindow == null) return;

            if (mainWindow.rtbLog.InvokeRequired)
            {
                LogCallBack l = new LogCallBack(Log);
                mainWindow.Invoke(l, new object[] { log });
            }
            else
            {
                mainWindow.rtbLog.AppendText(DateTime.Now.ToLongTimeString() + ": " + log + "\n");
                mainWindow.rtbLog.SelectionStart = mainWindow.rtbLog.Text.Length;
                mainWindow.rtbLog.ScrollToCaret();
            }
        }

        public static void Log(Exception ex)
        {
            Log(ex.Message);
            Log(ex.StackTrace);
        }
    }
}
