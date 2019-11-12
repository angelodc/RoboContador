using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace RoboContador
{
    class BuscaCPF
    {
        IWebDriver driver;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alunos">lista dos alunos os quais precisam buscar o cpf</param>
        /// <param name="etapa">se é a primeira ou segunda fase da OAB</param>
        /// <param name="nrExame"></param>
        /// <param name="apenasAprovados"></param>
        public string BuscarCPF(List<Aluno> alunos = null, int etapa = 1, string nrExame = "XXIX", bool apenasAprovados = true)
        {
            List<Aluno> listaFinal = new List<Aluno>();

            if (alunos.Count == 0)
            {
                if (apenasAprovados)
                {
                    return "Nenhum aluno com nome igual ao da lista encontrado.";
                }
                return "Nenhum aluno encontrado no excel selecionado.";
            }

            try
            {
                string site = "https://fgvprojetos.fgv.br/node/135";
                driver = CreateDriver(site);

                foreach (Aluno aluno in alunos)
                {
                    //Escolhe qual o nr do exame a ser pesquisado
                    try
                    {
                        driver.FindElement(By.LinkText(string.Format("Clique aqui para acessar informações relativas ao {0} Exame de Ordem Unificado", nrExame))).Click();
                    }
                    catch
                    {
                        return "Exame selecionado não está disponivel para consulta no momento.";
                    }

                    //Escolha dropdown do estado
                    IWebElement dropdown = driver.FindElement(By.Id("ContentPlaceHolder1_listSeccional"));
                    dropdown.FindElement(By.XPath(string.Format("option[. = 'OAB / {0}']", aluno.Estado))).Click();
                    //dropdown.FindElement(By.XPath("//option[. = 'OAB / " + aluno.Estado + "']")).Click();

                    //Escolhe fase da prova a consultar -> depois desse abre outra janela
                    if (etapa == 1)
                    {
                        driver.FindElement(By.LinkText("Consulta Local de Realização da Prova Objetiva (1ª fase)")).Click();
                    }
                    else
                    {
                        try
                        {
                            driver.FindElement(By.LinkText("Consulta Local de Realização da Prova Prático-Profissional (2ª fase)")).Click();
                        }
                        catch
                        {
                            return "2ª fase ainda não disponivel para consulta.";
                        }
                    }

                    // Seleciona a nova janela
                    driver.SwitchTo().Window(driver.WindowHandles.Last());

                    // Coloca o cpf
                    driver.FindElement(By.Id("ContentPlaceHolder1_UserName")).SendKeys(aluno.Cpf);

                    //Pesquisa o cpf
                    driver.FindElement(By.Id("ContentPlaceHolder1_BtnPesquisar")).Click();

                    if (!driver.PageSource.Contains("Não foi localizado local de prova para o CPF informado."))
                    {
                        //Fecha janela de aviso
                        driver.FindElement(By.Id("lkProsseguir")).Click();

                        if (!apenasAprovados || driver.FindElement(By.Id("dtlLocalProva_CodInscricaoLabel_0")).Text == aluno.Inscricao.ToString())
                        {
                            //colocar aluno na tabela do excell
                            listaFinal.Add(aluno);
                        }
                    }

                    driver.Close();

                    //Seleciona a nova janela
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    driver.Navigate().GoToUrl(site);
                }

                if (listaFinal.Count == 0)
                {
                    if (apenasAprovados)
                    {
                        return "Nenhum aluno do excel selecionado passou nessa etapa da OAB.";
                    }
                    return "Nenhum aluno do excel selecionado esta realizando essa etapa da OAB.";
                }

                //chamar funçao que cria tabela do excell com a listaFinal
                ExportarExcel export = new ExportarExcel();
                export.Exportar(listaFinal);
            }
            catch (Exception exception)
            {
                string s = exception.Message;
                return "Erro não esperado encontrado, tente novamente mais tarde ou contate os Alunxs Brilhantes." + Environment.NewLine + exception.Message;
            }

            return "Programa finalizado com sucesso." + Environment.NewLine + "Favor salvar o arquivo de Excel.";
        }

        IWebDriver CreateDriver(string url = "")
        {
            //IWebDriver driver = new ChromeDriver();
            var chromeDriverService = ChromeDriverService.CreateDefaultService(Environment.CurrentDirectory);
            chromeDriverService.HideCommandPromptWindow = true;
            IWebDriver driver = new ChromeDriver(chromeDriverService);
            driver.Manage().Window.Maximize();
            driver.Url = url;
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 3, 0);
            return driver;
        }
    }
}
