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

using Indices.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;

namespace CorrigirDebitos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CorrigirDebitosController : ControllerBase
{
    private readonly SeleniumService _seleniumService;

    public CorrigirDebitosController(SeleniumService seleniumService)
    {
        _seleniumService = seleniumService;
    }

    [HttpPost]
    public async Task<IActionResult> CorrecaoDebitos([FromForm] CorrigirDebitos requisicao)
    {
        if (requisicao.ArquivoCSV != null && requisicao.ArquivoCSV.Length > 0)
        {
            var csvResultado = new StringBuilder();
            csvResultado.AppendLine("NOME;NF;REF;DEBITO;PORCENTAGEM;CORRECAO");

            string indice = requisicao.Indice.BuscarCodigoDoIndice();

            DateTime dataAtual = DateTime.Now;
            DateTime mesAnterior = dataAtual.AddMonths(-1);
            string dataReferencia = string.IsNullOrEmpty(requisicao.MesAno) ? mesAnterior.ToString("MMyyyy") : requisicao.MesAno;

            using (var reader = new StreamReader(requisicao.ArquivoCSV.OpenReadStream()))
            {
                bool primeiraLinha = true;
                while (!reader.EndOfStream)
                {
                    var linha = reader.ReadLine();
                    if (primeiraLinha)
                    {
                        primeiraLinha = false;
                        continue;
                    }
                    string[] valores = linha.Split(';');
                    if (valores.Length >= 4 && valores.Length < 5)
                    {
                        await _seleniumService.NavegarParaPagina("https://www3.bcb.gov.br/CALCIDADAO/publico/corrigirPorIndice.do?method=corrigirPorIndice");
                        await _seleniumService.SelecionarIndice(indice);

                        string empresa = valores[0];
                        string notaFiscal = valores[1];
                        string valor = valores[3];
                        string data = valores[2];

                        DateTime dataObj = DateTime.ParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        data = dataObj.ToString("MMyyyy");

                        await _seleniumService.PreencherFormulario(data, dataReferencia, valor);
                        await _seleniumService.RealizarCorrecao();

                        string valorPercentual = await _seleniumService.ObterValorPercentual();
                        string valorCorrigido = await _seleniumService.ObterValorCorrigido();

                        valorPercentual = valorPercentual.Replace(" ", "");
                        valorCorrigido = valorCorrigido.Replace("R$", "").Replace("REAL", "").Replace(" ", "").Replace("(", "").Replace(")", "");

                        string linhaCSV = $"{empresa};{notaFiscal};{valores[2]};{valores[3]};{valorPercentual};{valorCorrigido}";
                        csvResultado.AppendLine(linhaCSV);

                    }

                }
                await _seleniumService.Finalizar();
            }
            string nomeArquivo = "resultado.csv";
            Response.Headers.Add("Content-Disposition", $"attachment; filename={nomeArquivo}");
            Response.ContentType = "text/csv";
            return Content(csvResultado.ToString());
        }
        return BadRequest("Por favor, selecione um arquivo CSV.");
    }
}