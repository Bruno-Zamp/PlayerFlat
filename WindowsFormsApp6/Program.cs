using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public class MediaFile
    {
        public string FileName { get; set; }
        public string Path { get; set; }
    }
    class GlobalVariable
    {
        private static string resume = "Resume";
        public static string v_resume
        {
            get { return resume; }
            set { resume = value; }
        }

    }
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
}
