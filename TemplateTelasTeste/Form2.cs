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
        string usuario;
        string senha;
        int id;
        public navegador(string usuario,string senha) {
            InitializeComponent();
            this.usuario = usuario;
            this.senha = senha;
            id = DbClass.getId(usuario);
        }

        private void Form2_Load(object sender, EventArgs e) {
            FormBorderStyle = FormBorderStyle.None;
            
            foreach (string item in DbClass.getSites(id))
            {
                comboBox1.Items.Add(item);
            }
            
        }

        private void button1_Click(object sender, EventArgs e) {
            //Uri uri = new Uri("http://myUrl/%2E%2E/%2E%2E");
            //Console.WriteLine(uri.AbsoluteUri);

            if (comboBox1.Text.StartsWith("http://") || comboBox1.Text.StartsWith("https://") && !String.IsNullOrEmpty(comboBox1.Text))
                webBrowser1.Navigate(new Uri(comboBox1.Text));
            else if (!String.IsNullOrEmpty(comboBox1.Text))
            {
                //comboBox1.Text = "http://" + comboBox1.Text;
                webBrowser1.Navigate(new Uri("http://" + comboBox1.Text));
            }
            else
                MessageBox.Show("Insira um endereço valido \nEx: google.com ", "erro");
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
            comboBox1.Text = webBrowser1.Url.ToString() ;
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string x;
            x = comboBox1.ToString();
            MessageBox.Show("OPS, Navegue apenas nos Sites Permitidos");
            webBrowser1.Navigate(new Uri(x));
        }
    }
}
