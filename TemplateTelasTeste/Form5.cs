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
    public partial class config2 : Form {
        string usuario;
        int id;
        public config2(string usuario) {
            this.usuario = usuario;
            id = DbClass.getId(usuario);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (!textBox1.Text.Equals("")) {
                if (DbClass.setSite(id, textBox1.Text)) {
                    listBox1.Items.Clear();
                    foreach (string item in DbClass.getSites(id)) {
                        listBox1.Items.Add(item);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            if (DbClass.deletSite(id, listBox1.Text)) {
                listBox1.Items.Clear();
                foreach (string item in DbClass.getSites(id)) {
                    listBox1.Items.Add(item);
                }
            }
        }

        private void config2_Load(object sender, EventArgs e) {
            string[] configs = DbClass.getConfig(usuario);
            SEGUNDA.Checked = configs[0] == bool.TrueString;
            TERCA.Checked = configs[1] == bool.TrueString;
            QUARTA.Checked = configs[2] == bool.TrueString;
            QUINTA.Checked = configs[3] == bool.TrueString;
            SEXTA.Checked = configs[4] == bool.TrueString;
            SABADO.Checked = configs[5] == bool.TrueString;
            DOMINGO.Checked = configs[6] == bool.TrueString;
            if(radioButton1.Text == configs[7]) {
                radioButton1.Checked = true;
            } else if(radioButton2.Text == configs[7]) {
                radioButton2.Checked = true;
            }else if(radioButton3.Text == configs[7]) {
                radioButton3.Checked = true;
            }
            foreach (string item in DbClass.getSites(DbClass.getId(usuario))) {
                listBox1.Items.Add(item);
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e) {
            string[] configs = new string[8];
            configs[0] = SEGUNDA.Checked.ToString();
            configs[1] = TERCA.Checked.ToString();
            configs[2] = QUARTA.Checked.ToString();
            configs[3] = QUINTA.Checked.ToString();
            configs[4] = SEXTA.Checked.ToString();
            configs[5] = SABADO.Checked.ToString();
            configs[6] = DOMINGO.Checked.ToString();
            if (radioButton1.Checked) {
                configs[7] = radioButton1.Text;
            }else if (radioButton2.Checked) {
                configs[7] = radioButton2.Text;
            }else if (radioButton3.Checked) {
                configs[7] = radioButton3.Text;
            }
            DbClass.setConfig(id, configs);
        }

        private void groupBox1_Enter(object sender, EventArgs e) {

        }

        private void button5_Click(object sender, EventArgs e) {
            if(textBox2.Text == textBox3.Text) {
                DbClass.updatePass(id, textBox3.Text);
            }
        }
    }
}
