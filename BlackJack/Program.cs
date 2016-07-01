using System;
using System.Windows.Forms;

namespace BlackJack
{
    internal static class Program
    {
        public static GameWindow Window;

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Window = new GameWindow();
            Game.Run();


            Application.Run(Window);
        }
    }
}