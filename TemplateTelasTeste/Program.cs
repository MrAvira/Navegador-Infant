using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTelasTeste {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form4 login = new Form4();
            login.ShowDialog();
            if (login.logado) {
                Application.Run(new principal(login.usuario,login.senha));
            }
        }
    }
}
