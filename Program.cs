using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Newtonsoft.Json;

namespace ScrapingATip
{
	class Program
	{
		static void Main(string[] args)
		{
			IWebDriver driver = new ChromeDriver();
			driver.Navigate().GoToUrl("https://www.boadica.com.br/produtos/p170681/");

			Produto produto = new Produto();

			produto.nome = driver.FindElement(By.ClassName("nome")).Text.ToString();
			produto.descricao = driver.FindElement(By.ClassName("especificacao")).Text.ToString();
			produto.menorValor = driver
				.FindElement(By.XPath("/html/body/div[2]/div[2]/div[1]/div/div/div[1]/div[2]/div[2]/div/div[2]/div/div/div[1]/span[1]"))
				.Text
				.ToString();
			produto.maiorValor = driver
				.FindElement(By.XPath("/html/body/div[2]/div[2]/div[1]/div/div/div[1]/div[2]/div[2]/div/div[2]/div/div/div[1]/span[2]"))
				.Text
				.ToString();

			string produtoConvertidoJson = JsonConvert.SerializeObject(produto);

			Console.WriteLine(produtoConvertidoJson);
		}
	}
}
