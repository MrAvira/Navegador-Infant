using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTelasTeste {
    public partial class Form4 : Form {
        public string usuario;
        public string senha;
        public bool logado;
        public Form4() {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void Form4_Load(object sender, EventArgs e) {
            AcceptButton = button1;
            CancelButton = button2;
        }

        private void button1_Click(object sender, EventArgs e) {
            usuario = textBox1.Text;
            senha = textBox2.Text;
            if (DbClass.VerifyUser(usuario, senha)) { 
                logado = true;
                this.Close();
            }
            else {
                logado = false;
                lblLoginError.Visible = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
