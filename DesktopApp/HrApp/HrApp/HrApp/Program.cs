﻿using System;
using System.IO;
using System.Windows.Forms;

namespace HrApp
{
    static class Program
    {
        public static string FilePath =
            Path.Combine(Environment.CurrentDirectory, "employee.txt");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
