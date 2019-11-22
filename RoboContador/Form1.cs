using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

                //ConvertePDF pdftxt = new ConvertePDF();
                //String texto = pdftxt.ExtrairTexto_PDF(txtCaminoNomePDF.Text);
                String texto = new ConvertePDF().ExtrairTexto_PDF(txtCaminoNomePDF.Text);

                //pega as listas de aluno do pdf e faz match com nomes do excel
                alunos = PegarMatchAluno(alunosExcel, texto);
            }
            else
            {
                //so precisa dos alunos do excel nesse modo
                alunos = Dados.BuscarListaAlunos(TbNomeEnderecoExcel.Text);
            }

            string nrExame = "1";
            if (rb2Fase.Checked)
            {
                nrExame = "2";
            }
            //BuscaCPF busca = new BuscaCPF();
            //MessageBox.Show(busca.BuscarCPF(alunos, nrExame, numericUpDown1.Value.ToString()));
            MessageBox.Show(new BuscaCPF().BuscarCPF(alunos, nrExame, numericUpDown1.Value.ToString()));
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

            texto.Replace("\n", " ");
            string[] pdfDividido = texto.Split(' ');
            bool estaNainscricao = false, estaNoNome = false; int b = 0;
            string nome = string.Empty, inscricao = string.Empty;
            double numero = 0;
            int teste = 0;
            foreach (string i in pdfDividido)
            {

                pdfDividido[b] = pdfDividido[b].TrimStart(new char[] { '\n' });
                pdfDividido[b] = pdfDividido[b].TrimEnd(new char[] { '\n' });

                if (pdfDividido[b] == "Nome")
                {
                    estaNainscricao = true;
                }
                else if (pdfDividido[b] == "Inscrição")
                {
                    estaNoNome = false;
                }
                if (estaNoNome == true && double.TryParse(pdfDividido[b], out numero))
                {
                    estaNainscricao = true;
                    estaNoNome = false;
                    if (!inscricao.Equals(string.Empty))
                    {
                        nome.Trim();
                        foreach (Aluno alunoExcel in alunosExcel)
                        {
                            teste++;
                            if (RemoveDiacritics(alunoExcel.Nome.ToUpper()) == RemoveDiacritics(nome.Trim().ToUpper()))
                            {
                                Aluno aluno = new Aluno(nome.Trim(), "RS", "POA", inscricao.Trim(), alunoExcel.Cpf, alunoExcel.Semestre);
                                alunos.Add(aluno);
                            }
                        }
                    }
                    nome = string.Empty; inscricao = string.Empty;
                }
                if (estaNainscricao == true && double.TryParse(pdfDividido[b], out numero))
                {
                    inscricao = pdfDividido[b];
                    estaNainscricao = false;
                    estaNoNome = true;
                }
                else if (estaNoNome == true)
                {
                    nome += pdfDividido[b] + " ";
                }
                b++;
            }
            return alunos;
        }

        /// <summary>
        /// Metodo para tirar acento de strings
        /// </summary>
        /// <param name="text">string a qual voce quer retirar os acentos</param>
        /// <returns></returns>
        string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
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

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            //define as propriedades do controle 
            //OpenFileDialog
            this.ofd1.Multiselect = false;
            this.ofd1.Title = "Selecionar PDF";
            ofd1.InitialDirectory = @"C:\dados";
            //filtra para exibir somente arquivos de imagens
            ofd1.Filter = "All files (*.*)|*.*" + "Files (*.PDF)|*.PDF|";
            ofd1.CheckFileExists = true;
            ofd1.CheckPathExists = true;
            ofd1.FilterIndex = 2;
            ofd1.RestoreDirectory = true;
            ofd1.ReadOnlyChecked = true;
            ofd1.ShowReadOnly = false;

            DialogResult dr = this.ofd1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                txtCaminoNomePDF.Text = ofd1.FileName;
            }
        }
    }
}
