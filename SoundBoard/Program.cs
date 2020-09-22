using System;
using System.Windows.Forms;
using SoundBoard.Persistence;
using SoundBoard.Helpers;
using System.Threading;

namespace SoundBoard
{
    static class Program
    {
        static Mutex mut = null;
        
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.ApplicationExit += new EventHandler(Application_ExitHandler);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                if (!AppDataManager.loadCfgFile())
                {
                    MessageBox.Show(ErrorHelper.ConfigFileCorrupted, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.NewLog(ex, "Major config file problem at start.");
                MessageBox.Show(String.Format(ErrorHelper.ConfigFileFailure, Logger.LogsFolderPath), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            if (IsFirstInstance())
            {
                Application.Run(new mainForm(true));
            }
            else
            {
                Application.Run(new mainForm(false));
            }
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            QuickFailure(e.Exception);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            QuickFailure((Exception)e.ExceptionObject);
        }

        static void QuickFailure(Exception e)
        {
            Logger.NewLog(e, "Unhandled exception and exited application.");
            MessageBox.Show(String.Format(ErrorHelper.UnhandledProgramFailure, Logger.LogsFolderPath, e.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }

        static void Application_ExitHandler(object sender, EventArgs e)
        {
            if (mut != null)
            {
                mut.Close();
                mut = null;
            }
        }

        static bool IsFirstInstance()
        {
            bool result = false;
            try
            {
                Mutex.OpenExisting("SoundBoard @ Doot Doot.bone");
            }
            catch
            {
                mut = new Mutex(true, "SoundBoard @ Doot Doot.bone");
                result = true;
            }
            return result;
        }
    }
}
