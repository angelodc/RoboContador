namespace RoboContador
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Iniciar = new System.Windows.Forms.Button();
            this.gbAfase = new System.Windows.Forms.GroupBox();
            this.rb2Fase = new System.Windows.Forms.RadioButton();
            this.rb1Fase = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAlunosAprovados = new System.Windows.Forms.RadioButton();
            this.rbAlunosQueFizeramOExame = new System.Windows.Forms.RadioButton();
            this.BtnProcurarExcel = new System.Windows.Forms.Button();
            this.TbNomeEnderecoExcel = new System.Windows.Forms.TextBox();
            this.lblCaminhoExcel = new System.Windows.Forms.Label();
            this.btnProcurar = new System.Windows.Forms.Button();
            this.txtCaminoNomePDF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbAfase.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Iniciar
            // 
            this.Iniciar.Location = new System.Drawing.Point(18, 279);
            this.Iniciar.Name = "Iniciar";
            this.Iniciar.Size = new System.Drawing.Size(75, 23);
            this.Iniciar.TabIndex = 0;
            this.Iniciar.Text = "Iniciar";
            this.Iniciar.UseVisualStyleBackColor = true;
            this.Iniciar.Click += new System.EventHandler(this.Iniciar_Click);
            // 
            // gbAfase
            // 
            this.gbAfase.Controls.Add(this.rb2Fase);
            this.gbAfase.Controls.Add(this.rb1Fase);
            this.gbAfase.Location = new System.Drawing.Point(18, 12);
            this.gbAfase.Name = "gbAfase";
            this.gbAfase.Size = new System.Drawing.Size(285, 52);
            this.gbAfase.TabIndex = 15;
            this.gbAfase.TabStop = false;
            this.gbAfase.Text = "Fase";
            // 
            // rb2Fase
            // 
            this.rb2Fase.AutoSize = true;
            this.rb2Fase.Location = new System.Drawing.Point(109, 15);
            this.rb2Fase.Name = "rb2Fase";
            this.rb2Fase.Size = new System.Drawing.Size(61, 17);
            this.rb2Fase.TabIndex = 1;
            this.rb2Fase.Text = "2° Fase";
            this.rb2Fase.UseVisualStyleBackColor = true;
            // 
            // rb1Fase
            // 
            this.rb1Fase.AutoSize = true;
            this.rb1Fase.Checked = true;
            this.rb1Fase.Location = new System.Drawing.Point(10, 15);
            this.rb1Fase.Name = "rb1Fase";
            this.rb1Fase.Size = new System.Drawing.Size(61, 17);
            this.rb1Fase.TabIndex = 0;
            this.rb1Fase.TabStop = true;
            this.rb1Fase.Text = "1° Fase";
            this.rb1Fase.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAlunosAprovados);
            this.groupBox1.Controls.Add(this.rbAlunosQueFizeramOExame);
            this.groupBox1.Location = new System.Drawing.Point(18, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 52);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gerar:";
            this.groupBox1.UseCompatibleTextRendering = true;
            // 
            // rbAlunosAprovados
            // 
            this.rbAlunosAprovados.AutoSize = true;
            this.rbAlunosAprovados.Checked = true;
            this.rbAlunosAprovados.Location = new System.Drawing.Point(190, 19);
            this.rbAlunosAprovados.Name = "rbAlunosAprovados";
            this.rbAlunosAprovados.Size = new System.Drawing.Size(111, 17);
            this.rbAlunosAprovados.TabIndex = 14;
            this.rbAlunosAprovados.TabStop = true;
            this.rbAlunosAprovados.Text = "Alunos Aprovados";
            this.rbAlunosAprovados.UseVisualStyleBackColor = true;
            this.rbAlunosAprovados.CheckedChanged += new System.EventHandler(this.rbAlunosAprovados_CheckedChanged);
            // 
            // rbAlunosQueFizeramOExame
            // 
            this.rbAlunosQueFizeramOExame.AutoSize = true;
            this.rbAlunosQueFizeramOExame.Location = new System.Drawing.Point(6, 19);
            this.rbAlunosQueFizeramOExame.Name = "rbAlunosQueFizeramOExame";
            this.rbAlunosQueFizeramOExame.Size = new System.Drawing.Size(161, 17);
            this.rbAlunosQueFizeramOExame.TabIndex = 13;
            this.rbAlunosQueFizeramOExame.Text = "Alunos que Fizeram o Exame";
            this.rbAlunosQueFizeramOExame.UseVisualStyleBackColor = true;
            // 
            // BtnProcurarExcel
            // 
            this.BtnProcurarExcel.Location = new System.Drawing.Point(17, 235);
            this.BtnProcurarExcel.Name = "BtnProcurarExcel";
            this.BtnProcurarExcel.Size = new System.Drawing.Size(75, 23);
            this.BtnProcurarExcel.TabIndex = 19;
            this.BtnProcurarExcel.Text = "Procurar";
            this.BtnProcurarExcel.UseVisualStyleBackColor = true;
            this.BtnProcurarExcel.Click += new System.EventHandler(this.BtnProcurarExcel_Click);
            // 
            // TbNomeEnderecoExcel
            // 
            this.TbNomeEnderecoExcel.Location = new System.Drawing.Point(99, 237);
            this.TbNomeEnderecoExcel.Name = "TbNomeEnderecoExcel";
            this.TbNomeEnderecoExcel.Size = new System.Drawing.Size(283, 20);
            this.TbNomeEnderecoExcel.TabIndex = 18;
            // 
            // lblCaminhoExcel
            // 
            this.lblCaminhoExcel.AutoSize = true;
            this.lblCaminhoExcel.Location = new System.Drawing.Point(15, 212);
            this.lblCaminhoExcel.Name = "lblCaminhoExcel";
            this.lblCaminhoExcel.Size = new System.Drawing.Size(214, 13);
            this.lblCaminhoExcel.TabIndex = 17;
            this.lblCaminhoExcel.Text = "Informe o caminho e nome do arquivo Excel";
            // 
            // btnProcurar
            // 
            this.btnProcurar.Location = new System.Drawing.Point(14, 163);
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.Size = new System.Drawing.Size(75, 23);
            this.btnProcurar.TabIndex = 21;
            this.btnProcurar.Text = "Procurar";
            this.btnProcurar.UseVisualStyleBackColor = true;
            // 
            // txtCaminoNomePDF
            // 
            this.txtCaminoNomePDF.Location = new System.Drawing.Point(99, 165);
            this.txtCaminoNomePDF.Name = "txtCaminoNomePDF";
            this.txtCaminoNomePDF.Size = new System.Drawing.Size(283, 20);
            this.txtCaminoNomePDF.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Informe o caminho e nome do arquivo PDF";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 314);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProcurar);
            this.Controls.Add(this.txtCaminoNomePDF);
            this.Controls.Add(this.BtnProcurarExcel);
            this.Controls.Add(this.TbNomeEnderecoExcel);
            this.Controls.Add(this.lblCaminhoExcel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbAfase);
            this.Controls.Add(this.Iniciar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gbAfase.ResumeLayout(false);
            this.gbAfase.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Iniciar;
        private System.Windows.Forms.GroupBox gbAfase;
        private System.Windows.Forms.RadioButton rb2Fase;
        private System.Windows.Forms.RadioButton rb1Fase;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbAlunosAprovados;
        private System.Windows.Forms.RadioButton rbAlunosQueFizeramOExame;
        private System.Windows.Forms.Button BtnProcurarExcel;
        private System.Windows.Forms.OpenFileDialog ofd1;
        private System.Windows.Forms.TextBox TbNomeEnderecoExcel;
        private System.Windows.Forms.Label lblCaminhoExcel;
        private System.Windows.Forms.Button btnProcurar;
        private System.Windows.Forms.TextBox txtCaminoNomePDF;
        private System.Windows.Forms.Label label1;
    }
}

