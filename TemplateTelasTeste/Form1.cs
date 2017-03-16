using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTelasTeste {
    public partial class principal : Form {
        navegador nav = new navegador();
        config config = new config();

        public principal() {
            InitializeComponent();
        }

        private void Template_Load(object sender, EventArgs e) {
            // Determina que o form nav e config pertencem ao mdi
            nav.MdiParent = this;
            config.MdiParent = this;
            // Ativa os forms nav e config
            nav.Activate();
            config.Activate();
            // "mostra" os forms
            nav.Show();
            config.Show();
            // ativa e mostra novamente o form nav para evitar o bug
            nav.Activate();
            nav.Show();
        }

        private void btnOption1_Click(object sender, EventArgs e) {
            
            nav.Activate();
            nav.Show();
            
            //nav.MdiParent = this;
            /*
            config.Hide();
            nav.MdiParent = this;
            nav.FormBorderStyle = FormBorderStyle.None;
            nav.Show();
            nav.WindowState = FormWindowState.Maximized;
            */
        }

        private void btnOption2_Click(object sender, EventArgs e) {
            
            config.Activate();
            config.Show();

            //config.MdiParent = this;
            /*
            nav.Hide();
            config.MdiParent = this;
            config.Show();
            config.FormBorderStyle = FormBorderStyle.None;
            config.WindowState = FormWindowState.Maximized;
            */


        }
    }
}
