using System;
using System.Drawing;
using System.Windows.Forms;

namespace NavKids {
    public partial class FormPrincipal : Form {
        string usuario;
        string senha;
        int id;
        string[] configs;
        FormNavegador nav;
        FormConfigs config = new FormConfigs();
        int x;

        public FormPrincipal(string usuario, string senha) {
            InitializeComponent();
            this.usuario = usuario;
            this.senha = senha;
            id = DbClass.getId(usuario);
            nav = new FormNavegador(usuario, senha);
            configs = DbClass.getConfig(id);
            x = int.Parse(configs[9]);
            timer1.Start();
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
            btnOption2.Enabled = DbClass.getNivelU(id);
        }

        private void btnOption1_Click(object sender, EventArgs e) {
            nav.atualizaBox();
            nav.Activate();
            nav.Show();
        }

        private void btnOption2_Click(object sender, EventArgs e) {
            config.Activate();
            config.Show();
        }

        private void btnMenu_Click(object sender, EventArgs e) {
            if (panel1.Size.Equals(new Size(210, panel1.Height))) {
                panel1.Size = new Size(39, panel1.Height);
            }
            else
                panel1.Size = new Size(210, panel1.Height);
        }

        private void btnLogout_Click(object sender, EventArgs e) {
            Application.Restart();
        }
     
        private void timer1_Tick(object sender, EventArgs e){
           
            x = x + 600; 
            // X equivale 10m a cada 10s
            DbClass.setTempUsed(id, x);
            /*
             * pega somente a parte numerica da string. EX 30 M = 30.
             * verifica se a parte numerica é menor que 30 (Se for menor só pode ser 1 HR, 2 HR ... 6 HR,
             * se for maior só pode ser 30 M).
             * 30m == 1800s >> 30m * 60s == 1800s  || 1hr == 3600s >> 1h * 60m * 60s == 3800.
             * verifica se o contador x é maior ou igual aos segundos estipulados, se for, Sai.
             */

            if (DbClass.getOnlyNum(configs[8].ToString()) < 30 && DbClass.getOnlyNum(configs[8].ToString()) != 0) {
                configs = DbClass.getConfig(id);
                if (x >= DbClass.getOnlyNum(configs[8].ToString()) * 60 * 60) {
                    this.Close();
                }
            }
            else if(DbClass.getOnlyNum(configs[8].ToString()) != 0) {
                configs = DbClass.getConfig(id);
                if (x >= DbClass.getOnlyNum(configs[8].ToString()) * 60) {
                    //MessageBox.Show("Seu tempo de Navegação acabou, até logo!");
                    this.Close();
                }
            }
        }

        private void btnOption3_Click(object sender, EventArgs e) {
            timer1.Stop();
            FormJogo jogo = new FormJogo(id,configs[7]);
            jogo.ShowDialog();
            timer1.Start();
        }
    }
}
