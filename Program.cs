using System;
using System.Windows.Forms;

namespace PlaylistParser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static ParserMainForm Parser;

        [STAThread] 
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Parser = new ParserMainForm();
            Application.Run(Parser);
        }
    }
}
