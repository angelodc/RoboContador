using System;
using System.Runtime.InteropServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
//using Dapper;

namespace RoboContador
{
    public static class Dados
    {
        static Excel.Application xlApp;
        static Excel.Workbook xlWorkbook;
        static Excel._Worksheet xlWorksheet;
        static Excel.Range xlRange;

        /// <summary>
        /// Busca todos alunos na planilha Excel.
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="estado"></param>
        /// <returns></returns>
        public static List<Aluno> BuscarListaAlunos(String directory)
        {
            try
            {
                StartExcel(directory);
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                List<Aluno> alunos = new List<Aluno>();

                for (int i = 2; i <= rowCount; i++)
                {
                    //aluno = new Aluno();
                    string cpf = string.Empty;
                    string nome = string.Empty;
                    string semestre = string.Empty;
                    for (int j = 1; j <= colCount; j++)
                    {
                        Excel.Range cellHead = xlRange.Cells[1, j];
                        Excel.Range cellValue = xlRange.Cells[i, j];
                        if (cpf.Equals(string.Empty))
                        {
                            cpf = PopularAluno(cellHead, cellValue, "CPF");
                            if (!cpf.Equals(string.Empty))
                            {
                                cpf = TratarCpf(cpf);
                            }
                        }
                        if (nome.Equals(string.Empty))
                        {
                            nome = PopularAluno(cellHead, cellValue, "NOME");
                        }
                        if (semestre.Equals(string.Empty))
                        {
                            semestre = PopularAluno(cellHead, cellValue, "SEMESTRE");
                        }
                    }
                    if (!VerificarLinhaVazia(cpf, nome))
                    {
                        Aluno aluno = new Aluno();
                        aluno.Cpf = cpf;
                        aluno.Nome = nome;
                        aluno.Semestre = semestre;
                        //aluno.Estado = estado;
                        if (!alunos.Contains(aluno))
                        {
                            alunos.Add(aluno);
                        }
                    }
                }
                return alunos;
            }
            catch (Exception)
            {
                throw new Exception("Erro na busca de dados no excel.");
            }
            finally
            {
                StopExcel();
            }
        }

        public static void ExportarExcel(System.Windows.Forms.DataGridView dvgAlunos)
        {
            Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                XcelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dvgAlunos.Columns.Count + 1; i++)
                {
                    XcelApp.Cells[1, i] = dvgAlunos.Columns[i - 1].HeaderText;
                }
                //
                for (int i = 0; i < dvgAlunos.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dvgAlunos.Columns.Count; j++)
                    {
                        XcelApp.Cells[i + 2, j + 1] = dvgAlunos.Rows[i].Cells[j].Value.ToString();
                    }
                }
                XcelApp.Columns.AutoFit();
                XcelApp.Visible = true;
            }
            catch (Exception ex)
            {
                XcelApp.Quit();
                throw ex;
            }
        }

        public static bool VerificarLinhaVazia(string cpf, string nome)
        {
            if (cpf.Equals(string.Empty) || nome.Equals(string.Empty))
            {
                return true;
            }
            return cpf.Equals(string.Empty)
                && nome.Equals(string.Empty);
        }

        /// <summary>
        /// Método que retorna o index X e Y na tabela do valor informado
        /// </summary>
        /// <param name="range">Range a ser percorrido.</param>
        /// <param name="value">Valor a ser procurado na tabela.</param>
        /// <param name="lengthX">Tamanho do range X a ser percorrido.</param>
        /// <param name="lengthY">Tamanho do range Y a ser percorrido.</param>
        /// <param name="x">Indice do inicio da pesquisa.</param>
        /// <param name="y">Indice do inicio da pesquisa.</param>
        /// <returns> Array, onde o valor 0 é equivalente ao X na tabela e 1 ao valor Y.</returns>
        public static int[] GetIndexByValue(Excel.Range range, string value, int lengthX, int lengthY, int x = 1, int y = 1)
        {
            for (int i = x; i <= lengthX; i++)
            {
                for (int j = y; j <= lengthY; j++)
                {
                    Excel.Range cell = range.Cells[i, j];
                    if (value.Equals(cell.Text.ToString()))
                    {
                        return new int[] { i, j };
                    }
                }
            }
            throw new Exception(String.Format("Campo com valor {0} não existe na tabela.", value));
        }

        private static string PopularAluno(Excel.Range cellHead, Excel.Range cellValue, string campo)
        {
            if ((cellHead.Text != null && cellValue.Text != null) && (cellHead.Value2 != null && cellValue.Value2 != null))
            {
                String head = (cellHead.Text.ToString() as String).Trim();

                if (head.ToUpper() != campo)
                {
                    return string.Empty;
                }

                switch (head.ToUpper())
                {
                    case "CPF":
                        string cpf = (cellValue.Text.ToString() as String).Trim();
                        if (cpf != "Não informado")
                        {
                            return cpf;
                        }
                        break;
                    case "NOME":
                        return (cellValue.Text.ToString() as String).Trim();
                    case "SEMESTRE":
                        return (cellValue.Text.ToString() as String).Trim();
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// caso esteja faltando algum 0 na frente do cpf essa funçao arruma
        /// </summary>
        /// <param name="cpf">O cpf a arrumar</param>
        /// <returns></returns>
        static string TratarCpf(string cpf)
        {
            while (cpf.Length < 11)
            {
                cpf = cpf.Insert(0, "0");
            }
            return cpf;
        }

        private static void StartExcel(String directory)
        {
            xlApp = new Excel.Application();
            xlWorkbook = xlApp.Workbooks.Open(directory);
            xlWorksheet = xlWorkbook.Sheets[1];
            xlRange = xlWorksheet.UsedRange;
        }

        private static void StopExcel()
        {
            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }
    }
}