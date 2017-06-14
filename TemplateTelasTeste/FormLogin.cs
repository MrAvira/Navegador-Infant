using System;
using System.Windows.Forms;

namespace NavKids {
    public partial class FormLogin : Form {
        public string usuario;
        public string senha;
        public bool logado = false;

        public FormLogin() {
            InitializeComponent();
            
        }

        private void Form4_Load(object sender, EventArgs e) {
            AcceptButton = button1;
            CancelButton = button2;
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
           usuario = textBox1.Text;
            senha = textBox2.Text;
            if (DbClass.VerifyUser(usuario, senha)) {
                DbClass.getday(usuario);
                int id = DbClass.getId(usuario);
                string[] configs = DbClass.getConfig(id);
                // verifica o dia da ultima vez logado com o dia atual.
                if (DbClass.getday(id).Substring(0, 10) == DbClass.GetNetworkTime().ToString("dd/MM/yyyy")) {
                    // se o dia da ultima vez logado for igual, verifica-se o tempo de utilização.
                    if (DbClass.getOnlyNum(configs[8].ToString()) < 30) {
                        // se o tempo maximo foi atingido, então mostra mensagem de tempo max atingido >>
                        if (int.Parse(configs[9]) >= (DbClass.getOnlyNum(configs[8]) * 60 * 60) &&
                            int.Parse(configs[8]) != 0) {
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
                        if (int.Parse(configs[9]) >= (DbClass.getOnlyNum(configs[8]) * 60) &&
                            DbClass.getOnlyNum(configs[8]) != 0) {
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
                    DbClass.setDia(id);
                    DbClass.setTempUsed(id);
                    logado = true;
                    this.Close();
                }
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
