using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Vodka_Crypt
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mVodka());
        }
    }
}
