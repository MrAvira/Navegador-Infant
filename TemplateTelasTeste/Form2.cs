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
    public partial class navegador : Form {
        public navegador() {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e) {
            FormBorderStyle = FormBorderStyle.None;
        }

        private void button1_Click(object sender, EventArgs e) {
            if (comboBox1.Text.StartsWith("http://") || comboBox1.Text.StartsWith("https://") && !String.IsNullOrEmpty(comboBox1.Text))
                webBrowser1.Navigate(new Uri(comboBox1.Text));
            else if (!String.IsNullOrEmpty(comboBox1.Text))
                webBrowser1.Navigate(new Uri("http://" + comboBox1.Text));
            else
                MessageBox.Show("Insira um endereço valido \nEx: google.com ","erro");
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            
        }

        private void btnVoltarNav_Click(object sender, EventArgs e) {
            webBrowser1.GoBack();
        }

        private void btnHomeNav_Click(object sender, EventArgs e) {
            webBrowser1.Navigate(new Uri("http://google.com"));
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {

        }
    }
}
