/*
 * Copyright [2023] [Leandro Rocha]
 *
 * Licenciado sob a Licença Apache, Versão 2.0 (a "Licença");
 * você não pode usar este arquivo, exceto em conformidade com a Licença.
 * Você pode obter uma cópia da Licença em
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * A menos que exigido por lei aplicável ou acordado por escrito, o software
 * distribuído sob a Licença é distribuído "COMO ESTÁ", SEM GARANTIAS OU CONDIÇÕES DE QUALQUER
 * TIPO, expressas ou implícitas. Consulte a Licença para as permissões específicas
 * que regem as autorizações e limitações sob a Licença.
 */

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
public class SeleniumService
{
    private IWebDriver _driver;

    public SeleniumService()
    {
        ChromeOptions chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--headless");
        _driver = new ChromeDriver(chromeOptions);
    }

    public async Task NavegarParaPagina(string url)
    {
        await Task.Run(() => _driver.Navigate().GoToUrl(url));
    }

    public async Task SelecionarIndice(string indice)
    {
        await Task.Run(() =>
        {
            IWebElement selectElement = _driver.FindElement(By.XPath("/html/body/div[6]/table/tbody/tr[3]/td/div/form/div[1]/table/tbody/tr[3]/td[2]/select"));
            SelectElement selectObject = new SelectElement(selectElement);
            selectObject.SelectByValue(indice);
        });
    }

    public async Task PreencherFormulario(string data, string dataReferencia, string valor)
    {
        await Task.Run(() =>
        {
            _driver.FindElement(By.XPath("//*[@id='corrigirPorIndiceForm']/div[1]/table/tbody/tr[4]/td[2]/input"))
                .SendKeys(data);
            _driver.FindElement(By.XPath("//*[@id='corrigirPorIndiceForm']/div[1]/table/tbody/tr[5]/td[2]/input"))
                .SendKeys(dataReferencia);
            _driver.FindElement(By.XPath("//*[@id='corrigirPorIndiceForm']/div[1]/table/tbody/tr[6]/td[2]/input"))
                .SendKeys(valor);
        });
    }
    public async Task RealizarCorrecao()
    {
        await Task.Run(() =>
        {
            _driver.FindElement(By.XPath("//*[@id='corrigirPorIndiceForm']/div[2]/input[1]"))
                .Click();
        });
    }

    public async Task<string> ObterValorPercentual()
    {
        return await Task.Run(() =>
        {
            string valorPercentual = _driver.FindElement(By.XPath("/html/body/div[6]/table/tbody/tr/td/div[2]/table[1]/tbody/tr[7]/td[2]")).Text;
            valorPercentual = valorPercentual.Replace(" ", "");
            return valorPercentual;
        });
    }

    public async Task<string> ObterValorCorrigido()
    {
        return await Task.Run(() =>
        {
            string valorCorrigido = _driver.FindElement(By.XPath("/html/body/div[6]/table/tbody/tr/td/div[2]/table[1]/tbody/tr[8]/td[2]")).Text;
            valorCorrigido = valorCorrigido.Replace("R$", "").Replace("REAL", "").Replace(" ", "").Replace("(", "").Replace(")", "");
            return valorCorrigido;
        });
    }

    public async Task Finalizar()
    {
        await Task.Run(() =>
        {
            _driver.Quit();
        });
    }
}

