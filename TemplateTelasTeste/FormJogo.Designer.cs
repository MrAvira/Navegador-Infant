namespace NavKids {
    partial class FormJogo {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJogo));
            this.btnSair = new System.Windows.Forms.Button();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.rtbPergunta = new System.Windows.Forms.RichTextBox();
            this.rbResp1 = new System.Windows.Forms.RadioButton();
            this.rbResp2 = new System.Windows.Forms.RadioButton();
            this.rbResp3 = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbTempoRest = new System.Windows.Forms.Label();
            this.lbMinseg = new System.Windows.Forms.Label();
            this.lbPontuacao = new System.Windows.Forms.Label();
            this.lbponto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.LightCoral;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSair.Location = new System.Drawing.Point(508, 396);
            this.btnSair.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(137, 46);
            this.btnSair.TabIndex = 0;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnVerificar
            // 
            this.btnVerificar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnVerificar.FlatAppearance.BorderSize = 0;
            this.btnVerificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerificar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnVerificar.Location = new System.Drawing.Point(252, 300);
            this.btnVerificar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(152, 46);
            this.btnVerificar.TabIndex = 1;
            this.btnVerificar.Text = "Confirmar";
            this.btnVerificar.UseVisualStyleBackColor = false;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnIniciar.FlatAppearance.BorderSize = 0;
            this.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnIniciar.Location = new System.Drawing.Point(365, 396);
            this.btnIniciar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(137, 46);
            this.btnIniciar.TabIndex = 2;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // rtbPergunta
            // 
            this.rtbPergunta.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.rtbPergunta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbPergunta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rtbPergunta.Location = new System.Drawing.Point(12, 12);
            this.rtbPergunta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbPergunta.Name = "rtbPergunta";
            this.rtbPergunta.Size = new System.Drawing.Size(616, 176);
            this.rtbPergunta.TabIndex = 3;
            this.rtbPergunta.Text = "";
            // 
            // rbResp1
            // 
            this.rbResp1.AutoSize = true;
            this.rbResp1.BackColor = System.Drawing.Color.Transparent;
            this.rbResp1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbResp1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rbResp1.Location = new System.Drawing.Point(15, 238);
            this.rbResp1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbResp1.Name = "rbResp1";
            this.rbResp1.Size = new System.Drawing.Size(118, 32);
            this.rbResp1.TabIndex = 4;
            this.rbResp1.TabStop = true;
            this.rbResp1.Text = "Resposta";
            this.rbResp1.UseVisualStyleBackColor = false;
            // 
            // rbResp2
            // 
            this.rbResp2.AutoSize = true;
            this.rbResp2.BackColor = System.Drawing.Color.Transparent;
            this.rbResp2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbResp2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rbResp2.Location = new System.Drawing.Point(252, 238);
            this.rbResp2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbResp2.Name = "rbResp2";
            this.rbResp2.Size = new System.Drawing.Size(118, 32);
            this.rbResp2.TabIndex = 5;
            this.rbResp2.TabStop = true;
            this.rbResp2.Text = "Resposta";
            this.rbResp2.UseVisualStyleBackColor = false;
            this.rbResp2.CheckedChanged += new System.EventHandler(this.rbResp2_CheckedChanged);
            // 
            // rbResp3
            // 
            this.rbResp3.AutoSize = true;
            this.rbResp3.BackColor = System.Drawing.Color.Transparent;
            this.rbResp3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbResp3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rbResp3.Location = new System.Drawing.Point(487, 238);
            this.rbResp3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbResp3.Name = "rbResp3";
            this.rbResp3.Size = new System.Drawing.Size(118, 32);
            this.rbResp3.TabIndex = 6;
            this.rbResp3.TabStop = true;
            this.rbResp3.Text = "Resposta";
            this.rbResp3.UseVisualStyleBackColor = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbTempoRest
            // 
            this.lbTempoRest.AutoSize = true;
            this.lbTempoRest.BackColor = System.Drawing.Color.Transparent;
            this.lbTempoRest.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTempoRest.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbTempoRest.Location = new System.Drawing.Point(7, 372);
            this.lbTempoRest.Name = "lbTempoRest";
            this.lbTempoRest.Size = new System.Drawing.Size(164, 28);
            this.lbTempoRest.TabIndex = 7;
            this.lbTempoRest.Text = "Tempo restante:";
            // 
            // lbMinseg
            // 
            this.lbMinseg.AutoSize = true;
            this.lbMinseg.BackColor = System.Drawing.Color.Transparent;
            this.lbMinseg.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMinseg.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbMinseg.Location = new System.Drawing.Point(32, 415);
            this.lbMinseg.Name = "lbMinseg";
            this.lbMinseg.Size = new System.Drawing.Size(122, 28);
            this.lbMinseg.TabIndex = 8;
            this.lbMinseg.Text = "0 min 0 seg";
            // 
            // lbPontuacao
            // 
            this.lbPontuacao.AutoSize = true;
            this.lbPontuacao.BackColor = System.Drawing.Color.Transparent;
            this.lbPontuacao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPontuacao.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbPontuacao.Location = new System.Drawing.Point(205, 372);
            this.lbPontuacao.Name = "lbPontuacao";
            this.lbPontuacao.Size = new System.Drawing.Size(116, 28);
            this.lbPontuacao.TabIndex = 9;
            this.lbPontuacao.Text = "Pontuação:";
            // 
            // lbponto
            // 
            this.lbponto.AutoSize = true;
            this.lbponto.BackColor = System.Drawing.Color.Transparent;
            this.lbponto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbponto.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbponto.Location = new System.Drawing.Point(217, 415);
            this.lbponto.Name = "lbponto";
            this.lbponto.Size = new System.Drawing.Size(95, 28);
            this.lbponto.TabIndex = 10;
            this.lbponto.Text = "0 pontos";
            // 
            // FormJogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(660, 455);
            this.Controls.Add(this.lbponto);
            this.Controls.Add(this.lbPontuacao);
            this.Controls.Add(this.lbMinseg);
            this.Controls.Add(this.lbTempoRest);
            this.Controls.Add(this.rbResp3);
            this.Controls.Add(this.rbResp2);
            this.Controls.Add(this.rbResp1);
            this.Controls.Add(this.rtbPergunta);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.btnVerificar);
            this.Controls.Add(this.btnSair);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormJogo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jogo ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.RichTextBox rtbPergunta;
        private System.Windows.Forms.RadioButton rbResp1;
        private System.Windows.Forms.RadioButton rbResp2;
        private System.Windows.Forms.RadioButton rbResp3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbTempoRest;
        private System.Windows.Forms.Label lbMinseg;
        private System.Windows.Forms.Label lbPontuacao;
        private System.Windows.Forms.Label lbponto;
    }
}