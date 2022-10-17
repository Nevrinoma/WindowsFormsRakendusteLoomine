using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsRakendusteLoomine
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ImageForm());
            //Application.Run(new Matem());
            //Application.Run(new matchingGame());
            Application.Run(new AvaForm()); //käivitab põhivormi
        }
    }
}
