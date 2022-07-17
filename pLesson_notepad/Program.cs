using pLesson_notepad_CL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pLesson_notepad
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 form = new Form1();
            MessageService service = new MessageService();
            FileManager manager = new FileManager();

            MainPresenter presenter = new MainPresenter(form, manager, service);

            Application.Run(form);
        }
    }
}
