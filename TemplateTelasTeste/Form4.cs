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
        public bool logado = false;
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
                DbClass.getday(usuario);
                string[] configs = DbClass.getConfig(usuario);
                // verifica o dia da ultima vez logado com o dia atual.
                if (DbClass.getday(DbClass.getId(usuario)).Substring(0, 10) == DbClass.GetNetworkTime().ToString("dd/MM/yyyy")) {
                    MessageBox.Show("Dia Igual");

                    // se o dia da ultima vez logado for igual, verifica-se o tempo de utilização.
                    if (DbClass.getOnlyNum(configs[8].ToString()) < 30) {
                        // se o tempo maximo foi atingido, então mostra mensagem de tempo max atingido >>
                        if (int.Parse(configs[9]) >= (DbClass.getOnlyNum(configs[8]) * 60 * 60)) {
                            MessageBox.Show("Max Hora");
                            lblLoginError.Text = "Tempo maximo de login diario atingido!!";
                            lblLoginError.Visible = true;
                        }
                        // se o tempo maximo não foi atingido, então entra >>
                        else {
                            logado = true;
                            this.Close();
                        }
                    }
                    else {
                        // se o tempo maximo foi atingido, então mostra mensagem de tempo max atingido >>
                        if (int.Parse(configs[9]) >= (DbClass.getOnlyNum(configs[8]) * 60)) {
                            MessageBox.Show("Max Min");
                            lblLoginError.Text = "Tempo maximo de login diario atingido!!";
                            lblLoginError.Visible = true;
                        }
                        // se o tempo maximo não foi atingido, então entra >>
                        else {
                            logado = true;
                            this.Close();
                        }
                    }
                }
                // se o dia do ultimo login for diferente, seta o dia como dia atual e zera o tempo usado do banco
                else {
                    MessageBox.Show("diferente");
                    DbClass.setDia(DbClass.getId(usuario));
                    DbClass.setTempUsed(DbClass.getId(usuario));
                    logado = true;
                    this.Close();
                }

                //logado = false;
                //this.Close();
            }
            else {
                lblLoginError.Text = "Senha ou login incorretos!";
                lblLoginError.Visible = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e) {
            Application.Exit();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e){
            if ( (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar)) ){
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
