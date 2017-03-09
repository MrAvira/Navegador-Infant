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
    public partial class Template : Form {
        navegador nav = new navegador();
        Form3 form3 = new Form3();

        public Template() {
            InitializeComponent();
        }

        private void Template_Load(object sender, EventArgs e) {

        }

        private void btnOption1_Click(object sender, EventArgs e) {
            
            form3.Hide();
            nav.MdiParent = this;
            nav.Show();
            //nav.WindowState = FormWindowState.Maximized;
        }

        private void btnOption2_Click(object sender, EventArgs e) {

            nav.Hide();
            form3.MdiParent = this;
            form3.Show();
            form3.WindowState = FormWindowState.Maximized;




        }
    }
}
