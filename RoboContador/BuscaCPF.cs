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
        /// <param name="nrExame">nr do exame(1 ou 2 (acho))</param>
        /// <param name="anoExame">ano do exame</param>
        public string BuscarCPF(List<Aluno> alunos = null, string nrExame = "1", string anoExame = "2019")
        {
            List<Aluno> listaFinal = new List<Aluno>();

            if (alunos.Count == 0)
            {
                return "Nenhum aluno encontrado no excel selecionado.";
            }

            try
            {
                string site = "https://cfc.org.br/category/exame-de-suficiencia-anteriores/";
                driver = CreateDriver(site);

                foreach (Aluno aluno in alunos)
                {
                    //Escolhe qual o nr do exame a ser pesquisado
                    try
                    {
                        ClickElement(driver.FindElement(By.XPath(string.Format("(//a[contains(@href, \'https://cfc.org.br/exame-de-suficiencia-anteriores/{0}o-exame-de-suficiencia-de-{1}/\')])[2]", nrExame, anoExame))));
                    }
                    catch
                    {
                        return "Exame selecionado não está disponivel para consulta no momento.";
                    }

                    //Clica no local de prova
                    try
                    {
                        ClickElement(driver.FindElement(By.CssSelector("p:nth-child(23) strong")));
                    }
                    catch
                    {
                        return "Ocorreu um erro ao tentar verificar o local de prova.";
                    }

                    //Escreve cpf
                    driver.FindElement(By.Id("ContentPlaceHolder1_UserName")).SendKeys(aluno.Cpf);

                    //clica em entrar
                    driver.FindElement(By.Id("ContentPlaceHolder1_LoginButton")).Click();





                    if (!driver.PageSource.Contains("Não foi encontrado nenhum local de prova para esse CPF."))
                    {
                        //if (!apenasAprovados || driver.FindElement(By.Id("dtlLocalProva_CodInscricaoLabel_0")).Text == aluno.Inscricao.ToString())
                        //{
                        //    //colocar aluno na tabela do excell
                        //}
                        listaFinal.Add(aluno);
                    }

                    //driver.Close();

                    ////Seleciona a nova janela
                    //driver.SwitchTo().Window(driver.WindowHandles.Last());
                    driver.Navigate().GoToUrl(site);
                }

                if (listaFinal.Count == 0)
                {
                    return "Nenhum aluno do excel selecionado passou/esta realizando essa etapa da OAB.";
                }

                //chamar funçao que cria tabela do excell com a listaFinal
                ExportarExcel export = new ExportarExcel();
                export.Exportar(listaFinal);
            }
            catch (Exception exception)
            {
                string s = exception.Message;
                return "Erro não esperado encontrado, tente novamente mais tarde ou contate os Alunxs Brilhantes." +
                    Environment.NewLine + exception.Message;
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

        void ClickElement(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
            element.Click();
        }
    }
}
