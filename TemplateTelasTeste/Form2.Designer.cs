namespace TemplateTelasTeste {
    partial class navegador {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(navegador));
            this.btnIrNav = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnVoltarNav = new System.Windows.Forms.Button();
            this.btnHomeNav = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIrNav
            // 
            this.btnIrNav.AccessibleDescription = "Ir";
            this.btnIrNav.AccessibleName = "Ir";
            this.btnIrNav.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.btnIrNav.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnIrNav.BackgroundImage")));
            this.btnIrNav.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIrNav.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnIrNav.FlatAppearance.BorderSize = 0;
            this.btnIrNav.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(104)))));
            this.btnIrNav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIrNav.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIrNav.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnIrNav.Location = new System.Drawing.Point(771, 0);
            this.btnIrNav.Name = "btnIrNav";
            this.btnIrNav.Size = new System.Drawing.Size(39, 39);
            this.btnIrNav.TabIndex = 3;
            this.btnIrNav.UseVisualStyleBackColor = true;
            this.btnIrNav.Click += new System.EventHandler(this.button1_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(0, 45);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(849, 420);
            this.webBrowser1.TabIndex = 5;
            this.webBrowser1.Url = new System.Uri("http://www.google.com", System.UriKind.Absolute);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(16)))), ((int)(((byte)(50)))));
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.btnIrNav);
            this.panel2.Controls.Add(this.btnVoltarNav);
            this.panel2.Controls.Add(this.btnHomeNav);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(849, 39);
            this.panel2.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "www.google.com",
            "www.fatecpg.com.br",
            "www.youtube.com"});
            this.comboBox1.Location = new System.Drawing.Point(45, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(720, 24);
            this.comboBox1.TabIndex = 7;
            // 
            // btnVoltarNav
            // 
            this.btnVoltarNav.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.btnVoltarNav.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVoltarNav.BackgroundImage")));
            this.btnVoltarNav.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVoltarNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnVoltarNav.FlatAppearance.BorderSize = 0;
            this.btnVoltarNav.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(104)))));
            this.btnVoltarNav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltarNav.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltarNav.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnVoltarNav.Location = new System.Drawing.Point(0, 0);
            this.btnVoltarNav.Name = "btnVoltarNav";
            this.btnVoltarNav.Size = new System.Drawing.Size(39, 39);
            this.btnVoltarNav.TabIndex = 2;
            this.btnVoltarNav.UseVisualStyleBackColor = true;
            this.btnVoltarNav.Click += new System.EventHandler(this.btnVoltarNav_Click);
            // 
            // btnHomeNav
            // 
            this.btnHomeNav.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.btnHomeNav.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHomeNav.BackgroundImage")));
            this.btnHomeNav.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHomeNav.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnHomeNav.FlatAppearance.BorderSize = 0;
            this.btnHomeNav.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(104)))));
            this.btnHomeNav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHomeNav.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomeNav.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnHomeNav.Location = new System.Drawing.Point(810, 0);
            this.btnHomeNav.Name = "btnHomeNav";
            this.btnHomeNav.Size = new System.Drawing.Size(39, 39);
            this.btnHomeNav.TabIndex = 6;
            this.btnHomeNav.UseVisualStyleBackColor = true;
            this.btnHomeNav.Click += new System.EventHandler(this.btnHomeNav_Click);
            // 
            // navegador
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(16)))), ((int)(((byte)(50)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(849, 465);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(452, 405);
            this.Name = "navegador";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIrNav;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnVoltarNav;
        private System.Windows.Forms.Button btnHomeNav;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}