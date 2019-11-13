using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboContador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Iniciar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Aluno> alunos = new List<Aluno>();
            if (rbAlunosAprovados.Checked)
            {
                //pega lista de alunos do excel
                List<Aluno> alunosExcel = Dados.BuscarListaAlunos(TbNomeEnderecoExcel.Text);

                ConvertePDF pdftxt = new ConvertePDF();
                String texto = pdftxt.ExtrairTexto_PDF(txtCaminoNomePDF.Text);
                texto.Replace("\n", " ");
                texto.TrimEnd(new char[] { '\n' });
                texto.TrimStart(new char[] { '\n' });

                //pega as listas de aluno do pdf e faz match com nomes do excel
                alunos = PegarMatchAluno(alunosExcel, texto);
            }
            else
            {
                //so precisa dos alunos do excel nesse modo
                alunos = Dados.BuscarListaAlunos(TbNomeEnderecoExcel.Text);
            }

            BuscaCPF busca = new BuscaCPF();
            //O 1 TEM Q SER O NR DO EXAME
            //O 2019 TEM Q SER O ANO DO EXAME!!!
            MessageBox.Show(busca.BuscarCPF(alunos, "1", "2019"));
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Codigo para achar os alunos no pdf que tem o nome no excel de alunos
        /// </summary>
        /// <param name="alunosExcel">todos os alunos do excel</param>
        /// <param name="texto">o texto do pdf</param>
        /// <returns>a lista de alunos que deram match de nome do pfd com o excel</returns>
        List<Aluno> PegarMatchAluno(List<Aluno> alunosExcel, string texto)
        {
            List<Aluno> alunos = new List<Aluno>();
            //
            //DOUGLAS, FAZER TEU CODIGO AQUI!!!
            //
            return alunos;
        }

        private void BtnProcurarExcel_Click(object sender, EventArgs e)
        {
            //define as propriedades do controle 
            //OpenFileDialog
            this.ofd1.Multiselect = false;
            this.ofd1.Title = "Selecionar PDF";
            ofd1.InitialDirectory = @"C:\dados";
            //filtra para exibir somente arquivos de imagens
            ofd1.Filter = "All files (*.*)|*.*" + "Files (*.xls)|*.XLS|";
            ofd1.CheckFileExists = true;
            ofd1.CheckPathExists = true;
            ofd1.FilterIndex = 2;
            ofd1.RestoreDirectory = true;
            ofd1.ReadOnlyChecked = true;
            ofd1.ShowReadOnly = false;

            DialogResult dr = this.ofd1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                TbNomeEnderecoExcel.Text = ofd1.FileName;
            }
        }

        private void rbAlunosAprovados_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAlunosAprovados.Checked)
            {
                //mostrar pdf
                label1.Visible = true;
                btnProcurar.Visible = true;
                txtCaminoNomePDF.Visible = true;
            }
            else
            {
                //tirar pdf
                label1.Visible = false;
                btnProcurar.Visible = false;
                txtCaminoNomePDF.Visible = false;
            }
        }
    }
}
