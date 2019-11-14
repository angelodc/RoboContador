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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Iniciar = new System.Windows.Forms.Button();
            this.gbAfase = new System.Windows.Forms.GroupBox();
            this.rb2Fase = new System.Windows.Forms.RadioButton();
            this.rb1Fase = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAlunosAprovados = new System.Windows.Forms.RadioButton();
            this.rbAlunosQueFizeramOExame = new System.Windows.Forms.RadioButton();
            this.BtnProcurarExcel = new System.Windows.Forms.Button();
            this.TbNomeEnderecoExcel = new System.Windows.Forms.TextBox();
            this.ofd1 = new System.Windows.Forms.OpenFileDialog();
            this.lblCaminhoExcel = new System.Windows.Forms.Label();
            this.btnProcurar = new System.Windows.Forms.Button();
            this.txtCaminoNomePDF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.gbAfase.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // Iniciar
            // 
            resources.ApplyResources(this.Iniciar, "Iniciar");
            this.Iniciar.Name = "Iniciar";
            this.Iniciar.UseVisualStyleBackColor = true;
            this.Iniciar.Click += new System.EventHandler(this.Iniciar_Click);
            // 
            // gbAfase
            // 
            this.gbAfase.Controls.Add(this.label2);
            this.gbAfase.Controls.Add(this.numericUpDown1);
            this.gbAfase.Controls.Add(this.rb2Fase);
            this.gbAfase.Controls.Add(this.rb1Fase);
            resources.ApplyResources(this.gbAfase, "gbAfase");
            this.gbAfase.Name = "gbAfase";
            this.gbAfase.TabStop = false;
            // 
            // rb2Fase
            // 
            resources.ApplyResources(this.rb2Fase, "rb2Fase");
            this.rb2Fase.Name = "rb2Fase";
            this.rb2Fase.UseVisualStyleBackColor = true;
            // 
            // rb1Fase
            // 
            resources.ApplyResources(this.rb1Fase, "rb1Fase");
            this.rb1Fase.Checked = true;
            this.rb1Fase.Name = "rb1Fase";
            this.rb1Fase.TabStop = true;
            this.rb1Fase.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAlunosAprovados);
            this.groupBox1.Controls.Add(this.rbAlunosQueFizeramOExame);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.groupBox1.UseCompatibleTextRendering = true;
            // 
            // rbAlunosAprovados
            // 
            resources.ApplyResources(this.rbAlunosAprovados, "rbAlunosAprovados");
            this.rbAlunosAprovados.Checked = true;
            this.rbAlunosAprovados.Name = "rbAlunosAprovados";
            this.rbAlunosAprovados.TabStop = true;
            this.rbAlunosAprovados.UseVisualStyleBackColor = true;
            this.rbAlunosAprovados.CheckedChanged += new System.EventHandler(this.rbAlunosAprovados_CheckedChanged);
            // 
            // rbAlunosQueFizeramOExame
            // 
            resources.ApplyResources(this.rbAlunosQueFizeramOExame, "rbAlunosQueFizeramOExame");
            this.rbAlunosQueFizeramOExame.Name = "rbAlunosQueFizeramOExame";
            this.rbAlunosQueFizeramOExame.UseVisualStyleBackColor = true;
            // 
            // BtnProcurarExcel
            // 
            resources.ApplyResources(this.BtnProcurarExcel, "BtnProcurarExcel");
            this.BtnProcurarExcel.Name = "BtnProcurarExcel";
            this.BtnProcurarExcel.UseVisualStyleBackColor = true;
            this.BtnProcurarExcel.Click += new System.EventHandler(this.BtnProcurarExcel_Click);
            // 
            // TbNomeEnderecoExcel
            // 
            resources.ApplyResources(this.TbNomeEnderecoExcel, "TbNomeEnderecoExcel");
            this.TbNomeEnderecoExcel.Name = "TbNomeEnderecoExcel";
            // 
            // lblCaminhoExcel
            // 
            resources.ApplyResources(this.lblCaminhoExcel, "lblCaminhoExcel");
            this.lblCaminhoExcel.Name = "lblCaminhoExcel";
            // 
            // btnProcurar
            // 
            resources.ApplyResources(this.btnProcurar, "btnProcurar");
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.UseVisualStyleBackColor = true;
            this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
            // 
            // txtCaminoNomePDF
            // 
            resources.ApplyResources(this.txtCaminoNomePDF, "txtCaminoNomePDF");
            this.txtCaminoNomePDF.Name = "txtCaminoNomePDF";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // numericUpDown1
            // 
            resources.ApplyResources(this.numericUpDown1, "numericUpDown1");
            this.numericUpDown1.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Value = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.gbAfase.ResumeLayout(false);
            this.gbAfase.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

