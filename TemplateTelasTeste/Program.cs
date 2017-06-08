﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavKids {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormLogin login = new FormLogin();
            login.ShowDialog();
            if (login.logado) {
                Application.Run(new FormPrincipal(login.usuario,login.senha));
            }
        }
    }
}
