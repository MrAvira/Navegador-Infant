using System;
using System.Windows.Forms;

namespace NavKids {
    public partial class FormJogo : Form {
        int pontos = 0;
        bool aux = true;
        int temp = 90;
        int id;
        string nivel;
        string[] quiz = new string[] { };

        public FormJogo(int id, string nivel) {
            InitializeComponent();
            this.id = id;
            this.nivel = nivel;
            btnVerificar.Enabled = false;
        }

        private void btnSair_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnIniciar_Click(object sender, EventArgs e) {
            temp = 90;
            btnVerificar.Enabled = true;
            aux = true;
            quiz = DbClass.getQuiz(nivel);
            rtbPergunta.Text = quiz[0];
            Random rand = new Random();
            int num = rand.Next(1, 3);
            if (num == 1) {
                rbResp1.Text = quiz[1];
                num = rand.Next(1, 3);
                if (num == 1) {
                    rbResp2.Text = quiz[2];
                    rbResp3.Text = quiz[3];
                }
                else {
                    rbResp2.Text = quiz[3];
                    rbResp3.Text = quiz[2];
                }
                
            }
            else if (num == 2) {
                rbResp1.Text = quiz[2];
                num = rand.Next(1, 3);
                if (num == 1) {
                    rbResp2.Text = quiz[1];
                    rbResp3.Text = quiz[3];
                }
                else {
                    rbResp2.Text = quiz[3];
                    rbResp3.Text = quiz[1];
                }
            }
            else {
                rbResp1.Text = quiz[3];
                num = rand.Next(1, 3);
                if (num == 1) {
                    rbResp2.Text = quiz[2];
                    rbResp3.Text = quiz[1];
                }
                else {
                    rbResp2.Text = quiz[1];
                    rbResp3.Text = quiz[2];
                }
            }
            btnIniciar.Enabled = false;
            timer1.Enabled = true;
        }

        private void btnVerificar_Click(object sender, EventArgs e) {
            if (rbResp1.Checked && rbResp1.Text == quiz[3]) {
                MessageBox.Show("Resposta certa!!");
                btnIniciar.Text = "Proxima";
                btnIniciar.Enabled = true;
                if (aux) {
                    pontos += temp + 10;
                    lbponto.Text = pontos + " pontos";
                    aux = false;
                }
                timer1.Stop();
            }
            else if (rbResp2.Checked && rbResp2.Text == quiz[3]) {
                MessageBox.Show("Resposta certa!!");
                btnIniciar.Text = "Proxima";
                btnIniciar.Enabled = true;
                if (aux) {
                    pontos += temp + 10;
                    lbponto.Text = pontos + " pontos";
                    aux = false;
                }
                timer1.Stop();
            }
            else if (rbResp3.Checked && rbResp3.Text == quiz[3]) {
                MessageBox.Show("Resposta certa!!");
                btnIniciar.Text = "Proxima";
                btnIniciar.Enabled = true;
                if (aux) {
                    pontos += temp + 10;
                    lbponto.Text = pontos + " pontos";
                    aux = false;
                }
                timer1.Stop();
            }
            else {
                MessageBox.Show("Resposta Errada!!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            temp--;
            lbMinseg.Text = "" + temp / 60 + " Min e " + temp % 60 + " Segs";
            if (temp == 0) {
                MessageBox.Show("Seu tempo para responder acabou!!");
                btnVerificar.Enabled = false;
                btnIniciar.Text = "Proxima";
                btnIniciar.Enabled = true;
                timer1.Enabled = false;
            }
        }
    }
}
