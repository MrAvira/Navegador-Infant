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
            this.btnSair.Location = new System.Drawing.Point(528, 377);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(120, 23);
            this.btnSair.TabIndex = 0;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnVerificar
            // 
            this.btnVerificar.Location = new System.Drawing.Point(385, 377);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(120, 23);
            this.btnVerificar.TabIndex = 1;
            this.btnVerificar.Text = "Verificar";
            this.btnVerificar.UseVisualStyleBackColor = true;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(385, 348);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(120, 23);
            this.btnIniciar.TabIndex = 2;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // rtbPergunta
            // 
            this.rtbPergunta.Location = new System.Drawing.Point(12, 12);
            this.rtbPergunta.Name = "rtbPergunta";
            this.rtbPergunta.Size = new System.Drawing.Size(636, 176);
            this.rtbPergunta.TabIndex = 3;
            this.rtbPergunta.Text = "";
            // 
            // rbResp1
            // 
            this.rbResp1.AutoSize = true;
            this.rbResp1.Location = new System.Drawing.Point(12, 258);
            this.rbResp1.Name = "rbResp1";
            this.rbResp1.Size = new System.Drawing.Size(89, 21);
            this.rbResp1.TabIndex = 4;
            this.rbResp1.TabStop = true;
            this.rbResp1.Text = "Resposta";
            this.rbResp1.UseVisualStyleBackColor = true;
            // 
            // rbResp2
            // 
            this.rbResp2.AutoSize = true;
            this.rbResp2.Location = new System.Drawing.Point(271, 258);
            this.rbResp2.Name = "rbResp2";
            this.rbResp2.Size = new System.Drawing.Size(89, 21);
            this.rbResp2.TabIndex = 5;
            this.rbResp2.TabStop = true;
            this.rbResp2.Text = "Resposta";
            this.rbResp2.UseVisualStyleBackColor = true;
            // 
            // rbResp3
            // 
            this.rbResp3.AutoSize = true;
            this.rbResp3.Location = new System.Drawing.Point(538, 258);
            this.rbResp3.Name = "rbResp3";
            this.rbResp3.Size = new System.Drawing.Size(89, 21);
            this.rbResp3.TabIndex = 6;
            this.rbResp3.TabStop = true;
            this.rbResp3.Text = "Resposta";
            this.rbResp3.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbTempoRest
            // 
            this.lbTempoRest.AutoSize = true;
            this.lbTempoRest.Location = new System.Drawing.Point(12, 369);
            this.lbTempoRest.Name = "lbTempoRest";
            this.lbTempoRest.Size = new System.Drawing.Size(112, 17);
            this.lbTempoRest.TabIndex = 7;
            this.lbTempoRest.Text = "Tempo restante:";
            // 
            // lbMinseg
            // 
            this.lbMinseg.AutoSize = true;
            this.lbMinseg.Location = new System.Drawing.Point(12, 386);
            this.lbMinseg.Name = "lbMinseg";
            this.lbMinseg.Size = new System.Drawing.Size(81, 17);
            this.lbMinseg.TabIndex = 8;
            this.lbMinseg.Text = "0 min 0 seg";
            // 
            // lbPontuacao
            // 
            this.lbPontuacao.AutoSize = true;
            this.lbPontuacao.Location = new System.Drawing.Point(195, 369);
            this.lbPontuacao.Name = "lbPontuacao";
            this.lbPontuacao.Size = new System.Drawing.Size(80, 17);
            this.lbPontuacao.TabIndex = 9;
            this.lbPontuacao.Text = "Pontuação:";
            // 
            // lbponto
            // 
            this.lbponto.AutoSize = true;
            this.lbponto.Location = new System.Drawing.Point(195, 386);
            this.lbponto.Name = "lbponto";
            this.lbponto.Size = new System.Drawing.Size(63, 17);
            this.lbponto.TabIndex = 10;
            this.lbponto.Text = "0 pontos";
            // 
            // FormJogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 412);
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
            this.Name = "FormJogo";
            this.Text = "FormJogo";
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