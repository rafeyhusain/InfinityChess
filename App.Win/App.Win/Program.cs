using System; using App.Model;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace InfinityChess
{
    static class Program
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
             * 
             * W A R N I N G !!
             * 
             * 1) DO NOT COMMENT try-catch
             * 
             * 2) Do not write any code in Main(). Use Ap.Init() to write start up code
             * 
             * 
            */
            try
            {
                RunApp();
            }
            catch (Exception ex)
            {
                TestDebugger.Instance.WriteError(ex);
                MessageForm.Show(ex);
            }
        }

        private static void RunApp()
        {
            bool createdNew = true;

            using (Mutex mutex = new Mutex(true, "InfiChess", out createdNew))
            {
                Ap.Init(ApModuleE.Both);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Winforms.Startup());

                Ap.UnInit(ApModuleE.Both);
            }


        }
    }
}