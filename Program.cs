using System;
using System.Windows.Forms;

namespace Medical_App
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // Make sure this is your main form
        }
    }
}
