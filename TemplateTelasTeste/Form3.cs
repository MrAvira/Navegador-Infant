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
    public partial class config1 : Form {
        public config1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e){
            DbClass.setUser(textBox1.Text, textBox2.Text);
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            foreach (string item in DbClass.getUsers()) {
                listBox1.Items.Add(item);
                listBox2.Items.Add(item);
            }
        }

        private void Form3_Load(object sender, EventArgs e) {
            
            FormBorderStyle = FormBorderStyle.None;
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            foreach (string item in DbClass.getUsers()) {
                listBox1.Items.Add(item);
                listBox2.Items.Add(item);

            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {
            DialogResult confirm = MessageBox.Show("Deseja continuar?", "Deseja excluir o Usuario?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (confirm.ToString().ToUpper() == "YES") {
                DbClass.deletUser(listBox1.Text);
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                foreach (string item in DbClass.getUsers()){
                    listBox1.Items.Add(item);
                    listBox2.Items.Add(item);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            if (!listBox2.Text.Equals("")) {
                config2 formc2 = new config2(listBox2.Text);
                formc2.ShowDialog();
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                foreach (string item in DbClass.getUsers()) {
                    listBox1.Items.Add(item);
                    listBox2.Items.Add(item);
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e){
            if (e.Control && e.KeyValue == 86){
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

        }

        private void cmbTema_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTema.SelectedIndex == 0)
            {
               
            }
        }
    }
}
