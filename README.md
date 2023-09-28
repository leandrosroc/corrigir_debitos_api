# Correção de Débitos Automatizada

Este projeto é uma API com C# desenvolvida como uma evolução do [projeto original em Python](https://github.com/leandrosroc/corrigir_debitos). Ela foi criada para oferecer a funcionalidade de automatizar a correção de débitos, levando em consideração a inflação ocorrida durante um período específico. O usuário tem a flexibilidade de escolher o índice de correção desejado antes de iniciar o processo.

## Funcionalidades Principais

- Aceita o envio de um [arquivo CSV](https://github.com/leandrosroc/corrigir_debitos/blob/main/arquivosBase/baseExemplo.csv) contendo informações sobre os débitos, como nome da empresa, número da nota fiscal, data e valor.
- Utiliza o Selenium WebDriver para automatizar o processo de correção, navegando para uma página web onde o índice de correção pode ser definido.
- Realiza cálculos de correção de acordo com o índice escolhido, aplicando-os aos débitos do arquivo CSV.
- Gera um novo [arquivo CSV](https://github.com/leandrosroc/corrigir_debitos/blob/main/arquivosBase/baseExemploFinalizada.csv) contendo informações detalhadas, como o débito corrigido e a porcentagem de correção.

## Motivação

Esta automação oferece uma solução eficiente e escalável para o processo de correção de débitos, economizando tempo e esforço que normalmente seriam gastos em tarefas manuais. A API em C# foi criada como uma alternativa ao projeto original em Python, proporcionando maior flexibilidade e desempenho.

## Como Usar

Para começar a utilizar a API e automatizar a correção de débitos, siga estas etapas:

1. Clone o repositório para a sua máquina local.
2. Certifique-se de ter o ambiente de desenvolvimento C# configurado.
3. Execute a aplicação.
4. Envie um arquivo CSV contendo as informações dos débitos a serem corrigidos.
5. Escolha o índice de correção desejado.
6. A API irá processar os dados, realizar a correção e gerar um arquivo CSV com os resultados.

## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues, sugestões ou pull requests para melhorar este projeto.

## Licença

Este projeto é licenciado sob a Licença Apache, Versão 2.0. Para mais detalhes, consulte o arquivo [LICENSE](LICENSE).

## Autor

Este projeto foi desenvolvido por [Leandro Rocha](https://github.com/leandrosroc).

Aproveite a automação da correção de débitos e simplifique suas tarefas financeiras!
